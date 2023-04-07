using dotnet_entrance_test.Model;
using dotnet_entrance_test.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_entrance_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(ILogger<BooksController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IActionResult> Get(int? authorId, int? rating, int? publishYear)
        {
            if (Request.Query.Count > 0)
                foreach (var item in Request.Query)
                {
                    if (item.Key != "authorId" && item.Key != "rating" && item.Key != "publishYear")
                        return BadRequest(new { message = "Error: Bad Query Request" });
                }

            try
            {
                var books = await _unitOfWork.Book.GetAsync(includeProperties: "Author");
                if (authorId != null) { books = books.Where(x => x.AuthorId == authorId); }
                if (rating != null) { books = books.Where(x => x.Rating == rating); }
                if (publishYear != null) { books = books.Where(x => x.PublishYear == publishYear); }

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _unitOfWork.Book.GetBook(id);
            if (book == null)
                return StatusCode(StatusCodes.Status404NotFound, "");
            else return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (book != null && ModelState.IsValid)
            {
                if (await _unitOfWork.Book.AnyAsync(x => x.Title == book.Title))
                    return BadRequest(new { message = "There are already other items in the database with the same name." });
                if (!await _unitOfWork.Author.AnyAsync(x => x.Id == book.AuthorId))
                    return BadRequest(new { message = "Author is not found." });
                _unitOfWork.Book.AddAsync(book);
                _unitOfWork.SaveAsync();
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Error: Bad Query Request" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                if (book.Id == 0) book.Id = id;
                else return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (!await _unitOfWork.Author.AnyAsync(x => x.Id == book.AuthorId))
                        return BadRequest(new { message = "Author is not found." });
                    _unitOfWork.Book.Update(book);
                    _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _unitOfWork.Book.AnyAsync(x => x.Id == book.Id)) return NotFound();
                    else throw;
                }
                var json = await _unitOfWork.Book.GetBook(id);
                return Ok(json);
            }
            else
            {
                return BadRequest(new { message = "Error: Bad Query Request" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (await _unitOfWork.Book.AnyAsync(x => x.Id == id))
            {
                Book book = await _unitOfWork.Book.GetBook(id);
                _unitOfWork.Book.Remove(book);
                _unitOfWork.SaveAsync();
                return Ok();

            }
            else
            {
                return NotFound(new { message = "Not Found: Item does not exist" });
            }

        }
    }
}
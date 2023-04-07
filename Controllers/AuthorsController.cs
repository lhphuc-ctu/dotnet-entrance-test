using dotnet_entrance_test.Model;
using dotnet_entrance_test.Model.JsonModel;
using dotnet_entrance_test.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_entrance_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(ILogger<AuthorsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (Request.Query.Count > 0)
                return BadRequest(new { message = "Error: Bad Query Request" });

            var authors = await _unitOfWork.Author.GetAsync();
            List<AuthorModel> authorList = new List<AuthorModel>();
            foreach (var author in authors)
            {
                AuthorModel jsonAuthor = new AuthorModel()
                {
                    Id = author.Id,
                    Name = author.Name,
                    Female = author.Female,
                    BornYear = author.Born,
                    DiedYear = author.Died,
                };
                if (author.Died != null) jsonAuthor.Age = (int)(author.Died - author.Born);
                else jsonAuthor.Age = DateTime.Now.Year - author.Born;

                authorList.Add(jsonAuthor);
            }

            return Ok(authorList);
        }
    }
}

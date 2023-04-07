using dotnet_entrance_test.Data;
using dotnet_entrance_test.Model;
using dotnet_entrance_test.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace dotnet_entrance_test.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.Where(x => x.Id == id).Include(x => x.Author).FirstAsync();
        }

        public void Update(Book book)
        {
            var _book = _context.Books.Find(book.Id);

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Price = book.Price;
                _book.Topic = book.Topic;
                _book.AuthorId = book.AuthorId;
                _book.PublishYear = book.PublishYear;
            }
        }
    }
}

using dotnet_entrance_test.Data;
using dotnet_entrance_test.Repository.IRepository;

namespace dotnet_entrance_test.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Book = new BookRepository(_context);
            Author = new AuthorRepository(_context);
        }

        public IBookRepository Book { get; private set; }
        public IAuthorRepository Author { get; private set; }

        public void SaveAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}

using dotnet_entrance_test.Data;
using dotnet_entrance_test.Model;
using dotnet_entrance_test.Repository.IRepository;

namespace dotnet_entrance_test.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private AppDbContext _context;
        public AuthorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}

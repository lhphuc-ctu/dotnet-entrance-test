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

            if (_context.Authors.Count() == 0) AddAuthorData();
        }

        public void AddAuthorData()
        {
            var authors = new List<Author>()
            {
                new Author { Id = 1, Name = "Steve Harvey", Female = false, Born = 1957 },
                new Author { Id = 2, Name = "James Allen", Female = false, Born = 1864, Died = 1912 },
                new Author { Id = 3, Name = "Robin Norwood", Female = true, Born = 1945 },
                new Author { Id = 4, Name = "Ramit Sethi", Female = false, Born = 1982 },
                new Author { Id = 5, Name = "Melody Beattie", Female = true, Born = 1948 },
                new Author { Id = 6, Name = "Dale Carnegie", Female = false, Born = 1888, Died = 1955 },
                new Author { Id = 7, Name = "Wayne Dyer", Female = false, Born = 1940 },
                new Author { Id = 8, Name = "John T. Molloy", Female = false, Born = 1937 },
                new Author { Id = 10, Name = "Allen Carr", Female = false, Born = 1934, Died = 2006 },
                new Author { Id = 12, Name = "Robert Greene", Female = false, Born = 1959},
                new Author { Id = 13, Name = "Wendy Kaminer", Female = true, Born = 1949 },
                new Author { Id = 14, Name = "David Schwartz", Female = false, Born = 1927, Died = 1987 },
                new Author { Id = 15, Name = "Robin Sharma", Female = false, Born = 1964 },
                new Author { Id = 16, Name = "Norman Vincent Peale", Female = false, Born = 1898, Died = 1993 },
                new Author { Id = 17, Name = "Maxwell Maltz", Female = false, Born = 1899, Died = 1975 },
                new Author { Id = 18, Name = "Rhonda Byrne", Female = true, Born = 1951 },
                new Author { Id = 19, Name = "Stephen Covey", Female = false, Born = 1932, Died = 2012 },
                new Author { Id = 20, Name = "Napoleon Hill", Female = false, Born = 1883, Died = 1970 },
                new Author { Id = 21, Name = "Anthony Robbins", Female = false, Born = 1960 },
                new Author { Id = 22, Name = "Louise Hay", Female = true, Born = 1926, Died = 2017 },
                new Author { Id = 23, Name = "Charles F. Haanel", Female = false, Born = 1866, Died = 1949 },
                new Author { Id = 24, Name = "Eckhart Tolle", Female = false, Born = 1948 },
                new Author { Id = 25, Name = "Diane Muldrow", Female = true, Born = 1950 },
                new Author { Id = 26, Name = "David Gillespie", Female = false, Born = 1957 },
                new Author { Id = 27, Name = "Burra Venkatesham", Female = false, Born = 1968 },
                new Author { Id = 28, Name = "Dr. Walter Doyle Staples", Female = false, Born = 1955 },
                new Author { Id = 29, Name = "Wahiduddin Khan", Female = false, Born = 1925, Died = 2021 },
                new Author { Id = 30, Name = "Paulo Coelho", Female = false, Born = 1947 },
            };
            _context.Authors.AddRange(authors);
            _context.SaveChanges();
        }
    }
}

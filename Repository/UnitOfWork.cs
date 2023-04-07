using dotnet_entrance_test.Data;
using dotnet_entrance_test.Model;
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

            if (_context.Books.Count() == 0) AddBookData();
            if (_context.Authors.Count() == 0) AddAuthorData();
        }

        public IBookRepository Book { get; private set; }
        public IAuthorRepository Author { get; private set; }

        public void SaveAsync()
        {
            _context.SaveChangesAsync();
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

        public void AddBookData()
        {
            var books = new List<Book>()
            {
                new Book{ Id=1, Title="Act like a Lady, Think like a Man", Topic="relationship", PublishYear=2009, AuthorId=1, Price=20.00, Rating=1 },
                new Book{ Id=2, Title="As a Man Thinketh", Topic="positive thinking", PublishYear=1902, AuthorId=2, Price=50.00, Rating=2 },
                new Book{ Id=3, Title="Women Who Love Too Much", Topic="relationship", PublishYear=1985, AuthorId=3, Price=15.40, Rating=3 },
                new Book{ Id=4, Title="I Will Teach You To Be Rich", Topic="success", PublishYear=2009, AuthorId=4, Price=20.00, Rating=4 },
                new Book{ Id=5, Title="Codependent No More", Topic="relationship", PublishYear=1986, AuthorId=5, Price=32.00, Rating=2 },
                new Book{ Id=6, Title="How to Stop Worrying and Start Living", Topic="optimism", PublishYear=1948, AuthorId=6, Price=50.00, Rating=4 },
                new Book{ Id=7, Title="Your Erroneous Zones", Topic="health", PublishYear=1976, AuthorId=7, Price=24.00, Rating=5 },
                new Book{ Id=8, Title="Dress for Success", Topic="success", PublishYear=1975, AuthorId=8, Price=54.20, Rating=3 },
                new Book{ Id=9, Title="The Easy Way to Stop Smoking", Topic="health", PublishYear=2006, AuthorId=9, Price=45.60, Rating=2 },
                new Book{ Id=10, Title="How to Win Friends and Influence People", Topic="success", PublishYear=1936, AuthorId=6, Price=10.20, Rating=4 },
                new Book{ Id=11, Title="The 48 Laws of Power", Topic="success", PublishYear=1998, AuthorId=10, Price=20.50, Rating=2 },
                new Book{ Id=12, Title="I'm Dysfunctional, You're Dysfunctional", Topic="anti-self-help", PublishYear=1992, AuthorId=11, Price=10.05, Rating=3 },
                new Book{ Id=13, Title="The Magic of Thinking Big", Topic="success", PublishYear=1959, AuthorId=12, Price=100.00, Rating=5 },
                new Book{ Id=14, Title="The Monk Who Sold His Ferrari", Topic="health", PublishYear=1997, AuthorId=13, Price=39.55, Rating=3 },
                new Book{ Id=15, Title="The Power of Positive Thinking", Topic="optimism", PublishYear=1952, AuthorId=14, Price=12.34, Rating=5 },
                new Book{ Id=16, Title="Psycho-Cybernetics", Topic="self image", PublishYear=1960, AuthorId=15, Price=104.50, Rating=2 },
                new Book{ Id=17, Title="The Secret", Topic="optimism", PublishYear=2006, AuthorId=16, Price=20.50, Rating=4 },
                new Book{ Id=18, Title="The Seven Habits of Highly Effective People", Topic="success", PublishYear=1989, AuthorId=17, Price=50.30, Rating=1 },
                new Book{ Id=19, Title="Think and Grow Rich", Topic="success", PublishYear=1937, AuthorId=18, Price=25.50, Rating=5 },
                new Book{ Id=20, Title="Unlimited Power", Topic="success", PublishYear=1986, AuthorId=19, Price=20.50, Rating=5 },
                new Book{ Id=21, Title="You Can Heal Your Life", Topic="health", PublishYear=1984, AuthorId=20, Price=100.00, Rating=4 },
                new Book{ Id=22, Title="The Master Key System", Topic="optimism", PublishYear=1916, AuthorId=21, Price=69.60, Rating=1 },
                new Book{ Id=23, Title="The Power of Now", Topic="optimism", PublishYear=1997, AuthorId=22, Price=45.56, Rating=4 },
                new Book{ Id=24, Title="The Magic Ladder To Success", Topic="", PublishYear=1930, AuthorId=18, Price=100.05, Rating=5 },
                new Book{ Id=25, Title="Outwitting the Devil", Topic="success", PublishYear=2011, AuthorId=18, Price=32.45, Rating=3 },
                new Book{ Id=26, Title="Selfie Of Success", Topic="success", PublishYear=2019, AuthorId=25, Price=20.60, Rating=4 },
                new Book{ Id=27, Title="Think Like a Winner!", Topic="optimism", PublishYear=1991, AuthorId=26, Price=20.50, Rating=3 },
                new Book{ Id=28, Title="Raaz-e-Hayat", Topic="optimism", PublishYear=1987, AuthorId=27, Price=14.30, Rating=5 }
            };
            _context.Books.AddRange(books);

            _context.SaveChanges();
        }
    }
}

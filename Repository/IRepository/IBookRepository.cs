using dotnet_entrance_test.Model;

namespace dotnet_entrance_test.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBook(int id);
        void Update(Book book);
    }
}

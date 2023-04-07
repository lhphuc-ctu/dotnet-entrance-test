namespace dotnet_entrance_test.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
        void SaveAsync();
    }
}

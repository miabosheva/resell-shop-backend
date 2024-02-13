namespace backend_resell_app.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<bool> SaveAsync();
    }
}

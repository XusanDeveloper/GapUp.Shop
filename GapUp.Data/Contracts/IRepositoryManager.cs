namespace GapUp.Data.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        Task SaveAsync();
    }
}

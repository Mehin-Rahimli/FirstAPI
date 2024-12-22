namespace FirstAPI.Repositories.Interfaces
{
    public interface IRepository
    {
        IQueryable<Category>GetAll();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        void Delete(Category category);
        void Update(Category category);
        Task<int> SaveChangesAsync ();

    }
}

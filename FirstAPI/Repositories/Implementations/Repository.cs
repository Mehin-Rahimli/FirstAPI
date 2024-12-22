using FirstAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories.Implementations
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;


        public Repository(AppDbContext context)
        {
            _context = context;
          
        }

       
        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async void Delete(Category category)
        {
             _context.Categories.Remove(category);
        }


        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public async Task<int> SaveChangesAsync()
        {
         return await _context.SaveChangesAsync();   
        }
    }
}

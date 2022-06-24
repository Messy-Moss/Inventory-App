using InventoryApp.Data;
using InventoryApp.Dtos;
using InventoryApp.Models;
using InventoryApp.Types;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Repository {
    public class CategoryRepository : ICategoriesRepository {
        private readonly AppDbContext _ctx;

        public CategoryRepository(AppDbContext ctx) {
            _ctx = ctx;
        }

        public async Task<Category> AddCategory(CatrgoryDto category) {

            Category newCategory = new() {
                Name = category.Name,
                Description = category.Description
            };

            await _ctx.Categories.AddAsync(newCategory);

            await _ctx.SaveChangesAsync();

            return newCategory;
        }

        public async Task<IEnumerable<Category>> GetCategories() {
            return await _ctx.Categories.AsNoTracking().ToArrayAsync();
        }

        public async Task<Category> GetCategoryById(int id) {
            Category? foundCategory = await _ctx.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (foundCategory == null)
                throw new ArgumentException("Category with given id does not exist");

            return foundCategory;
        }

        public async Task<Category> GetCategoryByName(string name) {
            Category? foundCategory = await _ctx.Categories.FirstOrDefaultAsync(c => c.Name == name);

            if (foundCategory == null)
                throw new ArgumentException("Category with given name does not exist");

            return foundCategory;
        }
    }
}

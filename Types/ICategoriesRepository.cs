using InventoryApp.Dtos;
using InventoryApp.Models;

namespace InventoryApp.Types {
    public interface ICategoriesRepository {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
        Task<Category> AddCategory(CatrgoryDto category);
    }
}

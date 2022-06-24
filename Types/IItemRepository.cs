using InventoryApp.Dtos;
using InventoryApp.Models;

namespace InventoryApp.Repository {
    public interface IItemRepository {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItemById(int id);
        Task<IEnumerable<Item>> GetItemsByCategoryId(int catId);
        Task<IEnumerable<Item>> GetItemsByCategoryName(string catName);
        Task<Item> AddItem(ItemDto item);
        Task<IEnumerable<Item>> GetItemsByIds(IEnumerable<int> ids);
    }
}

using InventoryApp.Data;
using InventoryApp.Dtos;
using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Repository {
    public class ItemRepository : IItemRepository {
        private readonly AppDbContext _ctx;
        public ItemRepository(AppDbContext ctx) {
            _ctx = ctx;
        }

        public async Task<Item> AddItem(ItemDto item) {
            var newItem = new Item() {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                NumInStock = item.NumInStock,
                CategoryId = item.CategoryId
            };

            await _ctx.Items.AddAsync(newItem);

            await _ctx.SaveChangesAsync();

            return newItem;
        }

        public async Task<Item> GetItemById(int id) {
            Item? foundItem = await _ctx.Items
                .Include(i => i.Category)
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (foundItem == null) throw new ArgumentException("Item with given id does not exist");

            return foundItem;
        }

        public async Task<IEnumerable<Item>> GetItems() {
            return await _ctx.Items.Include(i => i.Category).AsNoTracking().ToArrayAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByCategoryId(int catId) {
            var foundItems = await _ctx.Items
                .Include(i => i.Category)
                .AsNoTracking()
                .Where(i => i.CategoryId == catId)
                .ToArrayAsync();

            if (foundItems == null || foundItems.Length == 0)
                throw new ArgumentException("Item with given category id does not exist");

            return foundItems;
        }

        public async Task<IEnumerable<Item>> GetItemsByCategoryName(string catName) {
            var foundItems = await _ctx.Items
                .Include(i => i.Category)
                .AsNoTracking()
                .Where(i => i.Category.Name == catName)
                .ToArrayAsync();

            if (foundItems == null || foundItems.Length == 0)
                throw new ArgumentException("Item with given category name does not exist");

            return foundItems;
        }

        public async Task<IEnumerable<Item>> GetItemsByIds(IEnumerable<int> ids) {
            //var selected = users.Where(u => new[] { "Admin", "User", "Limited" }.Contains(u.User_Rights));
            var foundItems = await _ctx.Items
                .AsNoTracking()
                .Include(i => i.Category)
                .Where(i => ids.Contains(i.Id))
                .ToArrayAsync();

            if (foundItems == null || foundItems.Length == 0)
                throw new ArgumentException("Item with given category name does not exist");

            return foundItems;

        }
    }
}

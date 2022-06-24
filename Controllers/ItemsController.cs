using InventoryApp.Dtos;
using InventoryApp.Models;
using InventoryApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers {
    public class ItemsController : Controller {
        private readonly IItemRepository _repo;
        public ItemsController(IItemRepository repo) {
            _repo = repo;
        }
        public IActionResult AddItem() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ItemDto item) {
            Item createdItem = await _repo.AddItem(item);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index() {
            IEnumerable<Item> items = await _repo.GetItems();
            return View(items);
        }

        public async Task<IActionResult> GetItemsByCategory([FromQuery] int catId) {
            IEnumerable<Item> items = await _repo.GetItemsByCategoryId(catId);

            return View(items);
        }
    }
}

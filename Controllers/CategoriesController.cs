using InventoryApp.Dtos;
using InventoryApp.Models;
using InventoryApp.Repository;
using InventoryApp.Types;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers {
    public class CategoriesController : Controller {
        private readonly ICategoriesRepository _repo;
        public CategoriesController(ICategoriesRepository repo) {
            _repo = repo;
        }

        public IActionResult AddCategory() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CatrgoryDto item) {
            Category createdItem = await _repo.AddCategory(item);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index() {
            IEnumerable<Category> categories = await _repo.GetCategories();
            return View(categories);
        }
    }
}

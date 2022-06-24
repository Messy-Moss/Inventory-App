using InventoryApp.Models;
using InventoryApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryApp.Controllers {
    public class HomeController : Controller {
        private readonly IItemRepository _repo;

        public HomeController(IItemRepository repo) {
            _repo = repo;
        }

        public async Task<IActionResult> Index() {
            var cookies = Request.Cookies.SingleOrDefault(c => c.Key == "test").Value;

            IEnumerable<int> cookieValueList = new List<int>();

            if (cookies != null) {
                cookieValueList = cookies.Split(',').ToList().Select(c => int.Parse(c));
                var items = await _repo.GetItemsByIds(cookieValueList);
                return View(items);
            }

            return View();
        }

        public IActionResult SetCookieForItem(int itemId) {
            string cookies = Request.Cookies.SingleOrDefault(c => c.Key == "test").Value;

            List<string> cookieValueList = new();

            if (cookies != null) {
                cookieValueList = cookies.Split(',').ToList();
            }

            cookieValueList.Add(itemId.ToString());

            var stringified = string.Join(",", cookieValueList);

            Response.Cookies.Append("test", stringified);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
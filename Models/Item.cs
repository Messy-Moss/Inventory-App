#nullable disable

namespace InventoryApp.Models {
    public class Item {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int NumInStock { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}

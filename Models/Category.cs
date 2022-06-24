namespace InventoryApp.Models {
    public class Category {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Item>? Items { get; set; }
    }
}

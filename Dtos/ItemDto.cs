namespace InventoryApp.Dtos {
    public record ItemDto(string Name, string Description, double Price, int NumInStock, int CategoryId);

}
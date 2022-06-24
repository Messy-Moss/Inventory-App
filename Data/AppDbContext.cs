using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InventoryApp.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {  }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

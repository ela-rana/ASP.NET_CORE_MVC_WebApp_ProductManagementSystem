using Microsoft.EntityFrameworkCore;

namespace ProductManagementSystem.Models
{
    /// <summary>
    /// The Product Database Context that represents the database
    /// </summary>
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        /// <summary>
        /// The Products database set that represents the Product table in our database
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Adds data seeding: dummy records being added to start with during creation of the database
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Avolicious Avocado Saver",
                    Price = 7.99,
                    Image = "1.jpg",
                    Description = "Keep your avocado safe for longer with the Sisno Avocado Saver. Made of Silicone, BPA free, dishwasher safe"
                },
                new Product
                {
                    Id = 2,
                    Name = "Sharkener Knife Sharpener",
                    Price = 15.99,
                    Image = "2.jpg",
                    Description = "Cut like a pro. Chef's favorite Knife Sharpening Pro Tool"
                },
                new Product
                {
                    Id = 3,
                    Name = "CherryMe Cherry Pitter",
                    Price = 11.99,
                    Image = "3.jpg",
                    Description = "Easy tool to pit cherries, easy cleanup rinse under water, dishwasher safe"
                },
                new Product
                {
                    Id = 4,
                    Name = "ChopStir Chop and Stir tool",
                    Price = 7.99,
                    Image = "4.jpg",
                    Description = "The patented ChopStir lets you chop you food while you stir it. Safe for use with non-stick pans"
                }
            );
        }
    }
}

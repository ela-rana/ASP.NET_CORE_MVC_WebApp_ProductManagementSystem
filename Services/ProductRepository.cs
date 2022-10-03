using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    /// <summary>
    /// Consists of actions/functionality that can be performed on Product records, 
    /// including CRUD- create, read, update, delete
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();

            //to add dummy data for our list (which represents the backend database)
            products.Add(new Product() { ID = 1, Name = "Sisno Avocado Saver", Price = 7.99, Image = "1.jpg",
                Description = "Keep your avocado safe for longer with the Sisno Avocado Saver. Made of Silicone, BPA free, dishwasher safe"});
            products.Add(new Product() { ID = 2, Name = "Cuisina Sharkener Knife Sharpener", Price = 15.99, Image = "2.jpg",
                Description = "Cut like a pro. Chef's favorite Knife Sharpening Pro Tool"});
            products.Add(new Product() { ID = 3, Name = "Cuisina Cherry Pitter", Price = 11.99, Image = "3.jpg",
                Description = "Easy tool to pit cherries, easy cleanup rinse under water, dishwasher safe"});
            products.Add(new Product() { ID = 4, Name = "Walter Drake ChopStir", Price = 7.99, Image = "4.jpg",
                Description = "The patented ChopStir lets you chop you food while you stir it. Safe for use with non-stick pans"});
        }

        public void AddRecord(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetRecord(int? ID)
        {
            if (ID == null)
                return null;
            else
                return products.Find(x => x.ID == ID);
        }
        
        public void UpdateRecord(Product product)
        {
            Product prodToUpdate = products.Find(x=>x.ID==product.ID);
            if(prodToUpdate != null)
            {
                prodToUpdate.ID = product.ID;
                prodToUpdate.Name = product.Name;
                prodToUpdate.Price = product.Price;
                prodToUpdate.Image = product.Image;
                prodToUpdate.Description = product.Description;
            }
        }

        public void DeleteRecord(int? ID)
        {
            Product? p = products.Find(x=>x.ID == ID);
            if (p != null)
            {
                products.Remove(p);
            }
        }

        public int MaxID()
        {
            return products.Max(x=>x.ID);
        }
    }
}

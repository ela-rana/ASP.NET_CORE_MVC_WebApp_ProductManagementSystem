using ProductManagementSystem.Models;

namespace ProductManagementSystem.Services
{
    /// <summary>
    /// Consists of actions/functionality that can be performed on Product records, 
    /// including CRUD- create, read, update, delete
    /// </summary>
    public class ProductDBRepository : IProductRepository
    {
        private ProductContext _productContext;

        public ProductDBRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public void AddRecord(Product product)
        {
            _productContext.Add(product);
            _productContext.SaveChanges();
        }

        public List<Product> GetRecords()
        {
            return _productContext.Products.ToList<Product>();
        }

        public Product GetRecord(int? Id)
        {
            return _productContext.Products.Find(Id);
        }
        
        public void UpdateRecord(Product product)
        {
            Product prodToUpdate = _productContext.Products.Find(product.Id);
            if (prodToUpdate != null)
            {
                prodToUpdate.Id = product.Id;
                prodToUpdate.Name = product.Name;
                prodToUpdate.Price = product.Price;
                prodToUpdate.Image = product.Image;
                prodToUpdate.Description = product.Description;
                _productContext.SaveChanges();
            }
        }

        public void DeleteRecord(int? Id)
        {
            Product? p = _productContext.Products.Find(Id);
            if (p != null)
            {
                _productContext.Products.Remove(p);
                _productContext.SaveChanges();
            }
        }

        public int MaxID()
        {
            return _productContext.Products.Max(x=>x.Id);
        }
    }
}

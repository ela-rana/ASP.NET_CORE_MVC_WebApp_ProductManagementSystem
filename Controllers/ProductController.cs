using ProductManagementSystem.Models;
using ProductManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository) //service injection
        {
            this.productRepository = productRepository;
        }

        public IActionResult DisplayAll()
        {
            AllProductsView allProductsView = new AllProductsView();
            allProductsView.Products = productRepository.GetAllProducts();
            return View(allProductsView);
        }
        public IActionResult Details(int? id)
        {
            Product p = productRepository.GetRecord(id);
            if(p == null)
                return NotFound();
            return View(p);
        }

    }
}

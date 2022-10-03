using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository productRepository;
        private IFileUploadService fileUploadService;

        //constructor 
        public AdminController(IProductRepository productRepository, IFileUploadService fileUploadService) //service injection
        {
            this.productRepository = productRepository;
            this.fileUploadService = fileUploadService;
        }

        /// <summary>
        /// to display the main page for Admin Portal
        /// </summary>
        /// <returns>Admin Home view</returns>
        public IActionResult AdminHome()
        {
            AllProductsView allProductsView = new AllProductsView();
            allProductsView.Products = productRepository.GetAllProducts();
            return View(allProductsView);
        }

        /// <summary>
        /// to display the details view for the product with the passed id
        /// </summary>
        /// <param name="id">id of the product for wihich details need to be displayed</param>
        /// <returns>details view for the product with the passed id</returns>
        public IActionResult Details(int? id)
        {
            Product p = productRepository.GetRecord(id);
            if (p == null)
                return NotFound();
            return View(p);
        }
        /// <summary>
        /// To open the Add view where a new product can be added to the inventory
        /// </summary>
        /// <returns>open the Add product form page and passes a ViewBag with the max ID value 
        /// in our inventory to it</returns>
        [HttpGet]
        public IActionResult Add()
        {
            if(productRepository.MaxID()!=null)
                ViewBag.Max = productRepository.MaxID();
            else
                ViewBag.Max = 0;
            return View();
        }

        /// <summary>
        /// To submit a newly created product in the Add view's form so that it gets 
        /// added to the inventory
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add(Product p, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if(await fileUploadService.UploadFile(file))
                {
                    p.Image = fileUploadService.FileName;
                }
                else
                {
                    ViewBag.ErrorMessage = "File upload failed";
                    p.Image = null;
                }
                productRepository.AddRecord(p);
                ViewBag.Message = "Successfully added product: "+ p.Name;
            }
            if (productRepository.MaxID() != null)
                ViewBag.Max = productRepository.MaxID();
            else
                ViewBag.Max = 0;
            return View(p);
        }

        /// <summary>
        /// To open the Edit view where you can edit a product's data
        /// </summary>
        /// <param name="id">id of the product to edit</param>
        /// <returns>Edit page view of passed id product</returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Product p=productRepository.GetRecord(id);
            if (p == null)
                return NotFound();
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        { 
            if(ModelState.IsValid)
            {
                productRepository.UpdateRecord(p);
                return RedirectToAction("AdminHome");
            }
            else
            {
                ViewBag.Message = "Error editing employee";
                return View(p);
            }
        }

        /// <summary>
        /// To delete a product
        /// </summary>
        public IActionResult Delete(int? id)
        {
            productRepository.DeleteRecord(id);
            return RedirectToAction("AdminHome");
        }
    }
}

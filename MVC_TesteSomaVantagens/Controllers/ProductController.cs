using IntermediateModels.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IntermediateModels.DtoS;

namespace IntermediateModels.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet, ActionName("Index")]
        public async Task<IActionResult> GetProducts()
        {
            IEnumerable<ProductDto> products = null;
            try
            {
                products = await _productService.GetProducts();
                
            }
            catch(Exception ex)
            {
                return View("Error", ex.Message);
            }
            return View(products);
        }

        [HttpGet, ActionName("Details")]
        public IActionResult GetProductById(int id)
        {
            ProductDto product = null;
            try
            {
                product = _productService.GetProductById(id);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
            return View(product);
        }

        [HttpGet, ActionName("Create")]
        public  async Task<IActionResult> GetCategoryForCreateProduct()
        {
            var categories =  await _categoryService.GetCategory();
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryId");
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult PostProduct([Bind("ProductId,Name,Points,CategoryId")] ProductDto product)
        {
            try
            {
                _productService.PostProduct(product);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet, ActionName("Edit")]
        public async Task<IActionResult> GetCategoryForEditProduct(int? id)
        {
            if (id is null) return NotFound();

            var existsProductsInDataBase = _productService.GetProducts();
            if (existsProductsInDataBase is null) return NotFound();

            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = await  _categoryService.GetCategory();
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryId", product.CategoryId);
            return View(product);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult PutProduct(int id, [Bind("ProductId,Name,Points,CategoryId")] ProductDto product)
        {
            try
            {
                _productService.PutProduct(id, product);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpGet, ActionName("Delete")]
        public IActionResult GetProductForDeleteProduct(int? id)
        {
            if (id is null) return NotFound();

            var existsProductsInDataBase = _productService.GetProducts();
            if (existsProductsInDataBase is null) return NotFound();

            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}

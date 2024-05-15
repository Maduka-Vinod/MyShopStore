using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyShopStore.Data;
using MyShopStore.Models;
using System.Drawing.Drawing2D;

namespace MyShopStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var    products = context.Products.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
           return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            Product Product = new Product()
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
                CreatedAt = DateTime.Now,

            };
            context.Products.Add(Product);
            context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }

            var Product = new Product()
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,

            };
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id,Product product)
        {
            var Product = context.Products.Find(id);
            if (Product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            if(!ModelState.IsValid)
            {
                return View(product);
            }

            Product.Name = product.Name;
            Product.Brand = product.Brand;
            Product.Category = product.Category;
            Product.Price = product.Price;
            //product.Description = product.Description;
            Product.Description = product.Description;

            context.SaveChanges();
            return RedirectToAction("Index", "Product");
            
        }

        
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");    
        }

           
    }
        

}

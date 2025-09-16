using Khalid_ASPMVC.Data;
using Khalid_ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Khalid_ASPMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult IndexProduct()

        {
            IEnumerable<Product> products = _context.Products.ToList();
            if (products.Any())
            {
                TempData["Success"] = "Data displayed Successfully";
            }
            else
            {
                TempData["Error"] = "Data Not Found !!";
            }

            return View(products);



        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
          
            

                if (ModelState.IsValid)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    TempData["Create"] = "Data Created Successfully";
                    return RedirectToAction("IndexProduct");

                }
                else
                {
                    return View(product);
                }
            }
           

            



            [HttpGet]
            public IActionResult Edit(int Id)
            {
                var cate = _context.Products.Find(Id);
                return View(cate);
            }

            [HttpPost]
            public IActionResult Edit(Product product)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                TempData["Edit"] = "Data Edited Successfully";
                return RedirectToAction("IndexProduct");

            }

            [HttpGet]
            public IActionResult Delete(int Id)
            {
                var cate = _context.Products.Find(Id);
                return View(cate);
            }
            [HttpPost]
            public IActionResult Delete(Product product)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                TempData["Delete"] = "Data Deleted Successfully";
                return RedirectToAction("IndexProduct");

            }
        }
    }



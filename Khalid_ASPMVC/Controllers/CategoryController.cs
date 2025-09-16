using Khalid_ASPMVC.Data;
using Khalid_ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Khalid_ASPMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
        public IActionResult Index()
        {
            IEnumerable<Category> category = _context.Categories.ToList();
            if (category.Any())
            {
                TempData["Success"]= "Data displayed Successfully";
            }
            else
            {
                TempData["Error"]= "Data Not Found !!";
            }

            return View(category);
        }



        [HttpGet]
        public IActionResult Create() {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                //if (category.Name == "100")
                //{
                //    ModelState.AddModelError("CustomError","Name can not be Equal 100");
                //}
                if (ModelState.IsValid)
                {
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                    TempData["Create"] = "Data Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(category);
                }

            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", "An error occurred while adding" + ex.Message);
                return View(category);



            }
           
            
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cate = _context.Categories.Find(Id);
            return View(cate);
        }
       
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["Edit"] = "Data Edited Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var cate = _context.Categories.Find(Id);
            return View(cate);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["Delete"] = "Data Deleted Successfully";
            return RedirectToAction("Index");
        }
    }

}
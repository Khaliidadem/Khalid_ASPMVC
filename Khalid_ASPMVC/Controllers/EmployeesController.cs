using Khalid_ASPMVC.Data;
using Khalid_ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Khalid_ASPMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult IndexEmployees()
        {
            IEnumerable<Employees>  employees = _context.Employees.ToList();
            if (employees.Any())
            {
                TempData["Success"] = "Data displayed Successfully";

            }
            else
            {
                TempData["Error"] = "Data Not Found !!";
            }
            return View(employees);
            

           

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost ]
        public IActionResult Create(Employees employees)
        {
            if (ModelState.IsValid)
            {

                _context.Employees.Add(employees);
                _context.SaveChanges();
                TempData["Create"] = "Data Created Successfully";
                return RedirectToAction("IndexEmployees");

            }
            else
            {
                return View(employees);
            }
                
        }

        [HttpGet]
        public IActionResult Edit(int Id)
       
        {
            var cate = _context.Employees.Find(Id);
            return View(cate);
        }
        [HttpPost]
        public IActionResult Edit(Employees employees)
        {
            _context.Employees.Update(employees);
            _context.SaveChanges();
            TempData["Edit"] = "Data Edited Successfully";
            return RedirectToAction("IndexEmployees");
        }

        [HttpGet]
        public IActionResult Delete(int Id) 
        {
            var cate =_context.Employees.Find(Id);
            return View(cate);
        }
        [HttpPost]
        public IActionResult Delete(Employees employees)
        {
            _context.Employees.Remove(employees);
            _context.SaveChanges();
            TempData["Delete"] = "Data Deleted Successfully";
            return RedirectToAction("IndexEmployees");
        }
    }
}

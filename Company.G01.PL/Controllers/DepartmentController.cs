using Company.G01.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Company.G01.BLL.Repositories;
using Company.G01.DAL.Models;


namespace Company.G01.PL.Controllers
{
    public class DepartmentController : Controller
    {
        protected readonly IDepartmentRepository _departmentRepo;
        public DepartmentController(IDepartmentRepository departmentRepo) // Ask CLR to inject this and create a new instance
        {
            _departmentRepo = departmentRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepo.GetAll();
            return View(departments);
        }
     
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentRepo model)
        {
            if (ModelState.IsValid)
            {
                var count = _departmentRepo.Add(model);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            
          return View(model);
        }

        public IActionResult Details(int? id)
        {
            if(id is null) return BadRequest(); //400

            var department = _departmentRepo.Get(id.Value);

            return View(department);
        }
        
    }
}

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
        [ValidateAntiForgeryToken]
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

            if(department is null) return NotFound(); //404

            return View(department);
        } 
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id is null) return BadRequest(); //400

            var department = _departmentRepo.Get(id.Value);

            if (department is null) return NotFound(); //404

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id,DepartmentRepo model)
        {
            if(id != model.Id) return BadRequest(); //400

            if (ModelState.IsValid)
            {
                var count = _departmentRepo.Update(model);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            
          return View(model);
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id is null) return BadRequest(); //400

            var department = _departmentRepo.Get(id.Value);

            if(department is null) return NotFound(); //404

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? id, DepartmentRepo model)
        {
            if(id != model.Id) return BadRequest(); //400

            var count = _departmentRepo.Delete(model);
            if (count > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}

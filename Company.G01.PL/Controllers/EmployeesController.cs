using Company.G01.BLL.Interfaces;
using Company.G01.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.G01.PL.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeesController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public ActionResult Index()  // GET all employees
        {
            var employees = _employeeRepo.GetAll();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()  // GET create employee
        {
            var model = new Employee();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee model)  // POST create employee
        {
            if (ModelState.IsValid)
            {
                var count = _employeeRepo.Add(model);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int? id, string viewName = "Details")  // GET employee details
        {
            if (id == null)
            {
                return BadRequest();
            }
            var employee = _employeeRepo.Get(id.Value);
            if (employee == null)
            {
                return NotFound(); // 404
            }
            return View(viewName,employee);
        }


        [HttpGet]
        public ActionResult Edit(int? id, string viewName = "Edit")  // GET edit employee
        {
            if (id == null)
            {
                return BadRequest();
            }
            var employee = _employeeRepo.Get(id.Value);
            if (employee == null)
            {
                return NotFound(); // 404
            }
            return View(viewName,employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute] int? id,Employee model)  // POST edit employee
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var count = _employeeRepo.Update(model);
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
              ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest(); //400

            var department = _employeeRepo.Get(id.Value);

            if (department is null) return NotFound(); //404

            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromRoute] int? id, Employee model)  // POST delete employee
        {
            try
            {
                if (id != model.Id) return BadRequest(); // 400
                if (ModelState.IsValid)
                {
                    var count = _employeeRepo.Delete(model);
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }
    }
}



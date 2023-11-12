using Core_codeFirst_practice.DAL;
using Core_codeFirst_practice.Models;
using Core_codeFirst_practice.Models.DBEntites;
using Microsoft.AspNetCore.Mvc;

namespace Core_codeFirst_practice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        //get all data from database
        [HttpGet] //if we do not use it, it will get httpget by default
        public IActionResult Index()
        {
            var emp = _context.Employees.ToList();
            List<EmployeeViewModel> listViewModel = new List<EmployeeViewModel>();
            if (emp != null)
            {
                foreach (var employees in emp)
                {
                    var empViewModel = new EmployeeViewModel()
                    {
                        id = employees.id,
                        FirstName = employees.FirstName,
                        LastName = employees.LastName,
                        DateofBirth = employees.DateofBirth,
                        Email = employees.Email,
                        Salary = employees.Salary,
                    };
                    listViewModel.Add(empViewModel);
                }
                return View(listViewModel);
            }
            return View(listViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //data save here
        [HttpPost]
        public IActionResult Create(EmployeeViewModel empViewData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var empModelData = new Employee()
                    {
                        FirstName = empViewData.FirstName,
                        LastName = empViewData.LastName,
                        DateofBirth = empViewData.DateofBirth,
                        Email = empViewData.Email,
                        Salary = empViewData.Salary,
                    };
                    _context.Add(empModelData);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Data saved successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Data not saved!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet] 
        public IActionResult Edit(int Id) { //get dat from index page by id and bing in edit page with this method
            try
            {
                var empModel = _context.Employees.SingleOrDefault(x => x.id == Id); //here singleOrDefault is used for primary keys value
                if (empModel != null)
                {
                    var empViewModel = new EmployeeViewModel
                    {
                        id = empModel.id,
                        FirstName = empModel.FirstName,
                        LastName = empModel.LastName,
                        DateofBirth = empModel.DateofBirth,
                        Email = empModel.Email,
                        Salary = empModel.Salary,
                    };
                    return View(empViewModel);
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not avilabe with the id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        //Edit data here
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model) {
            try
            {
                if (ModelState.IsValid)
                {
                    var empModelData = new Employee()
                    {
                        id = model.id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateofBirth = model.DateofBirth,
                        Email = model.Email,
                        Salary = model.Salary,
                    };
                    _context.Employees.Update(empModelData);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee data updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is invalid!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        { //get dat from db by id and bind to delete page
            try
            {
                var empModel = _context.Employees.SingleOrDefault(x => x.id == Id); //here singleOrDefault is used for primary keys value
                if (empModel != null)
                {
                    var empViewModel = new EmployeeViewModel
                    {
                        id = empModel.id,
                        FirstName = empModel.FirstName,
                        LastName = empModel.LastName,
                        DateofBirth = empModel.DateofBirth,
                        Email = empModel.Email,
                        Salary = empModel.Salary,
                    };
                    return View(empViewModel);
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not avilabe with the id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        //data delete here
        [HttpPost]
        public IActionResult Delete(EmployeeViewModel model)
        {
            try
            {
                var emp = _context.Employees.SingleOrDefault(x => x.id == model.id);
                if (emp != null)
                {
                    _context.Employees.Remove(emp);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee data deleted successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not avilabe with the id: {model.id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}

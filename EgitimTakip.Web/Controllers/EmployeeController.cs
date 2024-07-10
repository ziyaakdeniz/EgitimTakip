using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll(int companyId)

        {
            var result=_context.Employees.Where(x=>x.CompanyId==companyId&&x.IsDeleted==false).ToList();
            return Json(new {data=result});
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _context.Employees.Find(id);
            result.IsDeleted = true;
            _context.Employees.Update(result);
            _context.SaveChanges();
            return Ok(result);
        }
        [HttpPost]
        public  IActionResult Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges() ; 
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges() ;
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            Employee employee = _context.Employees.Find(id) ;
            _context.Employees.Remove(employee);
            _context.SaveChanges() ;
            return Ok();
        }
    }
}

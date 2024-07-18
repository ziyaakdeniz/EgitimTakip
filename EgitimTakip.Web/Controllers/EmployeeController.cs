using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Abstract;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll(int companyId)

        {
            //var result=_context.Employees.Where(x=>x.CompanyId==companyId&&x.IsDeleted==false).ToList();
            //return Json(new {data=result});
            return Json(new {data=_repo.GetAll(companyId)});

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
           _repo.Delete(id);
            return Ok();
        }
        [HttpPost]
        public  IActionResult Add(Employee employee)
        {
            return Ok(_repo.Add(employee));
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
           return Ok(_repo.Update(employee));
        }
        //[HttpPost]
        //public IActionResult HardDelete(int id)
        //{
        //    Employee employee = _context.Employees.Find(id) ;
        //    _context.Employees.Remove(employee);
        //    _context.SaveChanges() ;
        //    return Ok();
        //}
        [HttpPost]
        public IActionResult GetById(int id)
        {
           return Ok(_repo.GetById(id));
        }
    }
}

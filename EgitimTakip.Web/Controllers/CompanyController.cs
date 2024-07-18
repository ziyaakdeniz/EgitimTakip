using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var result=_context.Companies.Where(x=>x.IsDeleted==false).ToList();
            return Json(new {data=result});
        }
        [HttpPost]
        public IActionResult Add(Company  company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return Ok(company);
        }
        [HttpPost]
        public IActionResult Update(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
            return Ok(company);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Company company = _context.Companies.Find(id);
            company.IsDeleted = true;
            _context.Companies.Update(company);
            _context.SaveChanges();
            return Ok(company);
        }
        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            Company company = _context.Companies.Find(id);
            _context.Companies.Remove(company);
            _context.SaveChanges();
            return Ok(company);
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Companies.Find(id));
        }
    }
}

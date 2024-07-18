using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class CompanyController : Controller
    {
      private readonly IRepository<Company> _repo;

        public CompanyController(IRepository<Company> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            //var result=_context.Companies.Where(x=>x.IsDeleted==false).ToList();
            //return Json(new {data=result});

            return Json(new {data= _repo.GetAll()});    
        }
        [HttpPost]
        public IActionResult Add(Company  company)
        {
            //_context.Companies.Add(company);
            //_context.SaveChanges();
            //return Ok(company);

           return Ok(_repo.Add(company));

        }
        [HttpPost]
        public IActionResult Update(Company company)
        {
            //_context.Companies.Update(company);
            //_context.SaveChanges();
            //return Ok(company);

            return Ok(_repo.Update(company));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //Company company = _context.Companies.Find(id);
            //company.IsDeleted = true;
            //_context.Companies.Update(company);
            //_context.SaveChanges();
            //return Ok(company);
            _repo.Delete(id);
            return Ok();

          // return Ok(_repo.Delete(id) is object);

        }
        //[HttpPost]
        //public IActionResult HardDelete(int id)
        //{
        //    Company company = _context.Companies.Find(id);
        //    _context.Companies.Remove(company);
        //    _context.SaveChanges();
        //    return Ok(company);
        //}
        [HttpPost]
        public IActionResult GetById(int id)
        {
           return Ok(_repo.GetById(id));
        }
    }
}

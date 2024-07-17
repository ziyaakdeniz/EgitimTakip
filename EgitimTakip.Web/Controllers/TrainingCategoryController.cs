using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var result=_context.TrainingCategories.Where(x=>x.IsDeleted==false).ToList();
            return Json(new {data=result}); 
        }
        [HttpPost]
        public IActionResult Add(TrainingCategory  trainingCategory)
        {
            _context.TrainingCategories.Add(trainingCategory);
            _context.SaveChanges();
            return Ok(trainingCategory);
        }
        [HttpPost]
        public IActionResult Update(TrainingCategory trainingCategory)
        {
            _context.TrainingCategories.Update(trainingCategory);
            _context.SaveChanges();
            return Ok(trainingCategory);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _context.TrainingCategories.Find(id);
            result.IsDeleted = true;
            _context.TrainingCategories.Update(result);
            _context.SaveChanges();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_context.TrainingCategories.Find(id));
        }

    }
}

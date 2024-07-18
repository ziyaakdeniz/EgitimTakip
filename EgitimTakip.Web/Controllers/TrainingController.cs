using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll(int companyId)
        {
            var result=_context.Trainings.Where(x=>x.IsDeleted==false&& x.CompanyId==companyId).ToList();
            return Json(new {data=result}); 
        }
        [HttpPost]
        public IActionResult Add(Training training,List<TrainingsSubjectsMap> trainingsSubjectsMaps) 
        {
            _context.Trainings.Add(training);
            _context.SaveChanges();
            foreach (var item in trainingsSubjectsMaps)
            {
                _context.TrainingsSubjectsMaps.Add(item);
            }
        
            return Ok(training);
        }
        [HttpPost]
        public IActionResult Update(Training training)
        {
            _context.Trainings.Update(training);
            _context.SaveChanges();
            return Ok(training);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Training training = _context.Trainings.Find(id);
            training.IsDeleted= true;
            _context.Trainings.Update(training);
            _context.SaveChanges();
            return Ok(training);
        }
        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            Training training = _context.Trainings.Find(id);
            _context.Trainings.Remove(training);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Trainings.Find(id));
        }
    }
}

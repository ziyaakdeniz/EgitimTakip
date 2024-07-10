using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingSubjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingSubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var result = _context.GetTrainingSubjects.Where(x=>x.IsDeleted==false).ToList();
            return Json(new {data= result});    
        }
        [HttpPost]
        public IActionResult Add(TrainingSubject trainingSubject)
        {
            _context.GetTrainingSubjects.Add(trainingSubject);
            _context.SaveChanges();
            return Ok(trainingSubject);
        }
        [HttpPost]
        public IActionResult Update(TrainingSubject trainingSubject)
        {
            _context.UpdateRange(trainingSubject);
            _context.SaveChanges();
            return Ok(trainingSubject);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result=_context.GetTrainingSubjects.Find(id);
            result.IsDeleted= true; 
            _context.GetTrainingSubjects.Update(result);
            return Ok(result);
        }
        
    }
}

using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Abstract;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingRepository _repo;

        public TrainingController(ITrainingRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAll(int companyId)
        {
           return Json(new { data=_repo.GetAll(companyId) });
        }
        [HttpPost]
        public IActionResult Add(Training training,List<TrainingsSubjectsMap> trainingsSubjectsMaps) 
        {
            //_context.Trainings.Add(training);
            //_context.SaveChanges();
            //foreach (var item in trainingsSubjectsMaps)
            //{
            //    item.TrainingId=training.Id;
            //    _context.TrainingsSubjectsMaps.Add(item);
            //}

            //return Ok(training);

            

            return Ok(_repo.Add(training, trainingsSubjectsMaps));

        }
        [HttpPost]
        public IActionResult Update(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            training.TrainingsSubjectsMap=new List<TrainingsSubjectsMap>();
            _repo.Update(training);

            training.TrainingsSubjectsMap = trainingsSubjectsMaps;
            _repo.Update(training);
            return Ok(training);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            return Ok(_repo.Delete(id) is object);
        }
      
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_repo.GetById(id));
        }

    }
}

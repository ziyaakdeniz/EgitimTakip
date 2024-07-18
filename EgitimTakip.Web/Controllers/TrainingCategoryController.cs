using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class TrainingCategoryController : Controller
    {
        private readonly IRepository<TrainingCategory> _repo;

        public TrainingCategoryController(IRepository<TrainingCategory> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Ok(new {data=_repo.GetAll()});
        }
        [HttpPost]
        public IActionResult Add(TrainingCategory  trainingCategory)
        {
           return Ok(_repo.Add(trainingCategory));
        }
        [HttpPost]
        public IActionResult Update(TrainingCategory trainingCategory)
        {
            return Ok(_repo.Update(trainingCategory));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
           _repo.Delete(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_repo.GetById(id));
        }

    }
}

using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Abstract;
using EgitimTakip.Repository.Shared.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Conctere
{
    public class TrainingRepository : Repository<Training>, ITrainingRepository
    {
      

        public TrainingRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        public Training Add(Training training, List<TrainingsSubjectsMap> trainingsSubjectsMaps)
        {
            base.Add(training);

            foreach(var subject in trainingsSubjectsMaps)
            {
                subject.TrainingId=training.Id;

                
            }
            training.TrainingsSubjectsMap = trainingsSubjectsMaps;
            base.Update(training);
           
            return training;
        }

        public override Training GetById(int triningId)
        {
            return base.GetAll(t=>t.Id == triningId).Include(t=>t.Employees).First();
        }

        public void UpdateAttendees(int trainingId, List<Employee> employees)
        {
           Training training=GetById(trainingId);
            training.Employees=employees;
            base.Update(training);
        }

        public ICollection<Training> GetAll(int companyId)
        {
           return base.GetAll(x => x.CompanyId == companyId).ToList();
        }

        public void RemoveEmployee(int trainingId, Employee  employee )
        {
            Training training = GetById(trainingId);
            training.Employees.Remove(employee);
            base.Update(training);
        }
    }
}

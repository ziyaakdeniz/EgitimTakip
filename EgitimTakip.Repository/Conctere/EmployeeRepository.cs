﻿using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Abstract;
using EgitimTakip.Repository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Conctere
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
      //private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context):base (context) 
        {
            //_context = context;
        }

        public ICollection<Employee> GetAll(int companyId)
        {
            //return _context.Employees.Where(e=>!e.IsDeleted&&e.CompanyId==companyId).ToList(); 

            return base.GetAll(emp=>emp.CompanyId==companyId).ToList();
        }
    }
}

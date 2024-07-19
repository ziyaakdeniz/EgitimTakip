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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        

        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        public ICollection<Company> GetAll(int userId)
        {
            return base.GetAll(c=>c.Users.Any(u=>u.Id==userId)).Include(c=>c.Users).ToList();
        }
    }
}

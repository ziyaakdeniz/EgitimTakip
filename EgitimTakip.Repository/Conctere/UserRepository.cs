using EgitimTakip.Data;
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
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public AppUser CheckUser(string username, string password)
        {
           return base.GetFirstOrDefault(u=>u.UserName == username && u.Password == password && !u.IsDeleted);
        }
    }
}

using EgitimTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T,bool>>predicate);

        T Add(T entity);

       List<T> AddRange(List<T> entities);

        T Update(T entity);

        void Delete(int id);

        T GetById(int id);

        void Save();

        T GetFirstOrDefault(Expression<Func<T,bool>>predicate);
    }
}

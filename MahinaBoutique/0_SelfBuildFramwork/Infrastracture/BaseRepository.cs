using _0_SelfBuildFramwork.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _0_SelfBuildFramwork.Infrastracture
{
    public class BaseRepository<Tkey, T> : IRepository<Tkey, T> where T : EntityBase
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetBy(Tkey id)
        {
            return _dbContext.Find<T>(id);
        }

        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Any(expression);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

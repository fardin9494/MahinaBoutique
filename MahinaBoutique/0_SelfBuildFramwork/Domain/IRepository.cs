using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_SelfBuildFramwork.Domain
{
    public interface IRepository<Tkey,T> where T : EntityBase
    {
        T GetBy(Tkey id);

        bool IsExist(Expression<Func<T,bool>> expression);

        List<T> GetAll();

        void Create(T entity);

        void SaveChanges();
    }
}

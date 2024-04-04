using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base_Framework.Domain.Core.Contracts
{
    public interface IRepository<TKey, T> where T : class
    {
        public bool IsExist(Expression<Func<T, bool>> expression);
        public void Save();
    }
}

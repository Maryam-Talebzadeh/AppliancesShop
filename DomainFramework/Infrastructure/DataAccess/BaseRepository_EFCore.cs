using Base_Framework.Domain.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base_Framework.Infrastructure.DataAccess
{
    public class BaseRepository_EFCore<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepository_EFCore(DbContext context)
        {
            _context = context; 
        }

        public bool IsExist(Expression<Func<T, bool>> expression)
        {
           return _context.Set<T>().Any(expression);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

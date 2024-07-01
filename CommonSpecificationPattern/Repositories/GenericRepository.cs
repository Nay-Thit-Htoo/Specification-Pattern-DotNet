using CommonSpecificationPattern;
using Microsoft.EntityFrameworkCore;
using Specification.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet=context.Set<T>();    
        }
        
        public IEnumerable<T> Find(ISpecification<T> specification)
        {
            var expression = specification.ToExpression();
            return _dbSet.Where(expression);
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfectHotel.Web.Data;
using PerfectHotel.Web.Models;

namespace PerfectHotel.Web.Repositories
{
    public class GenericAsyncRepository<T>: IGenericAsyncRepository<T> where T: BaseEntity 
    {
        private readonly ApplicationDbContext _context;

        public GenericAsyncRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();            
        }

        public async Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();            
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

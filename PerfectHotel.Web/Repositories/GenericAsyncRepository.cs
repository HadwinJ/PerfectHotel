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

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();            
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            T exist = _context.Set<T>().Find(entity.Id);
            if (null != exist)
            {
                entity.CreatedBy = exist.CreatedBy;
                entity.CreatedAt = exist.CreatedAt;

                _context.Entry(exist).State = EntityState.Detached;
            }            
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfectHotel.Web.Data;
using PerfectHotel.Web.Models;

namespace PerfectHotel.Web.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }        

        public async Task<IEnumerable<Student>> FindAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);            
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);           
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            // _context.Entry(student).State = EntityState.Modified;            
        }

        public async Task<Student> FindByIdAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        
    }
}

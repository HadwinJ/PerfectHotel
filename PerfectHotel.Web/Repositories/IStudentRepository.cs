using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectHotel.Web.Models;

namespace PerfectHotel.Web.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> FindAllAsync();
        void Create(Student student);
        void Delete(Student student);
        void Update(Student student);
        Task<Student> FindByIdAsync(int id);
        Task SaveChangesAsync();
    }
}

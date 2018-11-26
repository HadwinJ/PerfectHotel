using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectHotel.Web.Data;
using PerfectHotel.Web.Models;

namespace PerfectHotel.TestWeb.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Students.AddRange(GetSeedingStudents());
            db.SaveChanges();
            throw new NotImplementedException();
        }

        private static List<Student> GetSeedingStudents()
        {
            return new List<Student>()
            {
                new Student(){FirstName = "SeedFirst1", LastName = "SeedLast1"},
                new Student(){FirstName = "SeedFirst2", LastName = "SeedLast2"},
                new Student(){FirstName = "SeedFirst3", LastName = "SeedLast3"},
            };
        }
    }
}

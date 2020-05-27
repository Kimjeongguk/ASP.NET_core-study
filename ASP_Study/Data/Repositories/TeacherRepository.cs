using ASP_Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Study.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ASPStudyContext _context;

        public TeacherRepository(ASPStudyContext context)
        {
            _context = context;
        }
        public IEnumerable<Teacher> GetAllTeachers()
        {
            var result = _context.Teachers.ToList();

            return result;
        }

        public Teacher GetTeacher(int id)
        {
            var result = _context.Teachers.Find(id);

            return result;
        }
    }
}

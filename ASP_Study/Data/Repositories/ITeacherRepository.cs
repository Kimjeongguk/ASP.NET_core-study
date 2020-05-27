using ASP_Study.Models;
using System.Collections.Generic;

namespace ASP_Study.Data.Repositories
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacher(int id);
    }
}
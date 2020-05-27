using ASP_Study.Models;
using System.Collections.Generic;

namespace ASP_Study.Data.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        void Save();
        void Edit(Student student);
        void Delete(Student student);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Study.Data.Repositories;
using ASP_Study.Models;
using ASP_Study.viewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Study.Controllers
{
    public class StudentController : Controller
    {
        private readonly ITeacherRepository _Trepository;
        private readonly IStudentRepository _Srepository;

        public StudentController(ITeacherRepository Trepository, IStudentRepository Srepository)
        {
            _Trepository = Trepository;
            _Srepository = Srepository;
        }
        // GET: /<controller>/
        [Authorize]
        public IActionResult Student()
        {
            var students = _Srepository.GetAllStudents();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };
            return View(viewModel);
        }
        [HttpPost]//html에서 넘어오는 값들을 받음
        [ValidateAntiForgeryToken]//요청위조방지 유저가보낸게맞는지 확인함
        public IActionResult Student(StudentTeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model 대이터를 student table에 저장
                _Srepository.AddStudent(model.Student);
                _Srepository.Save();

                ModelState.Clear();
            }
            else
            {

            }

            var students = _Srepository.GetAllStudents();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };
          
            return View(viewModel);
        }
        public IActionResult Detail(int id)
        {
            var restult = _Srepository.GetStudent(id);
            return View(restult);
        }
        public IActionResult Edit(int id)
        {
            var restult = _Srepository.GetStudent(id);
            return View(restult);
        }
        [HttpPost]//html에서 넘어오는 값들을 받음
        [ValidateAntiForgeryToken]//요청위조방지 유저가보낸게맞는지 확인함
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _Srepository.Edit(student);
                _Srepository.Save();
                return RedirectToAction("Student");
            }
           
           return View(student);
        }
        public IActionResult Delete(int id)
        {
            var result = _Srepository.GetStudent(id);
            if(result != null)
            {
                _Srepository.Delete(result);
                _Srepository.Save();
            }

            return RedirectToAction("Student");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_Study.Models;
using ASP_Study.viewModels;
using ASP_Study.Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ASP_Study.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherRepository _repository;
        private readonly ILogger<HomeController> _logger;
       

        public HomeController(ILogger<HomeController> logger, ITeacherRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [Authorize]
        public IActionResult Index()
        {
            var teachers = _repository.GetAllTeachers();
            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };
            return View(viewModel);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

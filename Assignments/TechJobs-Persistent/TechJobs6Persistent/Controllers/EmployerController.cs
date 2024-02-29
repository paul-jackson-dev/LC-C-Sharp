using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext _jobDbContext;

        public EmployerController(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Employer> employers = _jobDbContext.Employers.ToList();

            return View("Index", employers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEmployerViewModel viewModel = new AddEmployerViewModel();
            return View("Create", viewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer()
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                _jobDbContext.Employers.Add(newEmployer);
                _jobDbContext.SaveChanges();

                return Redirect("/");
            }

            return View("Create", addEmployerViewModel);
        }

        [HttpGet]
        public IActionResult About(int id)
        {
            Employer? employer = _jobDbContext.Employers.Find(id);
            if (employer != null)
            {
                return View("About", employer);
            }
            return Redirect("/");
        }

    }
}


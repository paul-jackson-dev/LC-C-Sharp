﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class JobController : Controller
    {
        private JobDbContext context;

        public JobController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Employer> employers = context.Employers.ToList();
            AddJobViewModel viewModel = new AddJobViewModel(employers);

            return View("Add", viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddJobViewModel addJobViewModel)
        {
            //if (addJobViewModel.Name != null && addJobViewModel.EmployerId >= 0)
            if (ModelState.IsValid)
            {
                Job newJob = new Job()
                {
                    Name = addJobViewModel.Name,
                    Employer = context.Employers.Find(addJobViewModel.EmployerId),
                    EmployerId = addJobViewModel.EmployerId
                };
                context.Add(newJob);
                context.SaveChanges();
                return Redirect("/");
            }


            List<Employer> employers = context.Employers.ToList(); // recreate the Employer Select List, couldn't get it to bind using a hidden input
            AddJobViewModel viewModel = new AddJobViewModel(employers);
            addJobViewModel.Employers = viewModel.Employers;

            return View("Add", addJobViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.jobs = context.Jobs.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] jobIds)
        {
            foreach (int jobId in jobIds)
            {
                Job theJob = context.Jobs.Find(jobId);
                context.Jobs.Remove(theJob);
            }

            context.SaveChanges();

            return Redirect("/Job");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs.Include(j => j.Employer).Include(j => j.Skills).Single(j => j.Id == id);

            JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);

            return View(jobDetailViewModel);

        }
    }
}


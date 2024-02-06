using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay6.Models;
using SpaDay6.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaDay6.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {

            AddUserViewModel viewModel = new AddUserViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("/user")]
        public IActionResult SubmitAddUserForm(AddUserViewModel addUserViewModel)
        {

            if (ModelState.IsValid)
            {
                if (addUserViewModel.Password.Equals(addUserViewModel.Verify))
                {

                    User newUser = new User
                    {
                        Username = addUserViewModel.Username,
                        Email = addUserViewModel.Email,
                        Password = addUserViewModel.Password
                    };
                    return View("Index", newUser);
                }
                ViewBag.error = "error: passwords don't match";
            }
            return View("Add", addUserViewModel);
            //if (newUser.Password == verify)
            //{
            //    ViewBag.user = newUser;
            //    return View("Index");
            //}
            //else
            //{
            //    ViewBag.error = "Passwords do not match! Try again!";
            //    ViewBag.userName = newUser.Username;
            //    ViewBag.eMail = newUser.Email;
            //    return View("Add");
            //}
        }
    }
}


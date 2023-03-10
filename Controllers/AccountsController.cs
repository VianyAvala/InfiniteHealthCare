using InfiniteHealthCare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace InfiniteHealthCare.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IConfiguration _configuration;
        public AccountsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new System.Uri(_configuration["ApiUrl:api"]);
                    var result = await client.PostAsJsonAsync("Accounts/Login", login);
                    if (result.IsSuccessStatusCode)
                    {
                        string token = await result.Content.ReadAsAsync<string>();
                        HttpContext.Session.SetString("token", token);

                        string userName = login.Username;
                        HttpContext.Session.SetString("Patient", userName);

                        // TempData["UserName"] = login.Username;

                        return RedirectToAction("Index", "Doctors");
                    }
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            }
            return View(login);
        }



        [HttpGet]
        public IActionResult SignUp()
        {
            RolesSignUpViewModel model = new RolesSignUpViewModel
            {
                Values = new List<SelectListItem>
                         {
                             new SelectListItem { Value = "patient", Text = "patient" },
                             new SelectListItem { Value = "Doctor", Text = "Doctor" }
                         }


            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm] RolesSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();

                    client.BaseAddress = new Uri(_configuration["ApiUrl:api"]);


                    SignUpViewModel user = new SignUpViewModel
                    {
                        UserName = model.SignUpRoles.UserName,
                        FullName = model.SignUpRoles.FullName,
                        Password = model.SignUpRoles.Password,
                        ConfirmPassword = model.SignUpRoles.ConfirmPassword,
                        Email = model.SignUpRoles.Email,
                        PhoneNumber = model.SignUpRoles.PhoneNumber,
                        Role = model.SelectedValue


                    };

                    var result = await client.PostAsJsonAsync("Accounts/Register", user);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login");
                    }

                }
            }
            SignUpViewModel user1 = new SignUpViewModel
            {
                UserName = model.SignUpRoles.UserName,
                FullName = model.SignUpRoles.FullName,
                Password = model.SignUpRoles.Password,
                Email = model.SignUpRoles.Email,
                PhoneNumber = model.SignUpRoles.PhoneNumber,
                Role = model.SelectedValue


            };
            RolesSignUpViewModel model1 = new RolesSignUpViewModel
            {
                SignUpRoles = user1,
                Values = new List<SelectListItem>
                         {
                             new SelectListItem { Value = "patient", Text = "patient" },
                             new SelectListItem { Value = "Doctor", Text = "Doctor" }
                         }


            };
            return View(model1);
        }


        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("token");
            return RedirectToAction("Index", "Home");
        }



    }

}

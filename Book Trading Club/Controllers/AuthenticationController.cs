using BookTradingClub.Models;
using BookTradingClub.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Book_Trading_Club.Controllers
{
    public class AuthenticationController : Controller
    {

        protected readonly UserManager<User> _UserManager;
        protected readonly SignInManager<User> _SignInManager;

        public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _UserManager = userManager;
            _SignInManager = signInManager; 
        }

        //[Route("signout"), HttpGet]
        public async Task<IActionResult> Signout()
        {
            await _SignInManager.SignOutAsync();
            return Redirect("/");
        }


        [Route("signin"), HttpGet]
        public IActionResult signin()
        {
            ViewBag.Title = "Sign In";
            return View("SignIn");
        }

        [HttpPost, Route("signin")]
        public async Task<IActionResult> signin(SigninViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var result = await _SignInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, viewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return Redirect("/");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }

            return View(viewModel);
        }



        [HttpGet, Route("Register")]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid) {

                var user = new User { UserName = viewModel.Username, Email = viewModel.Email };

                var result = await _UserManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    return Redirect("/");

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }
            }
            return View(viewModel);
        } 


    }
}
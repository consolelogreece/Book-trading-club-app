using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTradingClub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Book_Trading_Club.Controllers
{
    public class HomeController : Controller
    {
        protected BTCContext mContext;
        protected UserManager<User> mUserManager;
        protected SignInManager<User> mSignInManager;


        public HomeController(BTCContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult ViewBook()
        {
            var books = from b in mContext.Books where b.Id > 1000 select b;

            return View(books);
        }
    }
}
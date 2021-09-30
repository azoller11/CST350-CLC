using Microsoft.AspNetCore.Mvc;
using MinesweeperCLC.Models;
using MinesweeperCLC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperCLC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public LoginDAO service = new LoginDAO();

        public IActionResult Login(UserModel login)
        {
            if (service.isValid(login))
            {
                return View("LoginSuccess");
            }
            else
            {
                return View("Index");
            }
            
        }

    }
}

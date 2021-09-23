using Microsoft.AspNetCore.Mvc;
using MinesweeperCLC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperCLC.Controllers
{
    public class Api : Controller
    {

        public DAO services = new DAO();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] //https://localhost:44361/Api/getAmountOfGames
        public ActionResult getAmountOfGames()
        {
            return Content("There are "+services.getNumberOfGames()+" games in progress");
        }


        [HttpGet] //https://localhost:44361/Api/getAmountOfGames
        public ActionResult showSavedGames()
        {

            return Content(services.getGames().OfType<string>() + "");
        }

        public ActionResult deleteGame(int index)
        {
            services.deleteGame(index);

            return Content("Deleted game at index: " + index);
        }




    }
}

using MinesweeperCLC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperCLC.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random random = new Random();
        const int GRID_SIZE = 25;
        Board gameBoard = HomeController.gameBoard;


       

        public IActionResult Index()
        {
            buttons = new List<ButtonModel>();

            for(int row = 0; row < gameBoard.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < gameBoard.Grid.GetLength(1); col++)
                {
                    buttons.Add(new ButtonModel(row, col, 0));
                }
            }
            return View("Index", buttons);
        }

        public IActionResult HandelButtonClick(string buttonNumber)
        {
            //buttons.ElementAt(i).NumberOfNeighbors = gameBoard.Grid[row, col].LiveNeighbors;
            int bN = int.Parse(buttonNumber);
            int row = buttons.ElementAt(bN).Row;
            int col = buttons.ElementAt(bN).Col;
            if (!gameBoard.Grid[row, col].Live)
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (gameBoard.Grid[buttons.ElementAt(i).Row, buttons.ElementAt(i).Col].Visited)
                    {
                        buttons.ElementAt(i).ButtonState = 1;
                    }
                    
                }
            }
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons.ElementAt(i).NumberOfNeighbors = gameBoard.Grid[buttons.ElementAt(i).Row, buttons.ElementAt(i).Col].LiveNeighbors;
            }



                System.Diagnostics.Debug.WriteLine("Update Board");


            return View("Index", buttons);
        }

        public IActionResult ShowOneButton(int buttonNumber)
        {
           

            int row = buttons.ElementAt(buttonNumber).Row;
            int col = buttons.ElementAt(buttonNumber).Col;

            if (gameBoard.Grid[row, col].Live && !gameBoard.Grid[row, col].Flagged)
            {
                buttons.ElementAt(buttonNumber).ButtonState = 3;
                // You loose the game
                System.Diagnostics.Debug.WriteLine("You loose the game");
            } else
            {
                if (!gameBoard.Grid[row, col].Visited && !gameBoard.Grid[row, col].Flagged)
                {
                    buttons.ElementAt(buttonNumber).ButtonState = 1;
                    gameBoard.floodFill(row, col);
                    
                }
            }
            return PartialView(buttons.ElementAt(buttonNumber));
        }

        public IActionResult RightClickShowOneButton(int buttonNumber)
        {

            int row = buttons.ElementAt(buttonNumber).Row;
            int col = buttons.ElementAt(buttonNumber).Col;

            gameBoard.Grid[row, col].Flagged = true;
            buttons.ElementAt(buttonNumber).ButtonState = 2;

            return PartialView(buttons.ElementAt(buttonNumber));
        }


    }
}

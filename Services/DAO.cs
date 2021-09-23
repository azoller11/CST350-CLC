using MinesweeperCLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperCLC.Services
{


    public class DAO
    {
        public static List<Board> games { get; set; }

        public DAO()
        {
            games = new List<Board>();

        }

        public void saveGame(Board board) {
            games.Add(board);
        }

        public void deleteGame(int index)
        {
            try
            {
                games.RemoveAt(index);
            }
            catch { }
        }

        public int getNumberOfGames()
        {
            return games.Count;
        }

        public List<Board> getGames()
        {
            return games;
        }


    }
}

using MinesweeperCLC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperCLC.Services
{
    public class LoginDAO
    {

        public bool isValid(UserModel user)
        {
            if (user.userName == "Azoller" && user.password == "Password11")
            {
                return true;
            }
            return false;

        }



    }
}

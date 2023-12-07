using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Services
{
    public static class LoginService
    {
        public static bool isCorrect(string user, string pass)
        {
            if (user != Constants.userName || pass != Constants.passWord)
            {
                return false;
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea.Helper
{
    public class Validations
    {
        public static bool IsnotEmpty(string data)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(data))
            {
                result = true;
            }
            return result;
        }
        public static bool IsEqual(string password, string confirmPassword)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword))
            {
                if (password.Equals(confirmPassword))
                    result = true;
            }
            else
                result = false;

            return result;
        }

    }
}
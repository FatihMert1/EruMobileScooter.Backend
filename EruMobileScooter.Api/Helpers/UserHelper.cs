using System.Collections.Generic;
using EruMobileScooter.Data;
using EruMobileScooter.Localization.Models;

namespace EruMobileScooter.Api.Helpers
{
    public static class UserHelper
    {
        public static bool IsUserValid(User user, ILanguage language){
            if (user.Name.Trim().Equals("") || user.Name == null)
            {
                language.SetArguments("Name Is Required Or Invalid Input");
                return false;
            }
            else if (user.Surname.Trim().Equals("") || user.Surname == null)
            {
                language.SetArguments("Surname Is Required Or Invalid Input");
                return false;
            }
            else if (user.Email.Trim().Equals("") || user.Email == null)
            {
                language.SetArguments("Email Is Required Or Invalid Input");
                return false;
            }
            else if (user.Department.Trim().Equals("") || user.Department == null)
            {
                language.SetArguments("Department Is Required Or Invalid Input");
                return false;
            }
            else if (user.Faculty.Trim().Equals("") || user.Faculty == null)
            {
                language.SetArguments("Faculty Is Required Or Invalid Input");
                return false;
            }
            else if (user.Gender == Gender.NONE)
            {
                language.SetArguments("Gender Is Required Or Invalid Input");
                return false;
            }
            else if (user.Identity.Trim().Equals("") || user.Identity == null)
            {
                language.SetArguments("Identity Is Required Or Invalid Input");
                return false;
            }
            else if (user.Password.Trim().Equals("") || user.Password == null)
            {
                language.SetArguments("Password Is Required Or Invalid Input");
                return false;
            }
            else if (user.Phone.Trim().Equals("") || user.Phone == null)
            {
                language.SetArguments("Phone Is Required Or Empty Input");
                return false;
            }
            else if (user.Role == Role.NONE)
            {
                language.SetArguments("Role Is Required Or Invalid Input");
                return false;
            }

            return true;
        }
    }
}
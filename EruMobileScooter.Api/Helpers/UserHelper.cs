using System.Collections.Generic;
using EruMobileScooter.Data;
using EruMobileScooter.Localization.Models;

namespace EruMobileScooter.Api.Helpers
{
    public static class UserHelper
    {
        public static bool IsUserValid(User user ){
            if(user == null){
                return false;
            }
            else if (user.Name.Trim().Equals("") || user.Name == null)
            {
                return false;
            }
            else if (user.Surname.Trim().Equals("") || user.Surname == null)
            {
                return false;
            }
            else if (user.Email.Trim().Equals("") || user.Email == null)
            {
                return false;
            }
            else if (user.Department.Trim().Equals("") || user.Department == null)
            {
                return false;
            }
            else if (user.Faculty.Trim().Equals("") || user.Faculty == null)
            {
                return false;
            }
            else if (user.Gender == Gender.NONE)
            {
                return false;
            }
            else if (user.Identity.Trim().Equals("") || user.Identity == null)
            {
                return false;
            }
            else if (user.Password.Trim().Equals("") || user.Password == null)
            {
                return false;
            }
            else if (user.Phone.Trim().Equals("") || user.Phone == null)
            {
                return false;
            }
            else if (user.Role == Role.NONE)
            {
                return false;
            }

            return true;
        }
    }
}
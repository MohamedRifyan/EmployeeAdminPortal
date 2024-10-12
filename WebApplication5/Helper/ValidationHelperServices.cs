using System.Text.RegularExpressions;
using WebApplication5.DTO.RequestDTO;

namespace WebApplication5.Helper
{
    public class ValidationHelperServices
    {
        public static string UserValidator(UserReqDTO reqdto)
        {
            if (string.IsNullOrEmpty(reqdto.Name)) { return "Name Field Required"; }

            if (!IsValidEmail(reqdto.Email))
            {
                return "Enter Valid Email Address";
            }

            if (reqdto.Password.Length < 8 ) { return "Enter 8 digit password"; }

            if (reqdto.Phone != null)
            {

            if (reqdto.Phone.Length != 10 || !reqdto.Phone.All(char.IsDigit))
            {
                return "Phone Number must be exactly 10 digits";
            }

            }

            return null;
        }

        public static bool IsValidEmail(string email)
        {

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}

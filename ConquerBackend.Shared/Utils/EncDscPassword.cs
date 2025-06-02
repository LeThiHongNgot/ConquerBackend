using System.Text;

namespace ConquerBackend.Shared.Utils
{
    public class EncDscPassword
    {
        public static string secretKey = "ngotlth@gmailcom5345fadfasd";
        public static string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "";
            }
            else
            {
                password += secretKey;
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(passwordBytes);

            }
        }
        public static string Decrypt(string encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword))
            {
                return "";
            }

            try
            {
                var encodedBytes = Convert.FromBase64String(encryptedPassword);
                var actualPassword = Encoding.UTF8.GetString(encodedBytes);
                actualPassword = actualPassword.Substring(0, actualPassword.Length - secretKey.Length);
                return actualPassword;
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("The provided string is not a valid Base-64 string.", ex);
            }
        }
    }
}

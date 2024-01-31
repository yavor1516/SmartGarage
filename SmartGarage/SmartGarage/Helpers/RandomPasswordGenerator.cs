using System.Security.Cryptography;
using System.Text;

namespace SmartGarage.Helpers
{
    public class RandomPasswordGenerator
    {

        public string GeneratePassword(int lenght)
        {
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=<>";

            // Generate the password
            string password = GenerateRandomPassword(lenght, allowedChars);

            // Output the generated password

            return password;
        }
        private string GenerateRandomPassword(int length, string allowedChars)
        {
            // Create a StringBuilder to hold the generated password
            StringBuilder password = new StringBuilder(length);

            // Create a byte array to hold the random bytes
            byte[] randomBytes = new byte[length * 4];

            // Create an instance of RNGCryptoServiceProvider
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // Fill the array with random bytes
                rng.GetBytes(randomBytes);
            }

            // Generate the password using the random bytes
            for (int i = 0; i < length; i++)
            {
                // Convert the random byte to an index in the allowedChars string
                int index = (int)(BitConverter.ToUInt32(randomBytes, i * 4) % allowedChars.Length);
                index = Math.Abs(index);

                // Append the character at the generated index to the password
                password.Append(allowedChars[index]);
            }

            return password.ToString();
        }
    }


}

using ForumSystem.Exceptions;
using SmartGarage.Helpers;
using SmartGarage.Helpers.Contracts;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;
using System.Text;

namespace SmartGarage.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserDataService _userDataService;
        private readonly IPasswordHasher _passwordHasher;
        public AccountService(IUserDataService userDataService, IPasswordHasher passwordHasher)
        {
            _userDataService = userDataService;
            _passwordHasher = passwordHasher;
        }
        public User RegisterUser(RegisterUserDTO registerUserDTO)
        {
            User existingUserByEmail = _userDataService.GetByEmail(registerUserDTO.Email);
            if (existingUserByEmail != null)
            {
                throw new DuplicateEntityException($"Account with email: {existingUserByEmail.Email} already exist!.");
            }
            //Generating Random Password with 9 symbols
            RandomPasswordGenerator randomPasswordGenerator = new RandomPasswordGenerator();
            string password = randomPasswordGenerator.GeneratePassword(9);
            string passwordHash = _passwordHasher.HashPassword(password);
            //set Username to be |myEmailName| @gmail.com
            int atIndex = registerUserDTO.Email.IndexOf('@');
            string usernamePart = registerUserDTO.Email.Substring(0, atIndex);

            User registerUser = new User()
            {
                Email = registerUserDTO.Email,
                Username = usernamePart,
                PasswordHash = Encoding.UTF8.GetBytes(passwordHash),
                RegistrationDate = DateTime.Now
            };

            EmailSender emailSender = new EmailSender();
            emailSender.SendEmail(registerUser.Email, password);

            _userDataService.CreateUser(registerUser);

            return registerUser;
        }
    }
}

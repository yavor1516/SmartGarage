using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GarageContext _dbcontext;

        public UserRepository(GarageContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public User CreateUser(User user, bool isCustomer)
        {
            _dbcontext.Users.Add(user);
            if (isCustomer == true)
            {
                Customer custumer = new Customer()
                {
                    User = user,
                    UserID = user.UserID
                };
                _dbcontext.Customers.Add(custumer);
            }



            _dbcontext.SaveChanges();
            return user;
        }

        public ICollection<User> GetAllUsers()
        {
            return _dbcontext.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }

        public User GetUserByFirstName(string firstName)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.FirstName == firstName);
            return user;
        }

        public User GetUserById(int id)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.UserID == id);
            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = _dbcontext.Users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        public void UpdateUser(User user)
        {
            var existingUser = _dbcontext.Users.Find(user.UserID);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Username = user.Username;
                existingUser.phoneNumber = user.phoneNumber;

                _dbcontext.SaveChanges();
            }
        }
    }
}

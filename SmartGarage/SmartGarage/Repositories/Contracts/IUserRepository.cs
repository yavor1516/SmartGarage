namespace SmartGarage.Repositories.Contracts
{
    public interface IUserRepository
    {
        public User GetUserById(int id);
        public User GetUserByFirstName(string firstName);
        public User GetUserByUsername(string username);
        public User GetUserByEmail(string email);
        public ICollection<User> GetAllUsers();
        public User CreateUser(User user , bool isCustomer);
        public void UpdateUser(User user);

    }
}

using SystemZarzadzaniaPraktykami.Models.User;

namespace SystemZarzadzaniaPraktykami.Persistance.User
{
    public class UserService : IUserService
    {
        private Models.User.User _loggedInUser;
        public Models.User.User GetLoggedInUser()
        {
            return _loggedInUser;
        }

        public void SetLoggedInUser(Models.User.User user)
        {
            _loggedInUser = user;
        }
    }
}

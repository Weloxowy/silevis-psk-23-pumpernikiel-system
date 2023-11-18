using SystemZarzadzaniaPraktykami.Models.User;

namespace SystemZarzadzaniaPraktykami.Persistance.User
{
    public class UserService : IUserService
    {
        private Models.User.User _loggedInUser = new Models.User.User();
        public Models.User.User GetLoggedInUser()
        {
            return _loggedInUser;
        }

        public void SetLoggedInUser(Models.User.User user)
        {
            _loggedInUser = user;
        }

        public string GetLoggedInUserName()
        {
            return _loggedInUser.firstName;
        }

        public void clear()
        {
            _loggedInUser.firstName = null;
            _loggedInUser.email = null;
            _loggedInUser.studentNumber = null;
            _loggedInUser.studentProgrammes = null;
            _loggedInUser.id = null;
            _loggedInUser.lastName = null;
            _loggedInUser.staffStatus = -1;
            _loggedInUser.studentStatus = -1;
        }
    }
}

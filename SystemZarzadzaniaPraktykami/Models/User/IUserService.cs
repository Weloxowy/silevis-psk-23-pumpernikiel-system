namespace SystemZarzadzaniaPraktykami.Models.User
{
    public interface IUserService
    {
        User GetLoggedInUser();
        void SetLoggedInUser(User user);
    }
}

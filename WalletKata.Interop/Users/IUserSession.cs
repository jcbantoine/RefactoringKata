namespace WalletKata.Interop.Users
{
    public interface IUserSession
    {
        IUserSession GetInstance();
        IUser GetLoggedUser();
    }
}
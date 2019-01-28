using WalletKata.Exceptions;
using WalletKata.Interop.Users;

namespace WalletKata.Users
{
    public class UserSession : IUserSession
    {
        private readonly UserSession userSession = new UserSession();

        private UserSession() { }

        public IUserSession GetInstance()
        {
            return userSession;
        }

        public IUser GetLoggedUser()
        {
            throw new ThisIsAStubException("UserSession.IsUserLoggedIn() should not be called in an unit test");
        }
    }
}
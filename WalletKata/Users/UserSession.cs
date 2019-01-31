using WalletKata.Exceptions;
using WalletKata.Interop.Users;

namespace WalletKata.Users
{
    public class UserSession : IUserSession
    {
        private readonly IUserSession userSession = new UserSession();

        private UserSession() { }

        public IUser GetLoggedUser()
        {
            throw new ThisIsAStubException("UserSession.IsUserLoggedIn() should not be called in an unit test");
        }
    }
}
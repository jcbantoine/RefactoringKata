using System.Collections.Generic;
using System.Linq;
using WalletKata.Exceptions;
using WalletKata.Interop.Users;
using WalletKata.Interop.Wallets;

namespace WalletKata.Wallets
{
    public class WalletService
    {
        protected IUserSession _userSession;
        protected IWalletDAO _walletDAO;

        public WalletService(IUserSession userSession, IWalletDAO walletDAO)
        {
            _userSession = userSession;
            _walletDAO = walletDAO;
        }

        public List<IWallet> GetWalletsByUser(IUser user)
        {
            var walletList = new List<IWallet>();
            var loggedUser = _userSession.GetInstance().GetLoggedUser();
            bool isFriend = false;

            if (loggedUser != null)
            {
                isFriend = user.GetFriends().Any(u => u.Equals(loggedUser));
                
                if (isFriend)
                    walletList = _walletDAO.FindWalletsByUser(user);

                return walletList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }      
        }         
    }
}
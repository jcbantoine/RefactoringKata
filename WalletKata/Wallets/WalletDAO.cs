using System.Collections.Generic;
using WalletKata.Exceptions;
using WalletKata.Interop.Users;
using WalletKata.Interop.Wallets;

namespace WalletKata.Wallets
{
    public class WalletDAO : IWalletDAO
    {
        public List<IWallet> FindWalletsByUser(IUser user)
        {
            throw new ThisIsAStubException("WalletDAO.FindWalletsByUser() should not be called in an unit test");
        }
    }
}
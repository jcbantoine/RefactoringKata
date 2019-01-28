using System.Collections.Generic;
using WalletKata.Interop.Users;

namespace WalletKata.Interop.Wallets
{
    public interface IWalletDAO
    {
        List<IWallet> FindWalletsByUser(IUser user);
    }
}
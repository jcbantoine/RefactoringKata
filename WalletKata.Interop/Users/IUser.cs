using System.Collections;
using System.Collections.Generic;

namespace WalletKata.Interop.Users
{
    public interface IUser
    {
        IEnumerable<IUser> GetFriends();
        void AddFriend(IUser friend);
        bool Equals(IUser user);
    }
}
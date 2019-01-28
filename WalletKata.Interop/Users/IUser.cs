using System.Collections;

namespace WalletKata.Interop.Users
{
    public interface IUser
    {
        IEnumerable GetFriends();
        void AddFriend(IUser friend);
        bool Equals(IUser user);
    }
}
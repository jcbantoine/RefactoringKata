using System.Collections;
using System.Collections.Generic;
using WalletKata.Interop.Users;

namespace WalletKata.Users
{
    public class User : IUser
    {
        private List<IUser> friends = new List<IUser>();

        public IEnumerable<IUser> GetFriends()
        {
            return friends;
        }

        public void AddFriend(IUser friend)
        {
            friends.Add(friend);
        }

        public bool Equals(IUser user)
        {
            return base.Equals(user);
        }
    }
}
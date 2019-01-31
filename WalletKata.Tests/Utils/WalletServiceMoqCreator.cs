using WalletKata.Interop.Users;
using Moq;
using System.Collections.Generic;

namespace WalletKata.Tests.Utils
{
        public static class WalletServiceMoqCreator
        {
            public static Mock<IUser> CreateFriendIUserMoq(List<IUser> friends)
            {
                var friendUserMoq = new Mock<IUser>();
                friendUserMoq
                    .Setup(u => u.GetFriends())
                    .Returns(friends)
                    .Verifiable();
                return friendUserMoq;
            }

            public static Mock<IUserSession> CreateIUserSessionMoq(IUser loggedUser)
            {
                var userSessionMoq = new Mock<IUserSession>();
                userSessionMoq
                    .Setup(u => u.GetLoggedUser())
                    .Returns(loggedUser)
                    .Verifiable();
                return userSessionMoq;
            }
        }
}

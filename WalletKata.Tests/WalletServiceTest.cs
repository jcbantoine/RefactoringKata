using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WalletKata.Exceptions;
using WalletKata.Interop.Users;
using WalletKata.Interop.Wallets;
using WalletKata.Tests.Utils;
using WalletKata.Users;
using WalletKata.Wallets;

namespace WalletKata.Tests
{
    [TestClass]
    public partial class WalletServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(UserNotLoggedInException))]
        public void WalletService_NotLoggedUser()
        {
            //init

            var friendUserMoq = new Mock<IUser>();
            var walletDAOMoq = new Mock<IWalletDAO>();
            var userSessionMoq = WalletServiceMoqCreator.CreateIUserSessionMoq(null);

            var walletService = new WalletService(userSessionMoq.Object, walletDAOMoq.Object);

            //system-under-test

            walletService.GetWalletsByUser(friendUserMoq.Object);

            //asserts
            
            //The last instruction have to throw an UserNotLoggedInException.
        }

        [TestMethod]
        public void WalletService_IfUserNotFriend_EmptyList()
        {
            //init

            var walletDAOMoq = new Mock<IWalletDAO>();

            var anotherFriendUserMoq = new Mock<IUser>();
            anotherFriendUserMoq
                .Setup(au => au.Equals(It.IsAny<IUser>()))
                .Returns(false)
                .Verifiable();

            var friends = new List<IUser>();
            friends.Add(anotherFriendUserMoq.Object);

            var friendUserMoq = WalletServiceMoqCreator.CreateFriendIUserMoq(friends);

            var loggedUser = new User();
            var userSessionMoq = WalletServiceMoqCreator.CreateIUserSessionMoq(loggedUser);

            var walletService = new WalletService(userSessionMoq.Object, walletDAOMoq.Object);

            //system-under-test

            var wallets = walletService.GetWalletsByUser(friendUserMoq.Object);

            //asserts

            Assert.IsNotNull(wallets);
            Assert.AreEqual(0, wallets.Count);
            anotherFriendUserMoq.VerifyAll();
            friendUserMoq.VerifyAll();
            userSessionMoq.VerifyAll();
        }

        [TestMethod]
        public void WalletService_IfUserFriend_WalletList()
        {
            //init

            var friendsWallets = new List<IWallet>() { new Wallet() };

            var walletDAOMoq = new Mock<IWalletDAO>();
            walletDAOMoq
                .Setup(w => w.FindWalletsByUser(It.IsAny<IUser>()))
                .Returns(friendsWallets)
                .Verifiable();

            var anotherFriendUserMoq = new Mock<IUser>();
            anotherFriendUserMoq
                .Setup(au => au.Equals(It.IsAny<IUser>()))
                .Returns(true)
                .Verifiable();

            var friends = new List<IUser>();
            friends.Add(anotherFriendUserMoq.Object);
            Mock<IUser> friendUserMoq = WalletServiceMoqCreator.CreateFriendIUserMoq(friends);

            var loggedUser = new User();
            var userSessionMoq = WalletServiceMoqCreator.CreateIUserSessionMoq(loggedUser);

            var walletService = new WalletService(userSessionMoq.Object, walletDAOMoq.Object);

            //system-under-test
            var wallets = walletService.GetWalletsByUser(friendUserMoq.Object);

            //asserts
            Assert.AreNotEqual(0, wallets.Count);
            anotherFriendUserMoq.VerifyAll();
            friendUserMoq.VerifyAll();
            userSessionMoq.VerifyAll();
        }
    }
}

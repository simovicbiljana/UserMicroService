using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroService.DataAccess;
using UserMicroService.Models;

namespace UserMicroService.Tests
{
    public class UserTest
    {
        public void ClearUsers () {

            UserDB.listOfUser.Clear();

        }

        [Test]
        public void Create_User_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);
            Assert.AreEqual(1, UserDB.listOfUser.Count);
        }

        [Test]
        public void Create_User_Fail()
        {
            ClearUsers();
            User testUser1 = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            User testUser2 = new User
            {
                Id = 1,
                Name = "Ljljana"
            };
            UserDB.CreateUser(testUser1);
            UserDB.CreateUser(testUser2);
            Assert.AreEqual(1, UserDB.listOfUser.Count);
        }

        [Test]
        public void GetUserById_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);

            Assert.AreEqual(testUser, UserDB.GetUserId(1));
        }

        [Test]
        public void GetUserById_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);

            Assert.AreEqual(null, UserDB.GetUserId(2));
        }

        [Test]
        public void GetUserByName_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);

            Assert.AreEqual(testUser, UserDB.GetUserName("Bojana"));
        }

        [Test]
        public void GetUserByName_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);

            Assert.AreEqual(null, UserDB.GetUserName("Ljiljana"));
        }

        [Test]
        public void GetAllUsers_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);

            Assert.AreEqual(1, UserDB.GetAllUsers().Count);
        }

        [Test]
        public void ModifyUser_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);

            User testUser1 = new User
            {
                Id = 1,
                Name = "Ljiljana"
            };

            UserDB.ModifyUser(testUser1);

            Assert.AreEqual(testUser1, UserDB.GetUserName("Ljiljana"));
        }

        [Test]
        public void Modify_User_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);

            User testUser1 = new User
            {
                Id = 1,
                Name = "Ljiljana"
            };

            UserDB.ModifyUser(testUser1);

            Assert.AreEqual(null, UserDB.GetUserName("Bojana"));
        }

        [Test]
        public void RemoveUser_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);
            UserDB.RemoveUser(1);

            Assert.AreEqual(0, UserDB.listOfUser.Count);
        }

        [Test]
        public void RemoveUser_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);
            UserDB.RemoveUser(2);

            Assert.AreEqual(1, UserDB.listOfUser.Count);
        }

    }
   
}

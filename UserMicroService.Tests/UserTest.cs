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
            User testUser = new User
            {
                ID = 1,
                Name = "Bojana"
            };
            UserDB.CreateUser(testUser);
            Assert.AreEqual(2, UserDB.listOfUser.Count);
        }
        
    }
   
}

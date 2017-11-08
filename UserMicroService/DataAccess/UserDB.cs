using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMicroService.Models;

namespace UserMicroService.DataAccess
{
    public static class UserDB
    {
        public static List<User> listOfUser = new List<User>();

        public static User GetUserId(int id) {
            foreach (User user in listOfUser)
            {
                if (user.Id == id) {
                    return user;
                }
            }
            return null;

        }

        public static User GetUserName(string name) {
            foreach (User user in listOfUser) {

                if (user.Name == name) {

                    return user;
                }
            }
            return null;
        }

       public static List<User> GetAllUsers() {
            return listOfUser;
            
        }

        public static User CreateUser(User user) {

            listOfUser.Add(user);
            return GetUserId(user.Id);

        }
        
    }
}
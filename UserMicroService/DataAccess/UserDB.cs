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

            Console.WriteLine("User with this id already exists!");
            return null;

        }

        public static User GetUserName(string name) {
            foreach (User user in listOfUser) {

                if (user.Name == name) {

                    return user;
                }
            }

            Console.WriteLine("User with this name already exists!");
            return null;
        }

       public static List<User> GetAllUsers() {
            return listOfUser;
            
        }

        public static User CreateUser(User user) {
            listOfUser.Add(user);
            return GetUserId(user.Id);

        }

        public static void RemoveUser(int id) {
            User user = GetUserId(id);
            listOfUser.Remove(user);
        }

        public static void ModifyUser(User u) {
            User user = GetUserId(u.Id);
            listOfUser.Remove(user);
            listOfUser.Add(u);
        }
        
    }
}
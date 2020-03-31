using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Asssignment_PSD_2201809140.Model;
using Microsoft.Ajax.Utilities;

namespace Asssignment_PSD_2201809140.Repository
{
    public static class AccountRepository
    {
        private static DatabaseTokbedEntities tokbedDb = new DatabaseTokbedEntities();
        public static List<Users> GetUsers()
        {
            return (tokbedDb.Users).ToList();
        }

        public static void UpdateProfile(Users lama, String email, String name, String gender)
        {
            Users dapat =  tokbedDb.Users.Find(lama.Id);
            dapat.Email = email;
            dapat.Name = name;
            dapat.Gender = gender;
            tokbedDb.SaveChanges();

        }

        public static void ChangePassword(Users lama, String newPassword)
        {
            Users dapat = tokbedDb.Users.Find(lama.Id);
            dapat.Password = newPassword;
            tokbedDb.SaveChanges();

        }

        public static Users findUser(String email, String password)
        {
            Users user = tokbedDb.Users.Where(User => User.Email.Equals(email) && User.Password.Equals(password)).FirstOrDefault();
            return user;
        }

        public static void ToggleStatus(int id)
        {
            Users user = tokbedDb.Users.Find(id);
            if (user.Status.Equals("active"))
            {
                user.Status = "blocked";
            }
            else
            {
                user.Status = "active";
            }
                
            tokbedDb.SaveChanges();

        }

        public static void ToogleRole(int id)
        {
            Users user = tokbedDb.Users.Where(satu => satu.Id == id).FirstOrDefault();
            if (user.RoleId == 1)
            {
                user.RoleId = 2;
            }
            else
            {
                user.RoleId = 1;
            }
        }

        public static bool ifCredNull(String email, String password)
        {
            Users user = findUser(email,password);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ifEmailExist(String email)
        {
            Users user = tokbedDb.Users.Where(User => User.Email.Equals(email)).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void insertUser(Users newUser)
        {
            tokbedDb.Users.Add(newUser);
            tokbedDb.SaveChanges();
        }

    }
}
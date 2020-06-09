using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Factory;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.Handler
{
    public class AccountHandler
    {


        public static List<Users> GetUsers()
        {
            return AccountRepository.GetUsers();
        }

        public static void UpdateProfile(Users lama, String email, String name, String gender)
        {
            AccountRepository.UpdateProfile(lama,email,name,gender);

        }

        public static void ChangePassword(Users lama, String newPassword)
        {
            AccountRepository.ChangePassword(lama,newPassword);

        }

        public static Users findUser(String email, String password)
        {
            return AccountRepository.findUser(email, password);
        }

        public static void ToggleStatus(int id)
        {
            AccountRepository.ToggleStatus(id);

        }

        public static void ToogleRole(int id)
        {
          AccountRepository.ToogleRole(id);
        }

        public static bool ifCredNull(String email, String password)
        {
           return AccountRepository.ifCredNull(email, password);
        }

        public static bool ifEmailExist(String email)
        {
            return AccountRepository.ifEmailExist(email);
        }

        public static void insertUser(String emailRegis, String nameRegis,String passwordRegis,
            String genderRegis)
        {
            userFactory userPabrik = new userFactory();
            Users userBaru = userPabrik.CreateUser(emailRegis, nameRegis, passwordRegis,
                genderRegis);
            AccountRepository.insertUser(userBaru);
        }

    }
}
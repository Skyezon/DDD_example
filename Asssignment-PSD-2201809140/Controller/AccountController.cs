using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Handler;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Controller
{
    public class AccountController
    {
        public List<String> errorList = new List<string>();

        public  List<Users> GetUsers()
        {
            return AccountHandler.GetUsers();
        }

        public  void UpdateProfile(Users lama, String email, String name, String gender)
        {
            AccountHandler.UpdateProfile(lama, email, name, gender);

        }

        public  void ChangePassword(Users lama, String newPassword)
        {
            AccountHandler.ChangePassword(lama, newPassword);

        }

        public  Users findUser(String email, String password)
        {
            return AccountHandler.findUser(email, password);
        }

        public  void ToggleStatus(int id)
        {
            AccountHandler.ToggleStatus(id);

        }

        public  void ToogleRole(int id)
        {
            AccountHandler.ToogleRole(id);
        }

        public  bool ifCredNull(String email, String password)
        {
            return AccountHandler.ifCredNull(email, password);
        }

        public  bool ifEmailExist(String email)
        {
            return AccountHandler.ifEmailExist(email);
        }

        public  void insertUser(String emailRegis, String nameRegis, String passwordRegis,
            String genderRegis)
        {
            AccountHandler.insertUser(emailRegis, nameRegis, passwordRegis,
                genderRegis);
        }

        protected bool validateEmail(String emailRegis)
        {
            if (String.IsNullOrEmpty(emailRegis) || AccountHandler.ifEmailExist(emailRegis))
            {
                errorList.Add("Email Must be filled and unique");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validateName(String nameRegis)
        {
            if (String.IsNullOrEmpty(nameRegis))
            {
                errorList.Add("name Must be filled");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validatePassword(String passwordRegis)
        {
            if (String.IsNullOrEmpty(passwordRegis))
            {
                errorList.Add("Password Must be filled");

                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validateConfirmPassword(String passwordRegis, String confirmPasswordRegis)
        {
            if (passwordRegis.Equals(confirmPasswordRegis))
            {
                return true;
            }
            else
            {
                errorList.Add("confirm Pasword Must be same with password");
                return false;
            }
        }

        protected bool validateGender(String genderRegis)
        {
            String genderValue = genderRegis;
            if (String.IsNullOrEmpty(genderValue))
            {
                errorList.Add("Gender Must be chosen");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkAllValidation(String passwordRegis, String confirmPasswordRegis, String genderRegis, String nameRegis,String emailRegis)
        {
            bool isemailGud = validateEmail(emailRegis);
            bool isnameGud = validateName(nameRegis);
            bool ispasswordGud = validatePassword(passwordRegis);
            bool isconfirmGud = validateConfirmPassword(passwordRegis,confirmPasswordRegis);
            bool isgenderGud = validateGender(genderRegis);
            if (isemailGud && isnameGud && ispasswordGud && isconfirmGud && isgenderGud)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected bool validateOldPassword(String oldPassword, Users sessionUsers)
        {
            

            if (oldPassword.Equals(sessionUsers.Password))
            {
                return true;
            }
            else
            {
                errorList.Add("old password Must match with the password in database");
                return false;
            }
        }

        protected bool validatenewPassword(String newPassword)
        {
            if (newPassword.Length < 5)
            {
                errorList.Add("new Password must be longer than 5 character");
                return false;
            }
            else
            {
                
            }
            {
                return true;
            }
        }



        public bool validateAll(String oldPassword, String newPassword, String confirmPassword, Users sessionUsers)
        {
            if (validateOldPassword(oldPassword, sessionUsers) && validatenewPassword(newPassword) && validateConfirmPassword(confirmPassword,newPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool checkAllValidationUpdate(String email, String name, String gender)
        {
            bool isemailGud = validateEmail(email);
            bool isnameGud = validateName(name);
            bool isgenderGud = validateGender(gender);
            if (isemailGud && isnameGud && isgenderGud)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
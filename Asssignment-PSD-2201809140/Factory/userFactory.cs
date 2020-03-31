using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Factory
{
    public class userFactory
    {
        public Users CreateUser(String email, String name, String password, String Gender)
        {
            Users userbaru = new Users();

            userbaru.Name = name;
            userbaru.Email = email;
            userbaru.RoleId = 2;
            userbaru.Password = password;
            userbaru.Gender = Gender;
            userbaru.Status = "active";

            return userbaru;

        }
    }
}
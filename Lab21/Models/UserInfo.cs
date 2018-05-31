using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab21.Models
{
    public class UserInfo
    {
        [Required]
        public string FirstName { set; get; }

        [Required]
        public string LastName { set; get; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9{5,30}]+@[a-zA-A0-9{5,10}]+\.[a-zA-Z0-9{2,3}]+$", ErrorMessage = "Bad Email!")]
        public string Email { set; get; }

        [Required]
        public string Phone { set; get; }


        [Required]
        public string Password { set; get; }

        public UserInfo()
        {

        }

        public UserInfo(string firstname, string lastname, string email, string phone, string password)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Phone = phone;
            Password = password;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedemySchool
{
    internal class Information
    {
        private static int _id;
        private static string _name;
        private static string _firstname;
        private static string _lastname;
        private static string _email;
        private static string _phone;
        private static string _address;
        private static string _gender;
        private static string _status;
        private static string _role;
        private static DateTime _datebirthday;
        private static Image _picture;
        private static string _nationalcode;
        private static string _logindate;
        private static string _password;
        private static string _logintime;

        public static string Password
        {
            get { return _password; }   
            set { _password = value; }  
        }
        public static DateTime DateOfBirthDay
        {
            get { return _datebirthday; }
            set { _datebirthday = value; }
        }
        public static Image Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        public static int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public static string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public static string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public static string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public static string PhoneNumber
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public static string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public static string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public static string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public static string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public static string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public static string NationalCode
        {
            get { return _nationalcode; }
            set { _nationalcode = value; }
        }
        public static string LoginDate
        {
            get { return _logindate; }
            set { _logindate = value; }
        }
        public static string LoginTime
        {
            get { return _logintime; }
            set { _logintime = value; }
        }
    }
}

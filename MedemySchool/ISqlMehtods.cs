using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedemySchool
{
    internal interface ISqlMehtods
    {
        // For Admins 
        bool AddAdmins(string AdminName, string AdminPassword, string FirstName, string LastName, string PhoneNumber,
            string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, int Role, string CreateDate, string CreateTime);

        bool EditAdmins(int ID, string AdminName, string AdminPassword, string FirstName, string LastName, string PhoneNumber,
            string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, int Role, string CreateDate, string CreateTime);
        bool DeleteAdmins(int ID);
        // For Students
        bool AddStudents(string StudentName, string StudentPassword, string FirstName, string LastName, string PhoneNumber,
            string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, string CreateDate, string CreateTime);

        bool EditStudents(int ID, string StudentName, string StudentPassword, string FirstName, string LastName, string PhoneNumber,
            string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, string CreateDate, string CreateTime);
        bool DeleteStudents(int ID);
        // For Teachers
        bool AddTeachers(string TeacherName, string TeacherPassword, string FirstName, string LastName, string PhoneNumber,
    string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, string CreateDate, string CreateTime);

        bool EditTeachers(int ID, string StudentName, string StudentPassword, string FirstName, string LastName, string PhoneNumber,
            string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, string CreateDate, string CreateTime);
        bool DeleteTeachers(int ID);

        DataTable SelectAll(string ViewName);
        DataTable StudentSelectRow(int ID);
        DataTable AdminSelectRow(int ID);
        DataTable TeacherSelectRow(int ID);
        DataTable SearchBy(string ViewName, string colname, string valueSearch);

        int RowCountStudents();
        int RowCountTeachers();
        int RowCountAdmins();
    }

}

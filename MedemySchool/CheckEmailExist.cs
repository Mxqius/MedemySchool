using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedemySchool
{
    public class CheckEmailExist
    {
        public static bool CheckEmailSingleStudent(string email)
        {
            using (MedemySchoolEntities mse = new MedemySchoolEntities())
            {
                return mse.uvw_ShowStudents.Any(n => n.StudentEmail == email);
            }
        }
        public static bool CheckEmailSingleTeacher(string email)
        {
            using (MedemySchoolEntities mse = new MedemySchoolEntities())
            {
                return mse.uvw_ShowTeachers.Any(n => n.TeacherEmail == email);
            }
        }
        public static bool CheckEmailSingleStudentAccount(string email, int loginuserID)
        {
            using (MedemySchoolEntities mse = new MedemySchoolEntities())
            {
                return mse.uvw_ShowStudents.Any(n => n.StudentEmail == email && n.StudentID != loginuserID);
            }
        }
        public static bool CheckEmailSingleTeacherAccount(string email, int loginuserID)
        {
            using (MedemySchoolEntities mse = new MedemySchoolEntities())
            {
                return mse.uvw_ShowTeachers.Any(n => n.TeacherEmail == email && n.TeacherID != loginuserID);
            }
        }
        public static bool CheckEmailSingleAdminAccount(string email, int loginuserID)
        {
            using (MedemySchoolEntities mse = new MedemySchoolEntities())
            {
                return mse.uvw_ShowAdmins.Any(n => n.AdminEmail == email && n.AdminID != loginuserID);
            }
        }
    }
}

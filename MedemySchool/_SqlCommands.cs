using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;

namespace MedemySchool
{
    internal class _SqlCommands : ISqlMehtods
    {
        private string sqlcon = _SqlConnection.ConnectionString;

        public bool AddAdmins(string AdminName, string AdminPassword, string FirstName, string LastName, string PhoneNumber, string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, int Role, string CreateDate, string CreateTime)
        {
            try
            {
                SqlConnection sq = new SqlConnection(sqlcon);

                SqlCommand cmd = new SqlCommand("usp_AddAdmins", sq);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminName", AdminName);
                cmd.Parameters.AddWithValue("@AdminPassword", AdminPassword);
                cmd.Parameters.AddWithValue("@AdminFirstName", FirstName);
                cmd.Parameters.AddWithValue("@AdminLastName", LastName);
                cmd.Parameters.AddWithValue("@AdminPhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@AdminEmail", Email);
                cmd.Parameters.AddWithValue("@AdminAddress", Address);
                cmd.Parameters.AddWithValue("@AdminNationalCode", NationalCode);
                cmd.Parameters.AddWithValue("@AdminGender", Gender);
                cmd.Parameters.AddWithValue("@AdminStatus", Status);
                cmd.Parameters.AddWithValue("@AdminPicture", Image);
                cmd.Parameters.AddWithValue("@AdminBirthDay", BirthDay);
                cmd.Parameters.AddWithValue("@AdminRole", Role);
                cmd.Parameters.AddWithValue("@AdminCreateDate", CreateDate);
                cmd.Parameters.AddWithValue("@AdminCreateTime", CreateTime);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddStudents(string StudentName, string StudentPassword, string FirstName, string LastName, string PhoneNumber, string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, string CreateDate, string CreateTime)
        {
            try
            {
                SqlConnection sq = new SqlConnection(sqlcon);
                SqlCommand cmd = new SqlCommand("usp_AddStudents", sq);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentName", StudentName);
                cmd.Parameters.AddWithValue("@StudentPassword", StudentPassword);
                cmd.Parameters.AddWithValue("@StudentFirstName", FirstName);
                cmd.Parameters.AddWithValue("@StudentLastName", LastName);
                cmd.Parameters.AddWithValue("@StudentPhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@StudentEmail", Email);
                cmd.Parameters.AddWithValue("@StudentAddress", Address);
                cmd.Parameters.AddWithValue("@StudentNationalCode", NationalCode);
                cmd.Parameters.AddWithValue("@StudentGender", Gender);
                cmd.Parameters.AddWithValue("@StudentStatus", Status);
                cmd.Parameters.AddWithValue("@StudentPicture", Image);
                cmd.Parameters.AddWithValue("@StudentBirthDay", BirthDay);
                cmd.Parameters.AddWithValue("@StudentCreateDate", CreateDate);
                cmd.Parameters.AddWithValue("@StudentCreateTime", CreateTime);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddTeachers(string TeacherName, string TeacherPassword, string FirstName, string LastName, string PhoneNumber, string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, string CreateDate, string CreateTime)
        {
            try
            {
                SqlConnection sq = new SqlConnection(sqlcon);

                SqlCommand cmd = new SqlCommand("usp_AddTeachers", sq);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherName", TeacherName);
                cmd.Parameters.AddWithValue("@TeacherPassword", TeacherPassword);
                cmd.Parameters.AddWithValue("@TeacherFirstName", FirstName);
                cmd.Parameters.AddWithValue("@TeacherLastName", LastName);
                cmd.Parameters.AddWithValue("@TeacherPhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@TeacherEmail", Email);
                cmd.Parameters.AddWithValue("@TeacherAddress", Address);
                cmd.Parameters.AddWithValue("@TeacherNationalCode", NationalCode);
                cmd.Parameters.AddWithValue("@TeacherGender", Gender);
                cmd.Parameters.AddWithValue("@TeacherStatus", Status);
                cmd.Parameters.AddWithValue("@TeacherPicture", Image);
                cmd.Parameters.AddWithValue("@TeacherBirthDay", BirthDay);
                cmd.Parameters.AddWithValue("@TeacherCreateDate", CreateDate);
                cmd.Parameters.AddWithValue("@TeacherCreateTime", CreateTime);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAdmins(int ID)
        {

            try
            {
                SqlConnection sq = new SqlConnection(sqlcon);
                SqlCommand cmd = new SqlCommand("usp_DeleteAdmins", sq);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminID", ID);
                cmd.Parameters.AddWithValue("@AdminStatus", 0);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStudents(int ID)
        {
            try
            {
                SqlConnection sq = new SqlConnection(sqlcon);

                SqlCommand cmd = new SqlCommand("usp_DeleteStudents", sq);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", ID);
                cmd.Parameters.AddWithValue("@StudentStatus", 0);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTeachers(int ID)
        {
            try
            {
                SqlConnection sq = new SqlConnection(sqlcon);

                SqlCommand cmd = new SqlCommand("usp_DeleteTeachers", sq);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", ID);
                cmd.Parameters.AddWithValue("@TeacherStatus", 0);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditAdmins(int ID, string AdminName, string AdminPassword, string FirstName, string LastName, string PhoneNumber, string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, int Role, string CreateDate, string CreateTime)
        {
            try
            {
                SqlConnection sq = new SqlConnection(sqlcon);

                SqlCommand cmd = new SqlCommand("usp_UpdateAdmins", sq);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminID", ID);
                cmd.Parameters.AddWithValue("@AdminName", AdminName);
                cmd.Parameters.AddWithValue("@AdminPassword", AdminPassword);
                cmd.Parameters.AddWithValue("@AdminFirstName", FirstName);
                cmd.Parameters.AddWithValue("@AdminLastName", LastName);
                cmd.Parameters.AddWithValue("@AdminPhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@AdminEmail", Email);
                cmd.Parameters.AddWithValue("@AdminAddress", Address);
                cmd.Parameters.AddWithValue("@AdminNationalCode", NationalCode);
                cmd.Parameters.AddWithValue("@AdminGender", Gender);
                cmd.Parameters.AddWithValue("@AdminStatus", Status);
                cmd.Parameters.AddWithValue("@AdminPicture", Image);
                cmd.Parameters.AddWithValue("@AdminBirthDay", BirthDay);
                cmd.Parameters.AddWithValue("@AdminRole", Role);
                cmd.Parameters.AddWithValue("@AdminCreateDate", CreateDate);
                cmd.Parameters.AddWithValue("@AdminCreateTime", CreateTime);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditStudents(int ID, string StudentName, string StudentPassword, string FirstName, string LastName, string PhoneNumber, string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, string CreateDate, string CreateTime)
        {
            try
            {
                SqlConnection sq = new SqlConnection(sqlcon);
                SqlCommand cmd = new SqlCommand("usp_UpdateStudents", sq);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentName", StudentName);
                cmd.Parameters.AddWithValue("@StudentPassword", StudentPassword);
                cmd.Parameters.AddWithValue("@StudentFirstName", FirstName);
                cmd.Parameters.AddWithValue("@StudentLastName", LastName);
                cmd.Parameters.AddWithValue("@StudentPhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@StudentEmail", Email);
                cmd.Parameters.AddWithValue("@StudentAddress", Address);
                cmd.Parameters.AddWithValue("@StudentNationalCode", NationalCode);
                cmd.Parameters.AddWithValue("@StudentGender", Gender);
                cmd.Parameters.AddWithValue("@StudentStatus", Status);
                cmd.Parameters.AddWithValue("@StudentPicture", Image);
                cmd.Parameters.AddWithValue("@StudentBirthDay", BirthDay);
                cmd.Parameters.AddWithValue("@StudentCreateDate", CreateDate);
                cmd.Parameters.AddWithValue("@StudentCreateTime", CreateTime);
                cmd.Parameters.AddWithValue("@StudentID", ID);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditTeachers(int ID, string TeacherName, string TeacherPassword, string FirstName, string LastName, string PhoneNumber, string Email, string Address, string NationalCode, int Gender, int Status, byte[] Image, DateTime BirthDay, string CreateDate, string CreateTime)
        {

            try
            {
                SqlConnection sq = new SqlConnection(sqlcon);

                SqlCommand cmd = new SqlCommand("usp_UpdateTeachers", sq);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", ID);
                cmd.Parameters.AddWithValue("@TeacherName", TeacherName);
                cmd.Parameters.AddWithValue("@TeacherPassword", TeacherPassword);
                cmd.Parameters.AddWithValue("@TeacherFirstName", FirstName);
                cmd.Parameters.AddWithValue("@TeacherLastName", LastName);
                cmd.Parameters.AddWithValue("@TeacherPhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@TeacherEmail", Email);
                cmd.Parameters.AddWithValue("@TeacherAddress", Address);
                cmd.Parameters.AddWithValue("@TeacherNationalCode", NationalCode);
                cmd.Parameters.AddWithValue("@TeacherGender", Gender);
                cmd.Parameters.AddWithValue("@TeacherStatus", Status);
                cmd.Parameters.AddWithValue("@TeacherPicture", Image);
                cmd.Parameters.AddWithValue("@TeacherBirthDay", BirthDay);
                cmd.Parameters.AddWithValue("@TeacherCreateDate", CreateDate);
                cmd.Parameters.AddWithValue("@TeacherCreateTime", CreateTime);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable SearchBy(string ViewName, string colname, string valueSearch)
        {
            string query = $"Select * From uvw_Show{ViewName} Where @col like @value";
            try
            {
                using (SqlConnection sc = new SqlConnection(sqlcon))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, sc);
                    sda.SelectCommand.Parameters.AddWithValue("@col", colname);
                    sda.SelectCommand.Parameters.AddWithValue("@value", "%" + valueSearch + "%");
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return null;
            }

        }

        public DataTable SelectAll(string ViewName)
        {
            string query = $"Select * From uvw_Show{ViewName}";
            try
            {
                using (SqlConnection sc = new SqlConnection(sqlcon))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, sc);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return null;
            }
        }

        public DataTable StudentSelectRow(int ID)
        {
            //string idcol = ViewName.Substring(0, ViewName.Length - 1) + "ID";
            string query = $"Select * From uvw_ShowStudents Where StudentID=" + ID;
            try
            {
                using (SqlConnection sc = new SqlConnection(sqlcon))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, sc);
                    //sda.SelectCommand.Parameters.AddWithValue("@colID", col);
                    //sda.SelectCommand.Parameters.AddWithValue("@ID", ID.ToString());
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable TeacherSelectRow(int ID)
        {
            //string idcol = ViewName.Substring(0, ViewName.Length - 1) + "ID";
            string query = $"Select * From uvw_ShowTeachers Where TeacherID=" + ID;
            try
            {
                using (SqlConnection sc = new SqlConnection(sqlcon))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, sc);
                    //sda.SelectCommand.Parameters.AddWithValue("@colID", col);
                    //sda.SelectCommand.Parameters.AddWithValue("@ID", ID.ToString());
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable AdminSelectRow(int ID)
        {
            //string idcol = ViewName.Substring(0, ViewName.Length - 1) + "ID";
            string query = $"Select * From uvw_ShowAdmins Where AdminID=" + ID;
            try
            {
                using (SqlConnection sc = new SqlConnection(sqlcon))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, sc);
                    //sda.SelectCommand.Parameters.AddWithValue("@colID", col);
                    //sda.SelectCommand.Parameters.AddWithValue("@ID", ID.ToString());
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int RowCountStudents()
        {
            try
            {
                using (MedemySchoolEntities mse = new MedemySchoolEntities())
                {
                    return mse.uvw_ShowStudents.Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int RowCountTeachers()
        {
            try
            {
                using (MedemySchoolEntities mse = new MedemySchoolEntities())
                {
                    return mse.uvw_ShowTeachers.Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int RowCountAdmins()
        {
            try
            {
                using (MedemySchoolEntities mse = new MedemySchoolEntities())
                {
                    return mse.uvw_ShowAdmins.Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}

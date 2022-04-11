using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedemySchool
{
    internal class GetAccountData
    {
        private static string _query;
        private ImageMethodSql ims = new ImageMethodSql();
        private SqlConnection sq = new SqlConnection(_SqlConnection.ConnectionString);
        public static string Query
        {
            get { return _query; }
            set { _query = value; }
        }
        public bool GetData(string username , string password)
        {
            string role = Information.Role;
            if (role == "Manager")
                role = "Admin";
            try
            {
                SqlCommand sc = new SqlCommand(Query, sq);
                sc.Parameters.AddWithValue("@Username", username);
                sc.Parameters.AddWithValue("@Password", password);
                //CheckSqlScStatus();
                sq.Open();
                using (SqlDataReader rdr = sc.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Information.ID = Convert.ToInt32(rdr[$"{role}ID"]);
                        Information.Name = rdr[$"{role}Name"].ToString();
                        Information.Password = rdr[$"{role}Password"].ToString();
                        Information.FirstName = rdr[$"{role}FirstName"].ToString();
                        Information.LastName = rdr[$"{role}LastName"].ToString();
                        Information.PhoneNumber = rdr[$"{role}PhoneNumber"].ToString();
                        Information.Email = rdr[$"{role}Email"].ToString();
                        Information.Gender = rdr[$"Gender{role}"].ToString();
                        Information.Status = rdr[$"Status{role}"].ToString();
                        Information.Address = rdr[$"{role}Address"].ToString();
                        Information.NationalCode = rdr[$"{role}NationalCode"].ToString();
                        Information.Picture = ims.ConvertByteToImage((byte[])rdr[$"{role}Picture"], Properties.Resources.defult_profile);
                        Information.DateOfBirthDay = Convert.ToDateTime(rdr[$"{role}BirthDay"]);
                    }
                }
                sq.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

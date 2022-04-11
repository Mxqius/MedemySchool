using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedemySchool
{
    internal class _SqlConnection
    {
        private static string _connectionString = "Data Source=.;Initial Catalog=MedemySchool;Integrated Security=True";
        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPractice.DAL
{
    public class Class1
    {
        public void TestConnect()
        {
            string sqlConnection = @"Data Source=F60B8CF9GB9T4TP;User ID=kida;Password=levelup;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database = t1;";
            string sql = "select * from Student";

            using (var conn = new SqlConnection(sqlConnection))
            {
                
                conn.Open();
                var students = conn.Query<Student>(sql).ToList();
            }

            sql = "update Student set s_name='张三' where s_id = '09'";

            using (var conn = new SqlConnection(sqlConnection))
            {
                conn.Open();
                var affectedRows = conn.Execute(sql);
            }

            //using (var conn = new SqlConnection(sqlConnection))
            //{
            //    conn.Open();
            //    var students = conn.Query(sql).ToList();
            //}

            sql = string.Empty;
        }

    }

    public class Student
    {
        public string s_id { get; set; }
        public string s_name { get; set; }
        public string s_birth { get; set; }
        public string s_sex { get; set; }

    }
}

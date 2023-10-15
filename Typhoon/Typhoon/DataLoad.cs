using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Typhoon
{
    public class DataLoad
    {
        private SqlConnection conn;
        private void ConnectDatabase()
        {
            String conString = "server=47.99.196.197;database=CLASS;uid=class;pwd=ae2021";
            conn = new SqlConnection(conString);
            conn.Open();
            if (conn.State != ConnectionState.Open)
                MessageBox.Show("ERROR!!!");
            else
            {
            }
        }
        public SqlDataReader ExecuteSQL(string sql)
        {
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader dr = com.ExecuteReader();
            return dr;
        }

        //构造函数
        public DataLoad()
        {
            ConnectDatabase();
        }
        ~DataLoad()
        {
            // conn.Close();
        }


    }
}

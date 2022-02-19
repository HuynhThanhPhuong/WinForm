using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi
{
    class KetNoi
    {
        string strConnect = ConfigurationManager.ConnectionStrings["ChuoiKN"].ToString();
        SqlConnection conn;
        public SqlConnection getKetNoi()
        {
            conn = new SqlConnection(strConnect);
            return conn;
        }
        public void closeKetNoi()
        {
            conn.Close();
        }
    }
}

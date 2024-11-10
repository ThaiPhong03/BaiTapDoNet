using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TVSACH1
{
    internal class KetNoiDL
    {
        private static string duongDan = "Data Source=NờTêPê\\THAIPHONG;Initial Catalog=QLTVS;Integrated Security=True;Encrypt=False";

        public static SqlConnection KetNoi()
        {
            return new SqlConnection(duongDan);
        }

        public static DataTable GetTable(string sql)
        {
            using (SqlConnection con = KetNoi())
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                return dt;
            }
        }

        // Thêm , sửa , xoá
        public static bool AddEditDelete(string sql, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = KetNoi())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);

                    // Thêm các tham số vào câu lệnh SQL
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return false;
            }
        }


        public static bool TrungLap(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection con = KetNoi())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                // Thêm các tham số vào câu lệnh SQL
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                int result = (int)cmd.ExecuteScalar(); // Trả về số lượng bản ghi tìm thấy
                return result > 0; // Nếu kết quả > 0 thì có bản ghi trùng lặp
            }
        }



        public static SqlDataReader LayDuLieu(string sql)
        {
            SqlConnection con = KetNoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static DataTable TimKiemm(string sql, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = KetNoi())
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(sql, con);
                // Thêm các tham số vào câu lệnh SQL  
                if (parameters != null)
                {
                    ad.SelectCommand.Parameters.AddRange(parameters);
                }

                DataTable dt = new DataTable();
                ad.Fill(dt);
                return dt;
            }
        }
       


    }
}

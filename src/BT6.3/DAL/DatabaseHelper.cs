using System.Data;
using Microsoft.Data.SqlClient;

namespace BT6._3.DAL
{
    // Lớp hỗ trợ kết nối SQL Server (dùng chung cho các lớp DAL)
    public static class DatabaseHelper
    {
        // Sửa "Data Source" nếu SQL Server trên máy có tên khác
        public static string ConnectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=ProjectTaskDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // Mô hình ngắt kết nối: SqlDataAdapter tự mở/đóng kết nối và đổ dữ liệu vào DataTable
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddRange(thamSo);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(thamSo);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] thamSo)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(thamSo);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}

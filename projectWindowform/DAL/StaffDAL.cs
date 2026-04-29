using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;


namespace projectWindowform.DAL
{
    public class StaffDAL
    {
        private DataProvider dp = new DataProvider();

        public bool CheckLogin(string tenDangNhap, string matKhau)
        {
            string query = "SELECT COUNT(*) FROM Staff WHERE TenDangNhap = @tenDangNhap AND MatKhau = @matKhau";
            object result = dp.ExecuteScalar(query, new object[] { tenDangNhap, matKhau });
            int count = Convert.ToInt32(result);
            return count > 0;
        }

        public DataTable GetStaff(string username)
        {
            string query = "SELECT * FROM Staff WHERE TenDangNhap = @username";
            return dp.ExecuteQuery(query, new object[] { username });
        }


    }
}

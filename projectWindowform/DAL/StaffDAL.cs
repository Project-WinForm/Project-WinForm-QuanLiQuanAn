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

        public DataTable GetAllStaff()
        {
            string query = "SELECT * FROM Staff";
            return dp.ExecuteQuery(query);
        }

        public bool InsertStaff(string tenDangNhap, string matKhau, string tenHienThi, string vaiTro)
        {
            string query = @"
        INSERT INTO Staff( TenDangNhap , MatKhau , TenHienThi , VaiTro )
        VALUES( @user , @pass , @display , @role )";

            int result = dp.ExecuteNonQuery(query,
                new object[]
                {
            tenDangNhap,
            matKhau,
            tenHienThi,
            vaiTro
                });

            return result > 0;
        }

        public bool UpdateStaff(int id, string tenHienThi, string vaiTro)
        {
            string query = @" UPDATE Staff SET TenHienThi = @display , VaiTro = @role WHERE Id = @id";

            int result = dp.ExecuteNonQuery(query,
                new object[]
                {
            tenHienThi,
            vaiTro,
            id
                });

            return result > 0;
        }

        public bool DeleteStaff(int id)
        {
            string query = "DELETE FROM Staff WHERE Id = @id";

            int result = dp.ExecuteNonQuery(query,
                new object[] { id });

            return result > 0;
        }

        public bool CheckUsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM Staff WHERE TenDangNhap = @user";

            object result = dp.ExecuteScalar(query,
                new object[] { username });

            int count = Convert.ToInt32(result);

            return count > 0;
        }

        public bool ChangePassword(int id, string newPassword)
        {
            string query = @"
        UPDATE Staff
        SET MatKhau = @pass
        WHERE Id = @id";

            int result = dp.ExecuteNonQuery(query,
                new object[]
                {
            newPassword,
            id
                });

            return result > 0;
        }


        public DataTable SearchStaff(string keyword)
        {
            string query = @"
        SELECT *
        FROM Staff
        WHERE TenHienThi LIKE @keyword";

            return dp.ExecuteQuery(query,
                new object[]
                {
            "%" + keyword + "%"
                });
        }

    }
}

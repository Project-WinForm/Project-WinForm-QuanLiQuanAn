using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectWindowform.DAL;
using projectWindowform.DTO;
using System.Data;

namespace projectWindowform.BLL
{
    public class StaffBLL
    {
        private StaffDAL dal = new StaffDAL();

        // =========================
        // ĐĂNG NHẬP
        // =========================
        public bool Login(string username, string password)
        {
            // validate
            if (string.IsNullOrWhiteSpace(username))
                return false;

            if (string.IsNullOrWhiteSpace(password))
                return false;

            return dal.CheckLogin(username, password);
        }

        // =========================
        // LẤY DANH SÁCH NHÂN VIÊN
        // =========================
        public DataTable GetAll()
        {
            return dal.GetAllStaff();
        }

        // =========================
        // THÊM NHÂN VIÊN
        // =========================
        public bool Insert( Staff user)
        {
            // validate
            if (string.IsNullOrWhiteSpace(user.TenDangNhap))
                return false;

            if (string.IsNullOrWhiteSpace(user.MatKhau))
                return false;

            if (string.IsNullOrWhiteSpace(user.TenHienThi))
                return false;

            // check username tồn tại
            if (dal.CheckUsernameExists(user.TenDangNhap))
                return false;

            return dal.InsertStaff(user.TenDangNhap, user.MatKhau, user.TenHienThi, user.VaiTro);
        }


        // =========================
        // SỬA NHÂN VIÊN
        // =========================
        public bool Update(Staff user)
        {
            if (user.Id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(user.TenDangNhap))
                return false;

            if (string.IsNullOrWhiteSpace(user.TenHienThi))
                return false;

            if (string.IsNullOrWhiteSpace(user.MatKhau))
                return false;

            // Gọi chính xác hàm UpdateStaff của DAL với đúng vị trí 5 tham số đã sửa ở trên
            return dal.UpdateStaff(user.Id, user.TenDangNhap, user.MatKhau, user.TenHienThi, user.VaiTro);
        }


        // XOÁ NHÂN VIÊN

        public bool Delete(int id)
        {
            if (id <= 0)
                return false;

            return dal.DeleteStaff(id);
        }

        
        // KIỂM TRA ADMIN

        public bool IsAdmin(string username)
        {
            DataTable user = dal.GetStaff(username);

            if (user == null || user.Rows.Count == 0)
                return false;

            return user.Rows[0]["VaiTro"].ToString() == "Admin";
        }
    }
}

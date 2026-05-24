using System;
using System.Collections.Generic;
using System.Text;
using projectWindowform.DAL;
using projectWindowform.DTO;

namespace projectWindowform.BLL
{
    public class FoodBLL
    {
        private FoodDAL foodDAL = new FoodDAL();

        // Lấy danh sách món ăn
        public List<Food> GetFoods()
        {
            return foodDAL.GetFoods();
        }

        // Thêm món ăn
        public bool Insert(string tenMon, decimal gia, int danhMucId, string hinhAnh, bool trangThai)
        {
            if (string.IsNullOrWhiteSpace(tenMon)) return false;
                

            if (gia <= 0) return false;

            return foodDAL.Insert(tenMon, gia, danhMucId, hinhAnh, trangThai);
        }

        // Cập nhật món ăn
        public bool Update(int id, string tenMon, decimal gia, int danhMucId, string hinhAnh, bool trangThai)
        {
            if (id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(tenMon))
                return false;


            if (gia <= 0)
                return false;

            return foodDAL.Update(id, tenMon, gia, danhMucId, hinhAnh, trangThai);
        }

        // Xóa món ăn
        public bool Delete(int id)
        {
            if (id <= 0)
                return false ;

            return foodDAL.Delete(id);
        }

        // Lấy món ăn theo danh mục
        public List<Food> GetFoodByCategoryID(int id)
        {
            if (id <= 0)
                throw new Exception("Danh mục không hợp lệ");

            return foodDAL.GetFoodByCategoryID(id);
        }

        public List<Food> SearchFood(string name)
        {
            return foodDAL.SearchFoodByName(name);
        }

        public string KiemTraMonAn(string tenMon, object danhMuc, string giaRaw, object trangThai)
        {
            // 1. Kiểm tra Tên món ăn
            if (string.IsNullOrWhiteSpace(tenMon))
            {
                return "Tên món ăn không được để trống!";
            }

            // 2. Kiểm tra Danh mục
            if (danhMuc == null || string.IsNullOrEmpty(danhMuc.ToString()))
            {
                return "Vui lòng chọn danh mục cho món ăn!";
            }

            // 3. Kiểm tra Giá (Quan trọng để tránh lỗi format)
            if (string.IsNullOrWhiteSpace(giaRaw))
            {
                return "Giá món ăn không được để trống!";
            }

            // Thử chuyển đổi chuỗi Giá sang số thực
            if (!decimal.TryParse(giaRaw, out decimal giaResult))
            {
                return "Giá món ăn phải là con số (không chứa chữ cái hay ký tự lạ)!";
            }

            if (giaResult < 0)
            {
                return "Giá món ăn không được là số âm!";
            }

            // 4. Kiểm tra Trạng thái
            if (trangThai == null || string.IsNullOrEmpty(trangThai.ToString()))
            {
                return "Vui lòng chọn trạng thái món ăn!";
            }

            return ""; // Mọi thứ đều ổn
        }
    }
}
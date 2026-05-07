using System;
using System.Collections.Generic;
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
            if (string.IsNullOrWhiteSpace(tenMon))
                throw new Exception("Tên món không được để trống");

            if (gia <= 0)
                throw new Exception("Giá phải lớn hơn 0");

            return foodDAL.Insert(tenMon, gia, danhMucId, hinhAnh, trangThai);
        }

        // Cập nhật món ăn
        public bool Update(int id, string tenMon, decimal gia, int danhMucId, string hinhAnh, bool trangThai)
        {
            if (id <= 0)
                throw new Exception("Id không hợp lệ");

            if (string.IsNullOrWhiteSpace(tenMon))
                throw new Exception("Tên món không được để trống");

            if (gia <= 0)
                throw new Exception("Giá phải lớn hơn 0");

            return foodDAL.Update(id, tenMon, gia, danhMucId, hinhAnh, trangThai);
        }

        // Xóa món ăn
        public bool Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id không hợp lệ");

            return foodDAL.Delete(id);
        }

        // Lấy món ăn theo danh mục
        public List<Food> GetFoodByCategoryID(int id)
        {
            if (id <= 0)
                throw new Exception("Danh mục không hợp lệ");

            return foodDAL.GetFoodByCategoryID(id);
        }
    }
}
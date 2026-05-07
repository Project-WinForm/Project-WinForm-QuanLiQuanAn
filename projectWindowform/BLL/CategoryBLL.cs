using System;
using System.Collections.Generic;
using projectWindowform.DAL;
using projectWindowform.DTO;

namespace projectWindowform.BLL
{
    public class CategoryBLL
    {
        private CategoryDAL categoryDAL = new CategoryDAL();

        // Lấy danh sách danh mục
        public List<Category> GetCategories()
        {
            return categoryDAL.GetCategories();
        }

        // Thêm danh mục
        public bool Insert(string tenDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(tenDanhMuc))
                throw new Exception("Tên danh mục không được để trống");

            return categoryDAL.Insert(tenDanhMuc);
        }

        // Cập nhật danh mục
        public bool Update(int id, string tenDanhMuc)
        {
            if (id <= 0)
                throw new Exception("Id không hợp lệ");

            if (string.IsNullOrWhiteSpace(tenDanhMuc))
                throw new Exception("Tên danh mục không được để trống");

            return categoryDAL.Update(id, tenDanhMuc);
        }

        // Xóa danh mục
        public bool Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id không hợp lệ");

            return categoryDAL.Delete(id);
        }
    }
}
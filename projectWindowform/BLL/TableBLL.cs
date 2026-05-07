using System;
using System.Collections.Generic;
using projectWindowform.DAL;
using projectWindowform.DTO;

namespace projectWindowform.BLL
{
    public class TableBLL
    {
        private TableDAL tableDAL = new TableDAL();

        // Lấy danh sách bàn
        public List<Table> GetTables()
        {
            return tableDAL.GetTables();
        }

        // Thêm bàn
        public bool Insert(string tenBan, string trangThai)
        {
            if (string.IsNullOrWhiteSpace(tenBan))
                throw new Exception("Tên bàn không được để trống");

            if (string.IsNullOrWhiteSpace(trangThai))
                throw new Exception("Trạng thái không được để trống");

            return tableDAL.Insert(tenBan, trangThai);
        }

        // Cập nhật bàn
        public bool Update(int id, string tenBan, string trangThai)
        {
            if (id <= 0)
                throw new Exception("Id không hợp lệ");

            if (string.IsNullOrWhiteSpace(tenBan))
                throw new Exception("Tên bàn không được để trống");

            if (string.IsNullOrWhiteSpace(trangThai))
                throw new Exception("Trạng thái không được để trống");

            return tableDAL.Update(id, tenBan, trangThai);
        }

        // Xóa bàn
        public bool Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Id không hợp lệ");

            return tableDAL.Delete(id);
        }
    }
}
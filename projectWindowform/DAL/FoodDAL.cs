using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using projectWindowform.DTO;

namespace projectWindowform.DAL
{
    public class FoodDAL
    {
        private DataProvider dp = new DataProvider();

        public List<Food> GetFoods()
        {
            List<Food> foods = new List<Food>();
            // Bổ sung thêm f.HinhAnh vào câu lệnh SELECT
            string query = "SELECT f.Id, f.TenMon, f.Gia, f.DanhMucId, f.HinhAnh, f.TrangThai, c.TenDanhMuc " +
                           "FROM Foods f INNER JOIN Categories c ON f.DanhMucId = c.Id";
            DataTable dataTable = dp.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                Food food = new Food
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenMon = row["TenMon"].ToString(),
                    Gia = Convert.ToDecimal(row["Gia"]),
                    DanhMucId = Convert.ToInt32(row["DanhMucId"]),
                    HinhAnh = row["HinhAnh"].ToString(), // --- ĐÃ BỔ SUNG ĐỂ SỬA LỖI MẤT ẢNH MÓN ---
                    TenDanhMuc = row["TenDanhMuc"].ToString(),
                    TrangThai = Convert.ToBoolean(row["TrangThai"])
                };
                foods.Add(food);
            }
            return foods;
        }

        public bool Insert(string tenMon, decimal gia, int danhMucId, string hinhAnh, bool trangThai)
        {
            string query = "INSERT INTO Foods (TenMon , Gia , DanhMucId , HinhAnh , TrangThai ) VALUES ( @tenMon , @gia , @danhMucId , @hinhAnh , @trangThai )";
            int result = dp.ExecuteNonQuery(query, new object[] { tenMon, gia, danhMucId, hinhAnh, trangThai });
            return result > 0;
        }

        public bool Update(int id, string tenMon, decimal gia, int danhMucId, string hinhAnh, bool trangThai)
        {
            string query = "UPDATE Foods SET TenMon = @tenMon , Gia = @gia , DanhMucId = @danhMucId , HinhAnh = @hinhAnh , TrangThai = @trangThai WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { tenMon, gia, danhMucId, hinhAnh, trangThai, id });
            return result > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Foods WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> foods = new List<Food>();
            // INNER JOIN để lấy kèm theo TenDanhMuc hỗ trợ cho hàm lọc
            string query = "SELECT f.*, c.TenDanhMuc FROM Foods f INNER JOIN Categories c ON f.DanhMucId = c.Id WHERE f.DanhMucId = @id";
            DataTable dataTable = dp.ExecuteQuery(query, new object[] { id });

            foreach (DataRow row in dataTable.Rows)
            {
                Food food = new Food
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenMon = row["TenMon"].ToString(),
                    Gia = Convert.ToDecimal(row["Gia"]),
                    DanhMucId = Convert.ToInt32(row["DanhMucId"]),
                    TenDanhMuc = row["TenDanhMuc"].ToString(), // --- ĐÃ BỔ SUNG ---
                    HinhAnh = row["HinhAnh"].ToString(),
                    TrangThai = Convert.ToBoolean(row["TrangThai"])
                };
                foods.Add(food);
            }
            return foods;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> foods = new List<Food>();
            string query = string.Format("SELECT f.*, c.TenDanhMuc FROM Foods f INNER JOIN Categories c ON f.DanhMucId = c.Id WHERE f.TenMon LIKE N'%{0}%'", name);

            DataTable dataTable = dp.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Food food = new Food
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenMon = row["TenMon"].ToString(),
                    Gia = Convert.ToDecimal(row["Gia"]),
                    DanhMucId = Convert.ToInt32(row["DanhMucId"]),
                    TenDanhMuc = row["TenDanhMuc"].ToString(),
                    HinhAnh = row["HinhAnh"].ToString(),
                    TrangThai = Convert.ToBoolean(row["TrangThai"])
                };
                foods.Add(food);
            }
            return foods;
        }

        public int GetFoodIdByName(string tenMon)
        {
            string query = "SELECT Id FROM Foods WHERE TenMon = @TenMon";
            object result = dp.ExecuteScalar(query, new object[] { tenMon });
            return result != null ? (int)result : 0;
        }
    }
}
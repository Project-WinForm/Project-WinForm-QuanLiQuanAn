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
            string query = "SELECT * FROM Food";
            DataTable dataTable = dp.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Food food = new Food
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenMon = row["TenMon"].ToString(),
                    Gia = Convert.ToDecimal(row["Gia"]),
                    DanhMucId = Convert.ToInt32(row["DanhMucId"]),
                    HinhAnh = row["HinhAnh"].ToString(),
                    TrangThai = Convert.ToBoolean(row["TrangThai"])
                };
                foods.Add(food);
            }
            return foods;
        }

        public bool Insert(string tenMon, decimal gia, int danhMucId, string hinhAnh, bool trangThai)
        {
                string query = "INSERT INTO Food (TenMon, Gia, DanhMucId, HinhAnh, TrangThai) VALUES (@tenMon, @gia, @danhMucId, @hinhAnh, @trangThai)";
                int result = dp.ExecuteNonQuery(query, new object[] { tenMon, gia, danhMucId, hinhAnh, trangThai });
                return result > 0;
        }

        public bool Update(int id, string tenMon, decimal gia, int danhMucId, string hinhAnh, bool trangThai)
        {
            string query = "UPDATE Food SET TenMon = @tenMon, Gia = @gia, DanhMucId = @danhMucId, HinhAnh = @hinhAnh, TrangThai = @trangThai WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { tenMon, gia, danhMucId, hinhAnh, trangThai, id });
            return result > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Food WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> foods = new List<Food>();
            string query = "SELECT * FROM Food WHERE DanhMucId = @id";
            DataTable dataTable = dp.ExecuteQuery(query, new object[] { id });
            foreach (DataRow row in dataTable.Rows)
            {
                Food food = new Food
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenMon = row["TenMon"].ToString(),
                    Gia = Convert.ToDecimal(row["Gia"]),
                    DanhMucId = Convert.ToInt32(row["DanhMucId"]),
                    HinhAnh = row["HinhAnh"].ToString(),
                    TrangThai = Convert.ToBoolean(row["TrangThai"])
                };
                foods.Add(food);
            }
            return foods;
        }

    }
}

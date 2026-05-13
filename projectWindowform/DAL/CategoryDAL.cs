using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using projectWindowform.DTO;

namespace projectWindowform.DAL
{
    public class CategoryDAL
    {
        private DataProvider dp = new DataProvider();
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            string query = "SELECT * FROM Categories";
            DataTable data = dp.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Category category = new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenDanhMuc = row["TenDanhMuc"].ToString()
                };

                categories.Add(category);
            }

            return categories;
        }

        public bool Insert(string tenDanhMuc)
        {
            string query = "INSERT INTO Categories (TenDanhMuc) VALUES (@tenDanhMuc)";
            int result = dp.ExecuteNonQuery(query, new object[] { tenDanhMuc });
            return result > 0;
        }

        public bool Update(int id, string tenDanhMuc)
        {
            string query = "UPDATE Categories SET TenDanhMuc = @tenDanhMuc WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { tenDanhMuc, id });
            return result > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Categories WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }
    }
}

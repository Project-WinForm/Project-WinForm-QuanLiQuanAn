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
            string query = "SELECT * FROM Category";
            DataTable data = dp.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Category category = new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenDanhMuc = row["Name"].ToString()
                };

                categories.Add(category);
            }

            return categories;
        }

        public bool Insert(string tenDanhMuc)
        {
            string query = "INSERT INTO Category (Name) VALUES (@tenDanhMuc)";
            int result = dp.ExecuteNonQuery(query, new object[] { tenDanhMuc });
            return result > 0;
        }

        public bool Update(int id, string tenDanhMuc)
        {
            string query = "UPDATE Category SET Name = @tenDanhMuc WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { tenDanhMuc, id });
            return result > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Category WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }
    }
}

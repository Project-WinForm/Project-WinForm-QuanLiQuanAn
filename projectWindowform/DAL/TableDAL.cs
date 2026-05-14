using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using projectWindowform.DTO;

namespace projectWindowform.DAL
{
    public class TableDAL
    {
        DataProvider dp = new DataProvider();

        public List<Table> GetTables()
        {
            List<Table> tables = new List<Table>();
            string query = "SELECT * FROM [Tables]";
            DataTable dataTable = dp.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Table table = new Table
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenBan = row["TenBan"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
                tables.Add(table);
            }
            return tables;
        }

        public bool Insert(string tenBan, string trangThai)
        {
            string query = "INSERT INTO [Tables] ( TenBan, TrangThai ) VALUES ( @tenBan, @trangThai )";
            int result = dp.ExecuteNonQuery(query, new object[] { tenBan, trangThai });
            return result > 0;
        }

        public bool Update(int id, string tenBan, string trangThai)
        {
            string query = "UPDATE [Tables] SET TenBan = @tenBan, TrangThai = @trangThai WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { tenBan, trangThai, id });
            return result > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM [Tables] WHERE Id = @id";
            int result = dp.ExecuteNonQuery(query, new object[] { id });
            return result > 0;
        }


    }
}

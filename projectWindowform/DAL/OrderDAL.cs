using projectWindowform.DAL;
using System.Collections.Generic;
using System.Data;
using tieuluan.DTO;

namespace tieuluan.DAL
{
    public class OrderDAL
    {
        private DataProvider _db = new DataProvider();

        public List<OrderItem> GetOrders(string tableName)
        {
            var result = new List<OrderItem>();
            string query = "SELECT FoodName , Price , Quantity FROM Orders WHERE TableName = @TableName ";
            DataTable dt = _db.ExecuteQuery(query, new object[] { tableName });

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new OrderItem
                {
                    FoodName = row["FoodName"].ToString(),
                    Price = (int)row["Price"],
                    Quantity = (int)row["Quantity"]
                });
            }
            return result;
        }

        public void EnsureTableExists(string tableName)
        {
            // Không cần nữa vì SQL Server tự quản lý
            // Có thể để trống hoặc xóa
        }

        public void InsertFood(string tableName, OrderItem item)
        {
            string query = "INSERT INTO Orders ( TableName , FoodName , Price , Quantity ) " +
                           "VALUES ( @TableName , @FoodName , @Price , @Quantity )";
            _db.ExecuteNonQuery(query, new object[] { tableName, item.FoodName, item.Price, item.Quantity });
        }

        public void UpdateQuantity(string tableName, string foodName, int additionalQuantity)
        {
            string query = "UPDATE Orders SET Quantity = Quantity + @additionalQuantity " +
                           "WHERE TableName = @TableName AND FoodName = @FoodName";
            _db.ExecuteNonQuery(query, new object[] { additionalQuantity, tableName, foodName });
        }

        public void DeleteFood(string tableName, string foodName)
        {
            string query = "DELETE FROM Orders WHERE TableName = @TableName AND FoodName = @FoodName";
            _db.ExecuteNonQuery(query, new object[] { tableName, foodName });
        }

        public void ClearTable(string tableName)
        {
            string query = "DELETE FROM Orders WHERE TableName = @TableName";
            _db.ExecuteNonQuery(query, new object[] { tableName });
        }

        public bool CheckOrderExists(string tableName)
        {
            string query = "SELECT COUNT(*) FROM Orders WHERE TableName = @TableName";
            int count = (int)_db.ExecuteScalar(query, new object[] { tableName });
            return count > 0;
        }

        public int GetOccupiedTableCount()
        {
            string query = "SELECT COUNT(DISTINCT TableName) FROM Orders";
            return (int)_db.ExecuteScalar(query, null);
        }
    }
}
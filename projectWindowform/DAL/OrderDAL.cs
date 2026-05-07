using System.Collections.Generic;
using tieuluan.DTO;

namespace tieuluan.DAL
{
    public class OrderDAL
    {
        // Biến static đóng vai trò như Database lưu trữ dữ liệu các bàn
        private static Dictionary<string, List<OrderItem>> _databaseOrders = new Dictionary<string, List<OrderItem>>();

        public List<OrderItem> GetOrders(string tableName)
        {
            if (_databaseOrders.ContainsKey(tableName))
            {
                return _databaseOrders[tableName];
            }
            return new List<OrderItem>();
        }

        public void EnsureTableExists(string tableName)
        {
            if (!_databaseOrders.ContainsKey(tableName))
            {
                _databaseOrders[tableName] = new List<OrderItem>();
            }
        }

        public void InsertFood(string tableName, OrderItem item)
        {
            _databaseOrders[tableName].Add(item);
        }

        public void UpdateQuantity(string tableName, string foodName, int additionalQuantity)
        {
            var currentBill = _databaseOrders[tableName];
            foreach (var item in currentBill)
            {
                if (item.FoodName == foodName)
                {
                    item.Quantity += additionalQuantity;
                    break;
                }
            }
        }

        public void DeleteFood(string tableName, string foodName)
        {
            if (_databaseOrders.ContainsKey(tableName))
            {
                _databaseOrders[tableName].RemoveAll(x => x.FoodName == foodName);
                // Nếu bàn trống thì xóa luôn bill khỏi database
                if (_databaseOrders[tableName].Count == 0)
                {
                    _databaseOrders.Remove(tableName);
                }
            }
        }

        public void ClearTable(string tableName)
        {
            if (_databaseOrders.ContainsKey(tableName))
            {
                _databaseOrders.Remove(tableName);
            }
        }

        public bool CheckOrderExists(string tableName)
        {
            return _databaseOrders.ContainsKey(tableName) && _databaseOrders[tableName].Count > 0;
        }

        // ==========================================
        // HÀM MỚI BỔ SUNG: Đếm số lượng bàn có khách
        // ==========================================
        public int GetOccupiedTableCount()
        {
            // Do hàm DeleteFood và ClearTable đã dọn dẹp sạch các bàn trống
            // Nên chỉ cần đếm số lượng key trong Dictionary là ra số bàn đang có khách
            return _databaseOrders.Count;
        }
    }
}
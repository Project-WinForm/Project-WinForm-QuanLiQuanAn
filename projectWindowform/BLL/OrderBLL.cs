using System.Collections.Generic;
using tieuluan.DAL;
using tieuluan.DTO;

namespace tieuluan.BLL
{
    public class OrderBLL
    {
        private OrderDAL _orderDAL = new OrderDAL();

        public List<OrderItem> GetBill(string tableName)
        {
            return _orderDAL.GetOrders(tableName);
        }

        public void AddFood(string tableName, string foodName, int price, int quantity)
        {
            // 1. Đảm bảo bàn đã được khởi tạo trong "Database"
            _orderDAL.EnsureTableExists(tableName);

            // 2. Lấy bill hiện tại để kiểm tra logic
            var currentBill = _orderDAL.GetOrders(tableName);
            bool isExists = false;

            // Nghiệp vụ: Quét xem món này đã gọi trước đó chưa
            foreach (var item in currentBill)
            {
                if (item.FoodName == foodName)
                {
                    // Đã tồn tại -> Gọi DAL cập nhật số lượng
                    _orderDAL.UpdateQuantity(tableName, foodName, quantity);
                    isExists = true;
                    break;
                }
            }

            // Nghiệp vụ: Món mới hoàn toàn -> Gọi DAL thêm dòng mới
            if (!isExists)
            {
                OrderItem newItem = new OrderItem { FoodName = foodName, Price = price, Quantity = quantity };
                _orderDAL.InsertFood(tableName, newItem);
            }
        }

        public void RemoveFood(string tableName, string foodName)
        {
            // Logic có thể mở rộng ở đây (VD: chỉ cho phép quản lý xóa, v.v.), hiện tại chỉ gọi DAL
            _orderDAL.DeleteFood(tableName, foodName);
        }

        public void Checkout(string tableName)
        {
            _orderDAL.ClearTable(tableName);
        }

        public bool HasOrder(string tableName)
        {
            return _orderDAL.CheckOrderExists(tableName);
        }
    }
}
using projectWindowform.DAL;
using projectWindowform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using tieuluan.DAL;
using tieuluan.DTO;

namespace tieuluan.BLL
{
    public class OrderBLL
    {
        private OrderDAL _orderDAL = new OrderDAL();
        private BillDAL _billDAL = new BillDAL();
        private FoodDAL _foodDAL = new FoodDAL();

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

        public void Checkout(string tableName , int tableId)
        {
            // Lấy danh sách món hiện tại
            var currentBill = _orderDAL.GetOrders(tableName);
            decimal tongTien = currentBill.Sum(x => x.Price * x.Quantity);

            var bill = new Bill
            {
                TableId = tableId,
                ThoiGianMo = DateTime.Now,
                ThoiGianDong = DateTime.Now,
                TongTien = tongTien,
                TrangThai = true
            };

            var details = new List<BillDetail>();
            foreach (var item in currentBill)
            {
                // Tra FoodId từ DB bằng FoodName
                int foodId = _foodDAL.GetFoodIdByName(item.FoodName);

                details.Add(new BillDetail
                {
                    FoodId = foodId,
                    SoLuong = item.Quantity,
                    DonGia = item.Price
                });
            }

            _billDAL.SaveBill(bill, details);
            _orderDAL.ClearTable(tableName);
        }

        public bool HasOrder(string tableName)
        {
            return _orderDAL.CheckOrderExists(tableName);
        }

        // 6. Đếm số lượng bàn đang có khách (Nhờ DAL đếm)
        public int GetOccupiedTableCount()
        {
            return _orderDAL.GetOccupiedTableCount();
        }

        // 7. Đếm số lượng bàn trống
        public int GetEmptyTableCount(int totalTables)
        {
            // Lấy tổng số bàn trừ đi số bàn đang có khách (lấy từ DAL)
            return totalTables - _orderDAL.GetOccupiedTableCount();
        }
    }
}
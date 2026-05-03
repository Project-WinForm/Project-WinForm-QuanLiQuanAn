using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tiểu_luận.Models;

namespace tiểu_luận.Services
{
    public class OrderService
    {
        // Đây là trái tim của hệ thống: Biến _tableOrders được dời từ Form1 sang đây
        // Nó sẽ tự động ghi nhớ Bàn nào đang gọi những món gì
        private Dictionary<string, List<OrderItem>> _tableOrders = new Dictionary<string, List<OrderItem>>();

        // 1. Hàm lấy danh sách món ăn của một bàn (để in ra màn hình)
        public List<OrderItem> GetBill(string tableName)
        {
            if (_tableOrders.ContainsKey(tableName))
            {
                return _tableOrders[tableName]; // Trả về danh sách món nếu bàn có khách
            }
            return new List<OrderItem>(); // Trả về danh sách rỗng nếu bàn trống
        }

        // 2. Hàm xử lý logic Thêm món (Cộng dồn số lượng nếu trùng món)
        public void AddFood(string tableName, string foodName, int price, int quantity)
        {
            // Nếu bàn chưa có ai ngồi, mở một bill mới cho bàn đó
            if (!_tableOrders.ContainsKey(tableName))
            {
                _tableOrders[tableName] = new List<OrderItem>();
            }

            var currentBill = _tableOrders[tableName];
            bool isExists = false;

            // Quét xem món này đã gọi trước đó chưa
            foreach (var item in currentBill)
            {
                if (item.FoodName == foodName)
                {
                    item.Quantity += quantity; // Nếu gọi rồi thì cộng thêm số lượng
                    isExists = true;
                    break;
                }
            }

            // Nếu là món mới hoàn toàn thì thêm một dòng mới vào bill
            if (!isExists)
            {
                currentBill.Add(new OrderItem { FoodName = foodName, Price = price, Quantity = quantity });
            }
        }

        // 3. Hàm xử lý logic Xóa món
        public void RemoveFood(string tableName, string foodName)
        {
            if (_tableOrders.ContainsKey(tableName))
            {
                var currentBill = _tableOrders[tableName];

                // Xóa món ăn có tên tương ứng
                currentBill.RemoveAll(x => x.FoodName == foodName);

                // Nếu xóa hết sạch các món, thì xóa luôn bill để trả lại bàn trống
                if (currentBill.Count == 0)
                {
                    _tableOrders.Remove(tableName);
                }
            }
        }

        // 4. Hàm xử lý logic Thanh toán (Giải phóng bàn)
        public void Checkout(string tableName)
        {
            if (_tableOrders.ContainsKey(tableName))
            {
                _tableOrders.Remove(tableName);
            }
        }

        // 5. Hàm kiểm tra xem bàn đang Trống hay Có khách
        public bool HasOrder(string tableName)
        {
            return _tableOrders.ContainsKey(tableName) && _tableOrders[tableName].Count > 0;
        }
    }
}

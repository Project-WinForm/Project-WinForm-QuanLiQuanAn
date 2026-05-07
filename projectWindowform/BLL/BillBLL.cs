using System;
using System.Data;
using projectWindowform.DAL;

namespace projectWindowform.BLL
{
    public class BillBLL
    {
        private BillDAL billDAL = new BillDAL();

        // Tạo hóa đơn mới
        public int CreateBill(int tableId)
        {
            if (tableId <= 0)
                throw new Exception("Id bàn không hợp lệ");

            return billDAL.CreateBill(tableId);
        }

        // Lấy hóa đơn theo bàn
        public int GetBillByTableId(int tableId)
        {
            if (tableId <= 0)
                throw new Exception("Id bàn không hợp lệ");

            return billDAL.GetBillByTableId(tableId);
        }

        // Thêm món vào hóa đơn
        public void AddFoodToBill(int billId, int foodId, int quantity)
        {
            if (billId <= 0 || foodId <= 0)
                throw new Exception("Id không hợp lệ");

            if (quantity <= 0)
                throw new Exception("Số lượng phải lớn hơn 0");

            billDAL.AddFoodToBill(billId, foodId, quantity);
        }

        // Lấy chi tiết hóa đơn
        public DataTable GetBillDetails(int billId)
        {
            if (billId <= 0)
                throw new Exception("Id hóa đơn không hợp lệ");

            return billDAL.GetBillDetails(billId);
        }

        // Thanh toán hóa đơn
        public void CheckOut(int billId)
        {
            if (billId <= 0)
                throw new Exception("Id hóa đơn không hợp lệ");

            billDAL.CheckOut(billId);
        }

        // Cập nhật tổng tiền hóa đơn
        public void UpdateTotalBill(int billId)
        {
            if (billId <= 0)
                throw new Exception("Id hóa đơn không hợp lệ");

            billDAL.UpdateTotalBill(billId);
        }

        // Giảm giá hóa đơn
        public void ApplyDiscount(int billId, decimal percent)
        {
            if (billId <= 0)
                throw new Exception("Id hóa đơn không hợp lệ");

            if (percent < 0 || percent > 100)
                throw new Exception("Phần trăm giảm giá không hợp lệ");

            billDAL.ApplyDiscount(billId, percent);
        }
    }
}
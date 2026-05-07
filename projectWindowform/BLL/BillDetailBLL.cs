using System;
using System.Data;
using projectWindowform.DAL;

namespace projectWindowform.BLL
{
    public class BillDetailBLL
    {
        private BillDetailDAL billDetailDAL = new BillDetailDAL();

        // Thêm món vào hóa đơn
        public void AddFoodToBill(int billId, int foodId, int quantity)
        {
            if (billId <= 0 || foodId <= 0)
                throw new Exception("Id không hợp lệ");

            if (quantity <= 0)
                throw new Exception("Số lượng phải lớn hơn 0");

            billDetailDAL.AddFoodToBill(billId, foodId, quantity);
        }

        // Lấy danh sách món theo hóa đơn
        public DataTable GetListByBill(int billId)
        {
            if (billId <= 0)
                throw new Exception("Id hóa đơn không hợp lệ");

            return billDetailDAL.GetListByBill(billId);
        }

        // Xóa chi tiết hóa đơn
        public void DeleteBillDetails(int billDetailsId)
        {
            if (billDetailsId <= 0)
                throw new Exception("Id chi tiết hóa đơn không hợp lệ");

            billDetailDAL.DeleteBillDetails(billDetailsId);
        }

        // Cập nhật số lượng món ăn
        public void UpdateQuantity(int billDetailsId, int newQuantity)
        {
            if (billDetailsId <= 0)
                throw new Exception("Id chi tiết hóa đơn không hợp lệ");

            billDetailDAL.UpdateQuantity(billDetailsId, newQuantity);
        }
    }
}
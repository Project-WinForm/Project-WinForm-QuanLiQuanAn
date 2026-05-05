using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectWindowform.DTO;

namespace projectWindowform.DAL
{
    public class BillDetailDAL
    {
        private DataProvider dp = new DataProvider();

        public void AddFoodToBill(int billId, int foodId, int quantity) // Thêm món vào hóa đơn, nếu đã tồn tại thì cập nhật số lượng
        {
            string check = "SELECT Id, SoLuong FROM BillDetails WHERE BillId = @billId AND FoodId = @foodId";
            DataTable data = dp.ExecuteQuery(check, new object[] { billId, foodId });

            if (data.Rows.Count > 0)
            {
                int currentQty = (int)data.Rows[0]["SoLuong"];
                int newQty = currentQty + quantity;

                string update = "UPDATE BillDetails SET SoLuong = @qty WHERE Id = @id";
                dp.ExecuteNonQuery(update, new object[] { newQty, data.Rows[0]["Id"] });
            }
            else
            {
                string insert = @"
            INSERT INTO BillDetails(BillId, FoodId, SoLuong, DonGia)
            VALUES (@billId, @foodId, @qty, (SELECT Gia FROM Foods WHERE Id = @foodId))";

                dp.ExecuteNonQuery(insert, new object[] { billId, foodId, quantity });
            }
        }

        public DataTable GetListByBill(int billId)
        {
            string query = @"
                SELECT f.TenMon, bd.SoLuong, bd.DonGia, (bd.SoLuong * bd.DonGia) AS ThanhTien
                FROM BillDetails bd
                JOIN Foods f ON bd.FoodId = f.Id
                WHERE bd.BillId = @billId";
            return dp.ExecuteQuery(query, new object[] { billId });
        }

        public void DeleteBillDetails(int billDetailsId)
        {
            string query = "DELETE FROM BillDetails WHERE Id = @billDetailsId";
            dp.ExecuteNonQuery(query, new object[] { billDetailsId });
        }
        public void UpdateQuantity(int billDetailsId, int newQuantity)
        {
            if( newQuantity <= 0)
            {
                DeleteBillDetails(billDetailsId);
                return;
            }
            else
            {
                string query = "UPDATE BillDetails SET SoLuong = @newQuantity WHERE Id = @billDetailsId";
                dp.ExecuteNonQuery(query, new object[] { newQuantity, billDetailsId });
            }

        }
         
    }
}

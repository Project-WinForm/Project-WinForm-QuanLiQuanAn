using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using projectWindowform.DTO;

namespace projectWindowform.DAL
{
    public class BillDAL
    {
        DataProvider dp = new DataProvider();

        public int CreateBill(int tableId) // Tạo hóa đơn mới và trả về Id của hóa đơn đó
        {
            string query = "INSERT INTO Bill (TableId, DateCheckIn) VALUES (@tableId, GETDATE()); SELECT SCOPE_IDENTITY();";
            object result = dp.ExecuteScalar(query, new object[] { tableId });
            return Convert.ToInt32(result);
        }

        public int GetBillByTableId(int tableId) // Lấy Id của hóa đơn theo Id bàn
        {
            string query = "SELECT TOP 1 Id FROM Bill WHERE TableId = @tableId AND DateCheckOut IS NULL ORDER BY DateCheckIn DESC";
            object result = dp.ExecuteScalar(query, new object[] { tableId });
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public void AddFoodToBill2(int billId, int foodId, int quantity)
        {
            string query = "INSERT INTO BillInfo (BillId, FoodId, Quantity) VALUES (@billId, @foodId, @quantity)";
            dp.ExecuteNonQuery(query, new object[] { billId, foodId, quantity });
        }

        public void AddFoodToBill(int billId, int foodId, int quantity)
        {
            string query = "SELECT Id, SoLuong FROM BillDetails WHERE BillId = @billId AND FoodId = @foodId";

            DataTable data = dp.ExecuteQuery(query, new object[] { billId, foodId });

            if (data.Rows.Count > 0)
            {
                int billDetailsId = Convert.ToInt32(data.Rows[0]["Id"]);
                int SoLuong = Convert.ToInt32(data.Rows[0]["SoLuong"]);
                int newQuantity = SoLuong + quantity;
                string updateQuery = "UPDATE BillDetails SET SoLuong = @newQuantity WHERE Id = @billDetailsId";
                dp.ExecuteNonQuery(updateQuery, new object[] { newQuantity, billDetailsId });
            }
            else
            {
                string insertQuery = "INSERT INTO BillDetails (BillId, FoodId, SoLuong) VALUES (@billId, @foodId, @quantity)";
                dp.ExecuteNonQuery(insertQuery, new object[] { billId, foodId, quantity });
            }
        }

        public DataTable GetBillDetails(int billId)
        {
            string query = @"
                                SELECT f.TenMon, bd.SoLuong, bd.DonGia, (bd.SoLuong * bd.DonGia) AS ThanhTien
                                FROM BillDetails bd
                                JOIN Foods f ON bd.FoodId = f.Id
                                WHERE bd.BillId = @billId";
            return dp.ExecuteQuery(query, new object[] { billId });
        }

        public void CheckOut(int billId)
        {
            string query = @"
                                UPDATE Bills SET TrangThai = 1, ThoiGianDong = GETDATE(),
                                    TongTien = (
                                        SELECT SUM(SoLuong * DonGia)
                                        FROM BillDetails
                                        WHERE BillId = @billId
                                    )
                                WHERE Id = @billId";
            dp.ExecuteNonQuery(query, new object[] { billId });
        }

        public void UpdateTotalBill(int billDetailsId)
        {
            string query = @"
                                UPDATE Bills
                                SET TongTien = (
                                    SELECT ISNULL(SUM(SoLuong * DonGia), 0)
                                    FROM BillDetails
                                    WHERE BillId = @billId
                                )
                                WHERE Id = @billId";
            dp.ExecuteNonQuery(query, new object[] { billDetailsId });
        }

        public void ApplyDiscount(int billId, decimal percent)
        {
            string query = @"
                                UPDATE Bills
                                SET TongTien = TongTien - (TongTien * @percent / 100)
                                WHERE Id = @billId";

            dp.ExecuteNonQuery(query, new object[] { percent, billId });
        }
    }
}

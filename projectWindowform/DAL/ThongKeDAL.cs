using System.Data;

namespace projectWindowform.DAL
{
    public class ThongKeDAL
    {
        DataProvider dp = new DataProvider();

        public object GetTongDoanhThu(object from, object to)
        {
            string query = @" SELECT ISNULL ( SUM ( TongTien ) , 0 ) FROM Bills WHERE ThoiGianDong BETWEEN @from AND @to";

            return dp.ExecuteScalar(query, new object[] { from, to });
        }

        public object GetTongHoaDon(object from, object to)
        {
            string query = @" SELECT COUNT(*) FROM Bills WHERE ThoiGianDong BETWEEN @from AND @to";

            return dp.ExecuteScalar(query, new object[] { from, to });
        }

        public object GetTongMon(object from, object to)
        {
            string query = @" SELECT ISNULL ( SUM ( SoLuong ) , 0 ) FROM BillDetails bd INNER JOIN Bills b ON bd.BillId = b.Id WHERE b.ThoiGianDong BETWEEN @from AND @to";

            return dp.ExecuteScalar(query, new object[] { from, to });
        }

        public DataTable GetDanhSachHoaDon(object from, object to)
        {
            string query = @" SELECT b.Id , t.TenBan AS TenBan , b.ThoiGianMo , b.ThoiGianDong , b.TongTien FROM Bills b JOIN Tables t ON b.TableId = t.Id WHERE b.ThoiGianDong BETWEEN @from AND @to ";

            return dp.ExecuteQuery(query, new object[] { from, to });
        }

        public DataTable GetDoanhThuTheoNgay(object from, object to)
        {
            string query = @" SELECT CONVERT ( date , ThoiGianDong ) Ngay , SUM(TongTien) DoanhThu FROM Bills WHERE ThoiGianDong BETWEEN @from AND @to GROUP BY CONVERT( date , ThoiGianDong)";

            return dp.ExecuteQuery(query, new object[] { from, to });
        }

        public DataTable GetTopMonBanChay(object from, object to)
        {
            string query = @"SELECT TOP 5 f.TenMon , SUM( bd.SoLuong ) TongBan FROM BillDetails bd INNER JOIN Foods f ON bd.FoodId = f.Id INNER JOIN Bills b ON bd.BillId = b.Id WHERE b.ThoiGianDong BETWEEN @from AND @to GROUP BY f.TenMon ORDER BY TongBan DESC";

            return dp.ExecuteQuery(query, new object[] { from, to });
        }

        public DataTable GetChiTietHoaDonDayDu(object from, object to)
        {
            string query = @" SELECT b.Id AS [Mã HD] , f.TenMon AS [Tên Món] , bd.SoLuong AS [Số Lượng] , f.Gia AS [Đơn Giá] , (bd.SoLuong * f.Gia) AS [Thành Tiền] , b.ThoiGianDong AS [Ngày Thanh Toán] FROM Bills b  JOIN BillDetails bd ON b.Id = bd.BillId  JOIN Foods f ON bd.FoodId = f.Id WHERE b.ThoiGianDong BETWEEN @from AND @to ORDER BY b.Id ASC";

            return dp.ExecuteQuery(query, new object[] { from, to });
        }
    }
}
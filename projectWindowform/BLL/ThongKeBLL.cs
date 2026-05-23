using projectWindowform.DAL;
using System;
using System.Data;

namespace projectWindowform.BLL
{
    public class ThongKeBLL
    {
        ThongKeDAL thongKeDAL = new ThongKeDAL();

        public decimal TongDoanhThu(DateTime from, DateTime to)
        {
            return Convert.ToDecimal(
                thongKeDAL.GetTongDoanhThu(from, to));
        }

        public int TongHoaDon(DateTime from, DateTime to)
        {
            return Convert.ToInt32(
                thongKeDAL.GetTongHoaDon(from, to));
        }

        public int TongMon(DateTime from, DateTime to)
        {
            return Convert.ToInt32(
                thongKeDAL.GetTongMon(from, to));
        }

        public DataTable DanhSachHoaDon(DateTime from, DateTime to)
        {
            return thongKeDAL.GetDanhSachHoaDon(from, to);
        }

        public DataTable DoanhThuTheoNgay(DateTime from, DateTime to)
        {
            return thongKeDAL.GetDoanhThuTheoNgay(from, to);
        }

        public DataTable TopMonBanChay(DateTime from, DateTime to)
        {
            return thongKeDAL.GetTopMonBanChay(from, to);
        }

        public DataSet GetDuLieuTongQuat(DateTime from, DateTime to)
        {
            DataSet ds = new DataSet();

            // 1. Bảng thông tin tổng hợp
            DataTable dtSummary = new DataTable("Summary");
            dtSummary.Columns.Add("TieuDe");
            dtSummary.Columns.Add("GiaTri");
            dtSummary.Rows.Add("Tổng doanh thu", thongKeDAL.GetTongDoanhThu(from, to));
            dtSummary.Rows.Add("Tổng hóa đơn", thongKeDAL.GetTongHoaDon(from, to));
            dtSummary.Rows.Add("Tổng món đã bán",   thongKeDAL.GetTongMon(from, to));
            ds.Tables.Add(dtSummary);

            // 2. Bảng danh sách hóa đơn (lấy từ DAL của bạn)
            DataTable dtBills = thongKeDAL.GetDanhSachHoaDon(from, to);
            dtBills.TableName = "DanhSachHoaDon";
            ds.Tables.Add(dtBills.Copy());

            return ds;
        }

        // Xuất chi tiết: Cần viết thêm 1 hàm ở DAL để lấy chi tiết từng món trong các hóa đơn
        public DataTable GetDuLieuChiTiet(DateTime from, DateTime to)
        {
            // Bạn nên viết thêm 1 hàm DAL.GetChiTietMonAnDaBan(from, to) 
            // để biết cụ thể mỗi hóa đơn gồm những món gì, số lượng bao nhiêu
            return thongKeDAL.GetChiTietHoaDonDayDu(from, to);
        }


    }
}
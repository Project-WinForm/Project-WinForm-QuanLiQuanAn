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
    }
}
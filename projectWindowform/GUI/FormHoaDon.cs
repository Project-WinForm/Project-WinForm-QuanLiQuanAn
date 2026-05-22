using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using tieuluan.DTO; // Đảm bảo namespace này trùng khớp với file chứa cấu trúc dữ liệu OrderItem của bạn

namespace projectWindowform
{
    public partial class FormHoaDon : Form
    {
        private string _tenBan;
        private List<OrderItem> _listMon;
        private int _tongTien;
        private string _thoiGianIn; // Biến giữ cố định thời gian in, tránh bị nhảy giây khi bấm Print Preview

        // Hàm khởi tạo nhận dữ liệu từ Form chính truyền sang
        public FormHoaDon(string tenBan, List<OrderItem> listMon, int tongTien)
        {
            InitializeComponent();
            this._tenBan = tenBan;
            this._listMon = listMon;
            this._tongTien = tongTien;

            // Thiết lập cố định chuỗi thời gian ngay khi mở hóa đơn
            this._thoiGianIn = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Ép form xuất hiện ngay chính giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            // Cấu hình hiển thị dòng đầy đủ cho ListView (phòng trường hợp thuộc tính Designer chưa nhận)
            lsvChiTietHD.View = View.Details;
            lsvChiTietHD.FullRowSelect = true;

            // Gán dữ liệu chữ lên các Label thông tin chung
            lblTenBan.Text = "Bàn: " + _tenBan;
            lblThoiGian.Text = "Thời gian: " + _thoiGianIn;

            // Đổ danh sách món ăn từ bàn vào ListView trên giao diện
            lsvChiTietHD.Items.Clear();
            foreach (var item in _listMon)
            {
                // Cột 1: Tên món kèm số lượng
                ListViewItem lsvItem = new ListViewItem($"{item.FoodName} (x{item.Quantity})");

                // Cột 2: Thành tiền của món đó
                lsvItem.SubItems.Add(item.Total.ToString("N0") + " VNĐ");

                lsvChiTietHD.Items.Add(lsvItem);
            }

            // Hiển thị tổng tiền tổng cộng lên giao diện hóa đơn
            lblTongTien.Text = _tongTien.ToString("N0") + " VNĐ";
        }

        // Sự kiện nút ĐÓNG (Màu đỏ)
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sự kiện nút IN HÓA ĐƠN (Màu xanh) -> Bật khung xem trước bản in nhiệt
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage_Format);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;

            // Cấu hình cửa sổ xem trước hiển thị cân đối
            ppd.WindowState = FormWindowState.Normal;
            ppd.StartPosition = FormStartPosition.CenterScreen;
            ppd.Width = 550;
            ppd.Height = 750;

            ppd.ShowDialog();
        }

        // Logic thiết kế bố cục tờ giấy in nhiệt thực tế cho nhà hàng HANSIM
        private void PrintPage_Format(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Khai báo Font chữ hóa đơn chuyên dụng (Sử dụng Courier New để các ký tự căn lề thẳng hàng)
            Font fTitle = new Font("Courier New", 16, FontStyle.Bold);
            Font fHeader = new Font("Courier New", 12, FontStyle.Bold);
            Font fBody = new Font("Courier New", 11, FontStyle.Regular);

            float x = 40;
            float y = 40;
            float lineSpacing = 25;

            // 1. Vẽ Tiêu đề nhà hàng
            g.DrawString("     HANSIM 한심     ", fTitle, Brushes.Black, x, y);
            y += 35;
            g.DrawString("  HÓA ĐƠN THANH TOÁN  ", fHeader, Brushes.Black, x, y);
            y += 40;

            // 2. Vẽ thông tin bàn và thời gian cố định
            g.DrawString($"Bàn: {_tenBan}", fBody, Brushes.Black, x, y);
            y += lineSpacing;
            g.DrawString($"Thời gian: {_thoiGianIn}", fBody, Brushes.Black, x, y);
            y += lineSpacing;
            g.DrawString("Thu Ngân: Nhân Viên", fBody, Brushes.Black, x, y);
            y += 30;

            // 3. Đường kẻ phân cách phần đầu
            g.DrawString("-----------------------------------------", fBody, Brushes.Black, x, y);
            y += 20;

            // 4. Tiêu đề các cột dữ liệu
            g.DrawString("Dịch vụ", fHeader, Brushes.Black, x, y);
            g.DrawString("Thành tiền", fHeader, Brushes.Black, x + 210, y);
            y += 25;
            g.DrawString("-----------------------------------------", fBody, Brushes.Black, x, y);
            y += 20;

            // 5. Vòng lặp vẽ danh sách món ăn ra bản in
            foreach (var item in _listMon)
            {
                string infoMon = $"{item.FoodName} (x{item.Quantity})";
                string tienMon = item.Total.ToString("N0") + " VNĐ";

                // Cắt chữ nếu tên món quá dài tránh đè lấn sang cột hiển thị tiền
                if (infoMon.Length > 20)
                {
                    infoMon = infoMon.Substring(0, 17) + "..";
                }

                g.DrawString(infoMon, fBody, Brushes.Black, x, y);
                g.DrawString(tienMon, fBody, Brushes.Black, x + 210, y);
                y += lineSpacing;
            }

            // 6. Đường kẻ phân cách phần đuôi
            g.DrawString("-----------------------------------------", fBody, Brushes.Black, x, y);
            y += 25;

            // 7. In tổng tiền thanh toán (Đẩy lề x + 210 để không bị tràn khung chữ)
            g.DrawString("TỔNG CỘNG:", fHeader, Brushes.Black, x, y);
            g.DrawString(_tongTien.ToString("N0") + " VNĐ", fHeader, Brushes.Black, x + 210, y);
            y += 50;

            // 8. Chân trang hóa đơn mang thông điệp nhà hàng
            g.DrawString("   Cảm ơn quý khách và hẹn gặp lại!   ", fBody, Brushes.Black, x, y);
        }
    }
}
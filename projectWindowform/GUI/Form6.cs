using projectWindowform.BLL;
using Sunny.UI;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace projectWindowform.GUI
{
    public partial class Form6 : Form
    {
        ThongKeBLL thongKeBLL = new ThongKeBLL();

        public Form6()
        {
            InitializeComponent();

            
        }
        private void DinhDangBang()
        {
            // Kiểm tra nếu chưa có cột nào thì thoát hàm để tránh lỗi NullReference
            if (uiDataGridView1.Columns.Count == 0) return;

            try
            {
                // Định dạng Header và Tên cột
                uiDataGridView1.Columns["Id"].HeaderText = "Mã HD";
                uiDataGridView1.Columns["TenBan"].HeaderText = "Bàn";
                uiDataGridView1.Columns["ThoiGianMo"].HeaderText = "Giờ Mở Hoá Đơn";
                uiDataGridView1.Columns["ThoiGianDong"].HeaderText = "Giờ Đóng Hoá Đơn";
                uiDataGridView1.Columns["TongTien"].HeaderText = "Tổng Tiền";

                // Format dữ liệu
                uiDataGridView1.Columns["ThoiGianMo"].DefaultCellStyle.Format = "HH:mm dd/MM/yyyy";
                uiDataGridView1.Columns["ThoiGianDong"].DefaultCellStyle.Format = "HH:mm dd/MM/yyyy";
                uiDataGridView1.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 VNĐ"; 

                // Căn lề
                uiDataGridView1.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                uiDataGridView1.Columns["TenBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                uiDataGridView1.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                uiDataGridView1.Columns["ThoiGianMo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                uiDataGridView1.Columns["ThoiGianDong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Tự động dãn cột cho khít khung hình
                uiDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // --- PHẦN STYLE (Giống như bạn đã làm rất tốt) ---
                uiDataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                uiDataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                uiDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Nên thêm dòng này để chọn cả hàng cho đẹp

                uiDataGridView1.BackgroundColor = Color.White;
                uiDataGridView1.EnableHeadersVisualStyles = false;
                uiDataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                uiDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                uiDataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                uiDataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                uiDataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                uiDataGridView1.ReadOnly = true;
                uiDataGridView1.AllowUserToAddRows = false;
                uiDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                // Nếu sai tên cột trong code so với SQL, nó sẽ báo ở đây thay vì văng app
                Console.WriteLine("Lỗi định dạng bảng: " + ex.Message);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.AddDays(-7);
            dtTo.Value = DateTime.Now;
            
            LoadThongKe();

            DinhDangBang();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        void LoadThongKe()
        {
            lblTotalRevenue.Text = thongKeBLL.TongDoanhThu(dtFrom.Value, dtTo.Value).ToString("N0") + " VNĐ";

            lblTotalBill.Text = thongKeBLL.TongHoaDon(dtFrom.Value, dtTo.Value).ToString();

            uiLabel5.Text = thongKeBLL.TongMon(dtFrom.Value, dtTo.Value).ToString();

            uiDataGridView1.DataSource = thongKeBLL.DanhSachHoaDon(dtFrom.Value, dtTo.Value);

            LoadChartRevenue();

            LoadChartFood();
        }

        void LoadChartRevenue()
        {
            // 1. Tạo Option mới cho biểu đồ
            var option = new UIBarOption();
            option.Title = new UITitle();
            option.Title.Text = "Doanh Thu Theo Ngày";

            // 2. Lấy dữ liệu từ BLL
            DataTable dt = thongKeBLL.DoanhThuTheoNgay(dtFrom.Value, dtTo.Value);

            // 3. Tạo một Series (Chuỗi dữ liệu)
            var series = new UIBarSeries();
            series.Name = "Doanh Thu";

            foreach (DataRow row in dt.Rows)
            {
                // Thêm tên cột (Trục X)
                option.XAxis.Data.Add(row["Ngay"].ToString());
                // Thêm giá trị (Trục Y)
                series.AddData(Convert.ToDouble(row["DoanhThu"]));
            }

            // 4. Gán Series vào Option và gán Option vào Chart
            option.Series.Add(series);
            uiBarChart1.SetOption(option); // Đây là lệnh thay thế cho AddData
        }

        void LoadChartFood()
        {
            var option = new UIBarOption();
            option.Title = new UITitle { Text = "Top Món Bán Chạy" };

            DataTable dt = thongKeBLL.TopMonBanChay(dtFrom.Value, dtTo.Value);

            var series = new UIBarSeries();
            series.Name = "Số lượng";

            foreach (DataRow row in dt.Rows)
            {
                option.XAxis.Data.Add(row["TenMon"].ToString());
                series.AddData(Convert.ToDouble(row["TongBan"]));
            }

            option.Series.Add(series);
            uiBarChart2.SetOption(option);
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            LoadThongKe();

            MessageBox.Show(
                "Statistics generated successfully!",
                "Notification",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
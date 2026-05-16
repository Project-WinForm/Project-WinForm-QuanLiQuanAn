using projectWindowform.BLL;
using Sunny.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace projectWindowform.GUI
{
    public partial class Form6 : Form
    {
        ThongKeBLL thongKeBLL = new ThongKeBLL();

        public Form6()
        {
            InitializeComponent();

            this.Load += Form6_Load;
            btnThongKe.Click += btnThongKe_Click;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.AddDays(-7);
            dtTo.Value = DateTime.Now;

            LoadThongKe();
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
    }
}
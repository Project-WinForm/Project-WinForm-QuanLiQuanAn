using projectWindowform.BLL;
using projectWindowform.DTO;
using projectWindowform.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tieuluan.BLL; // Gọi lớp BLL
using tieuluan.DTO; // Gọi lớp DTO

namespace projectWindowform
{
    public partial class Form1 : Form
    {
        private int totalTablesCount = 15;
        private Button _selectedTableBtn = null;
        private Button _selectedFoodBtn = null;
        private string _currentTableName = "";
        private string _currentFoodName = "";
        private int _currentFoodPrice = 0;
        private int _currentTableId = 0;

        private OrderBLL _orderBLL = new OrderBLL();
        private List<OrderItem> _temporarySelectedFoods = new List<OrderItem>();
        private FoodBLL _foodBLL = new FoodBLL();
        private TableBLL _tableBLL = new TableBLL();

        public Form1()
        {
            InitializeComponent();

            btnThemmon.Click += btnAddFood_Click;
            btnXoa.Click += btnRemove_Click;
            btnThanhtoan.Click += btnCheckout_Click;

            // --- ĐĂNG KÝ SỰ KIỆN CHO CÁC PHẦN MỚI NÂNG CẤP ---
            btnSwitchTable.Click += btnSwitchTable_Click; // Sự kiện nút Đổi bàn
            cboCategory.SelectedIndexChanged += CboCategory_SelectedIndexChanged; // Sự kiện lọc danh mục

            LoadTableList();
            LoadCategoryToComboBox(); // Nạp dữ liệu vào ô Danh mục
            LoadTableToComboBox();    // Nạp dữ liệu vào ô Đổi bàn
            LoadMenuList();
            UpdateTableStatus();
        }

        private void LoadTableList()
        {
            flpTables.Controls.Clear();

            var tables = _tableBLL.GetTables(); // load từ DB

            foreach (var table in tables)
            {
                Button btnTable = new Button();

                // Kiểm tra xem bàn thực tế đang có hóa đơn chưa để gán chữ trạng thái lúc mở app
                if (_orderBLL.HasOrder(table.TenBan))
                {
                    btnTable.Text = table.TenBan + Environment.NewLine + "(Có khách)";
                    btnTable.BackColor = Color.LightGreen;
                }
                else
                {
                    btnTable.Text = table.TenBan + Environment.NewLine + "(Trống)";
                    btnTable.BackColor = Color.LightGray;
                }

                btnTable.Width = 90;
                btnTable.Height = 90;
                btnTable.FlatStyle = FlatStyle.Flat;
                btnTable.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnTable.Tag = table;   // ← gán cả object Table
                btnTable.Click += BtnTable_Click;
                flpTables.Controls.Add(btnTable);
            }
            totalTablesCount = tables.Count;
        }

        private void UpdateTableStatus()
        {
            int occupied = _orderBLL.GetOccupiedTableCount();
            int empty = _orderBLL.GetEmptyTableCount(totalTablesCount);

            lblBanCoKhach.Text = "Bàn có khách: " + occupied;
            lblBanTrong.Text = "Bàn trống: " + empty;
        }

        // --- NẠP DANH SÁCH DANH MỤC ĐỘNG TỪ DATABASE VÀO COMBOBOX ---
        private void LoadCategoryToComboBox()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.Add("Tất cả món");

            var foods = _foodBLL.GetFoods();
            List<string> addedCategories = new List<string>();

            foreach (var item in foods)
            {
                // Nếu món ăn có tên danh mục hợp lệ và chưa được thêm vào ComboBox
                if (!string.IsNullOrEmpty(item.TenDanhMuc) && !addedCategories.Contains(item.TenDanhMuc))
                {
                    addedCategories.Add(item.TenDanhMuc);
                    cboCategory.Items.Add(item.TenDanhMuc);
                }
            }

            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
        }

        // --- NẠP DANH SÁCH TÊN BÀN VÀO COMBOBOX ĐỔI BÀN ---
        private void LoadTableToComboBox()
        {
            cboSwitchTable.Items.Clear();
            var tables = _tableBLL.GetTables();
            foreach (var table in tables)
            {
                cboSwitchTable.Items.Add(table.TenBan);
            }
            if (cboSwitchTable.Items.Count > 0)
            {
                cboSwitchTable.SelectedIndex = 0;
            }
        }

        private void LoadMenuList()
        {
            flpThucdon.Controls.Clear();
            var foods = _foodBLL.GetFoods(); // Load từ DB

            foreach (var item in foods)
            {
                Button btnFood = new Button();
                btnFood.Text = item.TenMon + Environment.NewLine
                             + item.Gia.ToString("N0") + "đ";
                btnFood.Width = 150;
                btnFood.Height = 140;
                btnFood.BackColor = Color.White;
                btnFood.FlatStyle = FlatStyle.Flat;
                btnFood.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                try
                {
                    string fullPath = System.IO.Path.Combine(
                        Application.StartupPath, "Images", item.HinhAnh);
                    if (System.IO.File.Exists(fullPath))
                    {
                        using (var stream = System.IO.File.OpenRead(fullPath))
                        {
                            Image img = Image.FromStream(stream);
                            btnFood.Image = new Bitmap(img, new Size(100, 80));
                        }
                        btnFood.TextImageRelation = TextImageRelation.ImageAboveText;
                    }
                }
                catch { }

                btnFood.Tag = new OrderItem
                {
                    FoodId = item.Id,
                    FoodName = item.TenMon,
                    Price = (int)item.Gia
                };
                btnFood.Click += BtnFood_Click;
                flpThucdon.Controls.Add(btnFood);
            }
        }

        // --- LOGIC XỬ LÝ LỌC THỰC ĐƠN ĐỘNG THEO DANH MỤC CHUẨN DATABASE ---
        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedItem == null) return;
            string selectedCat = cboCategory.SelectedItem.ToString();

            flpThucdon.Controls.Clear();
            var foods = _foodBLL.GetFoods();

            foreach (var item in foods)
            {
                // Đối chiếu trực tiếp trường TenDanhMuc của dữ liệu với danh mục được chọn trên giao diện
                if (selectedCat != "Tất cả món" && item.TenDanhMuc != selectedCat)
                {
                    continue;
                }

                Button btnFood = new Button();
                btnFood.Text = item.TenMon + Environment.NewLine + item.Gia.ToString("N0") + "đ";
                btnFood.Width = 150;
                btnFood.Height = 140;
                btnFood.BackColor = Color.White;
                btnFood.FlatStyle = FlatStyle.Flat;
                btnFood.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                try
                {
                    string fullPath = System.IO.Path.Combine(Application.StartupPath, "Images", item.HinhAnh);
                    if (System.IO.File.Exists(fullPath))
                    {
                        using (var stream = System.IO.File.OpenRead(fullPath))
                        {
                            Image img = Image.FromStream(stream);
                            btnFood.Image = new Bitmap(img, new Size(100, 80));
                        }
                        btnFood.TextImageRelation = TextImageRelation.ImageAboveText;
                    }
                }
                catch { }

                btnFood.Tag = new OrderItem
                {
                    FoodId = item.Id,
                    FoodName = item.TenMon,
                    Price = (int)item.Gia
                };
                btnFood.Click += BtnFood_Click;
                flpThucdon.Controls.Add(btnFood);
            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            if (_selectedTableBtn != null)
            {
                var prevTable = _selectedTableBtn.Tag as Table;
                if (!_orderBLL.HasOrder(prevTable.TenBan))
                    _selectedTableBtn.BackColor = Color.LightGray;
                else
                    _selectedTableBtn.BackColor = Color.LightGreen;
            }

            // --- FIX LỖI KẸT MÓN: Reset món ăn tạm thời (màu cam) của bàn cũ khi bấm sang bàn khác ---
            _temporarySelectedFoods.Clear();
            LoadMenuList(); // Reset lại toàn bộ màu sắc của các nút món ăn về màu trắng
            nmrSoluong.Value = 1;
            // -------------------------------------------------------------------------------------

            _selectedTableBtn = sender as Button;
            _selectedTableBtn.BackColor = Color.LightSkyBlue;

            var table = _selectedTableBtn.Tag as Table;
            _currentTableName = table.TenBan;
            _currentTableId = table.Id;

            ShowBill(_currentTableName);
        }

        private void BtnFood_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OrderItem data = btn.Tag as OrderItem;
            int quantity = (int)nmrSoluong.Value;
            var existingItem = _temporarySelectedFoods.Find(x => x.FoodName == data.FoodName);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _temporarySelectedFoods.Add(new OrderItem
                {
                    FoodId = data.FoodId,
                    FoodName = data.FoodName,
                    Price = data.Price,
                    Quantity = quantity
                });
            }
            btn.BackColor = Color.Orange;
            _currentFoodName = data.FoodName;
            _currentFoodPrice = data.Price;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTableName))
            {
                MessageBox.Show("Vui lòng chọn BÀN trước khi gọi món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_temporarySelectedFoods == null || _temporarySelectedFoods.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một MÓN ĂN (nút chuyển màu cam) trước khi nhấn thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (var item in _temporarySelectedFoods)
            {
                _orderBLL.AddFood(_currentTableName, item.FoodName, item.Price, item.Quantity);
            }
            _selectedTableBtn.Text = _currentTableName + Environment.NewLine + "(Có khách)";
            _selectedTableBtn.BackColor = Color.LightGreen;
            ShowBill(_currentTableName);
            UpdateTableStatus();
            _temporarySelectedFoods.Clear();
            LoadMenuList();
            nmrSoluong.Value = 1;
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTableName))
            {
                MessageBox.Show("Vui lòng chọn bàn hiện tại cần chuyển đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_orderBLL.HasOrder(_currentTableName))
            {
                MessageBox.Show("Bàn hiện tại không có khách ngồi, không thể thực hiện đổi bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSwitchTable.SelectedItem == null) return;
            string targetTableName = cboSwitchTable.SelectedItem.ToString();

            if (targetTableName == _currentTableName)
            {
                MessageBox.Show("Bàn đích trùng với bàn hiện tại. Vui lòng chọn một bàn khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận chuyển toàn bộ các món từ {_currentTableName} sang {targetTableName}?", "Xác nhận đổi bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _orderBLL.SwitchTable(_currentTableName, targetTableName);

                    MessageBox.Show($"Đã đổi từ {_currentTableName} sang {targetTableName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadTableList();
                    UpdateTableStatus();

                    _currentTableName = "";
                    _selectedTableBtn = null;
                    lsvHoadon.Items.Clear();
                    lblTong.Text = "Tổng tiền: 0 VNĐ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi trong quá trình đổi bàn: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsvHoadon.SelectedItems.Count > 0)
            {
                using (FormLyDoXoa frm = new FormLyDoXoa())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string lyDo = frm.LyDoChon;
                        List<string> selectedFoodNames = new List<string>();
                        foreach (ListViewItem item in lsvHoadon.SelectedItems)
                        {
                            selectedFoodNames.Add(item.Text);
                        }
                        foreach (string foodName in selectedFoodNames)
                        {
                            _orderBLL.RemoveFood(_currentTableName, foodName);
                        }
                        string chuoiMonDaXoa = string.Join(", ", selectedFoodNames);
                        MessageBox.Show($"Đã xóa các món: '{chuoiMonDaXoa}' với lý do: {lyDo}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!_orderBLL.HasOrder(_currentTableName))
                        {
                            _selectedTableBtn.Text = _currentTableName + Environment.NewLine + "(Trống)";
                            _selectedTableBtn.BackColor = Color.LightSkyBlue;
                        }

                        ShowBill(_currentTableName);
                        UpdateTableStatus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một món (hoặc giữ Ctrl để chọn nhiều món) trên hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem bàn hiện tại đang chọn có hóa đơn món ăn nào không
            if (!_orderBLL.HasOrder(_currentTableName)) return;

            // 2. Hiện hộp thoại hỏi xác nhận thanh toán
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn thanh toán cho {_currentTableName} không?", "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Lấy danh sách món ăn hiện tại và tính tổng tiền của bàn này TRƯỚC KHI xóa dữ liệu trong DB
                    List<OrderItem> currentBill = _orderBLL.GetBill(_currentTableName);
                    int totalAmount = 0;
                    foreach (var item in currentBill)
                    {
                        totalAmount += item.Total;
                    }

                    // 3. Khởi tạo Form Hóa Đơn và truyền dữ liệu sang (Tên bàn, Danh sách món, Tổng tiền)
                    FormHoaDon frmInHD = new FormHoaDon(_currentTableName, currentBill, totalAmount);

                    // Ép Form hóa đơn xuất hiện ngay chính giữa màn hình
                    frmInHD.StartPosition = FormStartPosition.CenterScreen;

                    // Hiển thị Form hóa đơn lên dạng hộp thoại (User bắt buộc phải xem hoặc ấn In/Đóng mới quay lại Form1 được)
                    frmInHD.ShowDialog();

                    // 4. Sau khi đóng Form hóa đơn, gọi BLL để xử lý cập nhật CSDL (Lưu doanh thu, xóa bảng tạm)
                    _orderBLL.Checkout(_currentTableName, _currentTableId);

                    // 5. Làm mới lại giao diện hiển thị của bàn vừa thanh toán
                    _selectedTableBtn.Text = _currentTableName + Environment.NewLine + "(Trống)";
                    _selectedTableBtn.BackColor = Color.LightGray; // Hoặc màu bàn trống mặc định của bạn

                    ShowBill(_currentTableName);
                    UpdateTableStatus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xử lý thanh toán và xuất hóa đơn: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowBill(string tableName)
        {
            lsvHoadon.Items.Clear();
            int totalAmount = 0;
            List<OrderItem> currentBill = _orderBLL.GetBill(tableName);

            foreach (var item in currentBill)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName);
                lsvItem.SubItems.Add(item.Quantity.ToString());
                lsvItem.SubItems.Add(item.Price.ToString("N0"));
                lsvItem.SubItems.Add(item.Total.ToString("N0"));
                lsvHoadon.Items.Add(lsvItem);
                totalAmount += item.Total;
            }
            lblTong.Text = "Tổng tiền: " + totalAmount.ToString("N0") + " VNĐ";
        }

        private void lnkDangXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Xác nhận đăng xuất khỏi hệ thống nhà hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                projectWindowform.GUI.Form4 loginForm = new projectWindowform.GUI.Form4();
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}
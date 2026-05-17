using projectWindowform.BLL;
using projectWindowform.DTO;
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

            LoadTableList();
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
                btnTable.Text = table.TenBan + Environment.NewLine + "(Trống)";
                btnTable.Width = 90;
                btnTable.Height = 90;
                btnTable.BackColor = Color.LightGray;
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
            // Tự động lấy số lượng bàn đã khai báo ở đầu Class
            int occupied = _orderBLL.GetOccupiedTableCount();
            int empty = _orderBLL.GetEmptyTableCount(totalTablesCount);

            lblBanCoKhach.Text = "Bàn có khách: " + occupied;
            lblBanTrong.Text = "Bàn trống: " + empty;
        }


        private void LoadMenuList()
        {
            flpThucdon.Controls.Clear();

            // Load từ DB thay vì hardcode
            var foods = _foodBLL.GetFoods(); // cần viết FoodBLL + FoodDAL

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

                // Load ảnh như cũ
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

                // Gán FoodId vào Tag
                btnFood.Tag = new OrderItem
                {
                    FoodId = item.Id,      // ← có FoodId thật rồi
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
                // Lấy table từ Tag đúng cách
                var prevTable = _selectedTableBtn.Tag as Table;
                if (!_orderBLL.HasOrder(prevTable.TenBan))  // ← dùng prevTable.TenBan
                    _selectedTableBtn.BackColor = Color.LightGray;
                else
                    _selectedTableBtn.BackColor = Color.LightGreen;
            }

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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsvHoadon.SelectedItems.Count > 0)
            {
                using (FormLyDoXoa frm = new FormLyDoXoa())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string lyDo = frm.LyDoChon;
                        string foodName = lsvHoadon.SelectedItems[0].Text;
                        MessageBox.Show($"Đã xóa món '{foodName}' với lý do: {lyDo}", "Thông báo"); _orderBLL.RemoveFood(_currentTableName, foodName);

                        if (!_orderBLL.HasOrder(_currentTableName))
                        {
                            _selectedTableBtn.Text = _currentTableName + Environment.NewLine + "(Trống)";
                            _selectedTableBtn.BackColor = Color.LightSkyBlue;
                        }

                        ShowBill(_currentTableName);
                        UpdateTableStatus();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một món trên hóa đơn để xóa!", "Thông báo");
                    }
                }
            }
        }
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (!_orderBLL.HasOrder(_currentTableName)) return;

            if (MessageBox.Show($"Thanh toán cho {_currentTableName}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _orderBLL.Checkout(_currentTableName,_currentTableId); // BLL tự lo lưu Bill

                    _selectedTableBtn.Text = _currentTableName + Environment.NewLine + "(Trống)";
                    _selectedTableBtn.BackColor = Color.LightSkyBlue;
                    ShowBill(_currentTableName);
                    UpdateTableStatus();
                    MessageBox.Show("Thanh toán thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
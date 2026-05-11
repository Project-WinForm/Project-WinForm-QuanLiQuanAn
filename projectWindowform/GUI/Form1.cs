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

        private OrderBLL _orderBLL = new OrderBLL();
        private List<OrderItem> _temporarySelectedFoods = new List<OrderItem>();

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
            // Sử dụng biến chung totalTablesCount
            for (int i = 1; i <= totalTablesCount; i++)
            {
                Button btnTable = new Button();
                string tableName = "Bàn " + i;
                btnTable.Text = tableName + Environment.NewLine + "(Trống)";
                btnTable.Width = 90;
                btnTable.Height = 90;
                btnTable.BackColor = Color.LightGray;
                btnTable.FlatStyle = FlatStyle.Flat;
                btnTable.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnTable.Tag = tableName;
                btnTable.Click += BtnTable_Click;
                flpTables.Controls.Add(btnTable);
            }
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
            var dookkiMenu = new List<Food>()
    {
        new Food { Name = "Vé Buffet Người Lớn", Price = 139000, ImagePath = @"Images\1.png" },
        new Food { Name = "Vé Buffet Trẻ Em", Price = 69000, ImagePath = @"Images\2.png" },
        new Food { Name = "Viền phô mai", Price = 69000, ImagePath = @"Images\a.png" },
        new Food { Name = "Phô mai hoa tuyết", Price = 49000, ImagePath = @"Images\b.png" },
        new Food { Name = "Thịt bò cuộn", Price = 49000, ImagePath = @"Images\c.png" },
        new Food {Name = "Nước ngọt", Price = 29000, ImagePath = @"Images\d.png"},  
    };

            foreach (var item in dookkiMenu)
            {
                Button btnFood = new Button();
                btnFood.Text = item.Name + Environment.NewLine + item.Price.ToString("N0") + "đ";
                btnFood.Width = 150;
                btnFood.Height = 140;
                btnFood.BackColor = Color.White;
                btnFood.FlatStyle = FlatStyle.Flat;
                btnFood.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                // --- BẮT ĐẦU CẢI TIẾN BƯỚC 3 Ở ĐÂY ---
                try
                {
                    // Kết hợp đường dẫn thư mục đang chạy (Debug) với đường dẫn Images\a.png
                    string fullPath = System.IO.Path.Combine(Application.StartupPath, item.ImagePath);

                    if (System.IO.File.Exists(fullPath))
                    {
                        // Dùng cách này để load ảnh mà không giữ khóa (lock) file
                        using (var stream = System.IO.File.OpenRead(fullPath))
                        {
                            Image img = Image.FromStream(stream);
                            btnFood.Image = new Bitmap(img, new Size(100, 80));
                        }
                        btnFood.TextImageRelation = TextImageRelation.ImageAboveText;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi nạp ảnh: " + ex.Message);
                }
                btnFood.Tag = new OrderItem { FoodName = item.Name, Price = item.Price };
                btnFood.Click += BtnFood_Click;
                flpThucdon.Controls.Add(btnFood);
            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            if (_selectedTableBtn != null && !_orderBLL.HasOrder(_selectedTableBtn.Tag.ToString()))
                _selectedTableBtn.BackColor = Color.LightGray;
            else if (_selectedTableBtn != null)
                _selectedTableBtn.BackColor = Color.LightGreen;

            _selectedTableBtn = sender as Button;
            _selectedTableBtn.BackColor = Color.LightSkyBlue;
            _currentTableName = _selectedTableBtn.Tag.ToString();
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
                _orderBLL.Checkout(_currentTableName);
                _selectedTableBtn.Text = _currentTableName + Environment.NewLine + "(Trống)";
                _selectedTableBtn.BackColor = Color.LightSkyBlue;

                ShowBill(_currentTableName);
                UpdateTableStatus();
                MessageBox.Show("Thanh toán thành công!");
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
    }
}
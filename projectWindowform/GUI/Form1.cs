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
            var dookkiMenu = new Dictionary<string, int>()
            {
                { "Vé Buffet Người Lớn", 139000 },
                { "Vé Buffet Trẻ Em", 69000 },
                { "Viền phô mai", 69000 },
                { "Phô mai hoa tuyết", 49000 },
                { "Thịt bò cuộn", 49000 },
                { "Nước ngọt Refill", 29000 },
                { "Sochu Hàn Quốc", 65000 }
            };

            foreach (var item in dookkiMenu)
            {
                Button btnFood = new Button();
                btnFood.Text = item.Key + Environment.NewLine + item.Value.ToString("N0") + "đ";
                btnFood.Width = 120;
                btnFood.Height = 80;
                btnFood.BackColor = Color.White;
                btnFood.FlatStyle = FlatStyle.Flat;
                btnFood.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                btnFood.Tag = new OrderItem { FoodName = item.Key, Price = item.Value };
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
            if (_selectedFoodBtn != null) _selectedFoodBtn.BackColor = Color.White;
            _selectedFoodBtn = sender as Button;
            _selectedFoodBtn.BackColor = Color.LightYellow;

            OrderItem selectedData = _selectedFoodBtn.Tag as OrderItem;
            _currentFoodName = selectedData.FoodName;
            _currentFoodPrice = selectedData.Price;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentTableName))
            {
                MessageBox.Show("Vui lòng chọn BÀN trước khi gọi món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(_currentFoodName))
            {
                MessageBox.Show("Vui lòng chọn MÓN ĂN trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)nmrSoluong.Value;
            _orderBLL.AddFood(_currentTableName, _currentFoodName, _currentFoodPrice, quantity);
            _selectedTableBtn.Text = _currentTableName + Environment.NewLine + "(Có khách)";
            _selectedTableBtn.BackColor = Color.LightGreen;

            ShowBill(_currentTableName);
            UpdateTableStatus();
            nmrSoluong.Value = 1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsvHoadon.SelectedItems.Count > 0)
            {
                string foodName = lsvHoadon.SelectedItems[0].Text;
                _orderBLL.RemoveFood(_currentTableName, foodName);

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
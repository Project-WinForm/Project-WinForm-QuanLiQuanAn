using projectWindowform.BLL;
using projectWindowform.DAL;
using projectWindowform.DTO;
using Sunny;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectWindowform
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        FoodBLL foodBLL = new FoodBLL();
        CategoryBLL categoryBLL = new CategoryBLL();
        string imagePath = "";
        string imageName = "";
        int selectedFoodId = -1;


        private void DinhDangBang()
        {
            // --- Khung và màu sắc cơ bản ---
            dgvFood.BorderStyle = BorderStyle.None;
            dgvFood.BackgroundColor = Color.White;
            dgvFood.GridColor = Color.FromArgb(224, 224, 224); // Màu đường kẻ mảnh
            dgvFood.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Chỉ kẻ ngang cho hiện đại

            // --- Định dạng Tiêu đề (Header) ---
            dgvFood.EnableHeadersVisualStyles = false;
            dgvFood.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFood.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue; // Hoặc Color.FromArgb(52, 73, 94) nếu muốn màu tối
            dgvFood.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFood.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvFood.ColumnHeadersHeight = 40; // Tăng chiều cao header cho thoáng
            dgvFood.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // --- Định dạng nội dung ô (Cells) ---
            dgvFood.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvFood.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgvFood.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFood.RowTemplate.Height = 35; // Hàng cao hơn một chút nhìn sẽ sang hơn

            // --- Màu dòng xen kẽ (Giống bên Thống kê) ---
            dgvFood.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // --- Căn chỉnh nội dung cột ---
            // Kiểm tra nếu có cột mới chỉnh, để tránh lỗi NullReference
            if (dgvFood.Columns.Contains("FoodID"))
            {
                dgvFood.Columns["FoodID"].HeaderText = "Mã Món";
                dgvFood.Columns["FoodID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvFood.Columns.Contains("FoodName"))
            {
                dgvFood.Columns["FoodName"].HeaderText = "Tên Món Ăn";
            }

            if (dgvFood.Columns.Contains("CategoryName"))
            {
                dgvFood.Columns["CategoryName"].HeaderText = "Danh Mục";
                dgvFood.Columns["CategoryName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvFood.Columns.Contains("Price"))
            {
                dgvFood.Columns["Price"].HeaderText = "Đơn Giá";
                dgvFood.Columns["Price"].DefaultCellStyle.Format = "#,### VNĐ"; // Thêm VNĐ như bạn muốn
                dgvFood.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvFood.Columns["Price"].DefaultCellStyle.ForeColor = Color.Red; // Giá tiền để màu đỏ cho nổi bật
            }

            if (dgvFood.Columns.Contains("Status"))
            {
                dgvFood.Columns["Status"].HeaderText = "Trạng Thái";
                dgvFood.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // --- Các thiết lập bổ sung ---
            dgvFood.ReadOnly = true; // Không cho sửa trực tiếp trên bảng
            dgvFood.AllowUserToAddRows = false; // Bỏ dòng trống cuối bảng
            dgvFood.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picFood.Image = Image.FromFile(open.FileName);
                // Lấy tên file
                imageName = Path.GetFileName(open.FileName);

                // Đường dẫn folder Images
                imagePath = Application.StartupPath + @"\Images\" + imageName;


                // Copy ảnh vào Images
                File.Copy(open.FileName, imagePath, true);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dgvFood.AutoGenerateColumns = false;
            dgvFood.DataSource = foodBLL.GetFoods();
            List<Category> categories = categoryBLL.GetCategories();

            // 2. Gán nguồn dữ liệu cho ComboBox
            cboCategory.DataSource = categories;

            // 3. Thiết lập cột hiển thị và cột giá trị ẩn
            cboCategory.DisplayMember = "TenDanhMuc"; // Tên thuộc tính hiển thị (chữ)
            cboCategory.ValueMember = "Id";
            txtNameFood.Enabled = false;
            txtPrice.Enabled = false;
            cboCategory.Enabled = false;
            cboStatus.Enabled = false;
            btnChooseImg.Enabled = false;
            btnNew.Enabled = false;
            btnCancel.Enabled = false;
            DinhDangBang();
        }

        private void ResetstatusAdd()
        {
            btnAdd.Text = "Add";
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtNameFood.Enabled = false;
            txtPrice.Enabled = false;
            cboCategory.Enabled = false;
            cboStatus.Enabled = false;
            btnChooseImg.Enabled = false;
            btnNew.Enabled = false;
            btnCancel.Enabled = false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text == "Add" )
            {
                btnAdd.Text = "Save";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                txtNameFood.Enabled = true;
                txtPrice.Enabled = true;
                cboCategory.Enabled = true;
                cboStatus.Enabled = true;
                btnChooseImg.Enabled = true;
                btnCancel.Enabled = true;
                btnNew.Enabled = true;
            }
            else
            {
                Food food = new Food();

                food.TenMon = txtNameFood.Text;
                food.DanhMucId = Convert.ToInt32(cboCategory.SelectedValue);
                food.Gia = Convert.ToInt32(txtPrice.Text);
                food.HinhAnh = imageName;
                if (cboStatus.Text == "Còn bán")
                {
                    food.TrangThai = true ;
                }
                else
                {
                    food.TrangThai = false ;
                }    
                if(foodBLL.Insert(food.TenMon, food.Gia, food.DanhMucId,food.HinhAnh,food.TrangThai))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetstatusAdd();
                    dgvFood.DataSource = foodBLL.GetFoods();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                    ResetstatusAdd();
                }

            }
        }

        private void ResetstatusUpdate()
        {
            btnUpdate.Text = "Update";
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            txtNameFood.Enabled = false;
            txtPrice.Enabled = false;
            cboCategory.Enabled = false;
            cboStatus.Enabled = false;
            btnChooseImg.Enabled = false;
            btnNew.Enabled = false;
            btnCancel.Enabled = false;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                txtNameFood.Enabled = true;
                txtPrice.Enabled = true;
                cboCategory.Enabled = true;
                cboStatus.Enabled = true;
                btnChooseImg.Enabled = true;
                btnCancel.Enabled = true;
                btnNew.Enabled = true;
            }
            else
            {
                Food food = new Food();
                food.TenMon = txtNameFood.Text;
                food.DanhMucId = Convert.ToInt32(cboCategory.SelectedValue);
                food.Gia = Convert.ToInt32(txtPrice.Text);
                food.HinhAnh = imageName;
                if (cboStatus.Text == "Còn bán")
                {
                    food.TrangThai = true;
                }
                else
                {
                    food.TrangThai = false;
                }
                if (foodBLL.Update(selectedFoodId,food.TenMon, food.Gia, food.DanhMucId, food.HinhAnh, food.TrangThai))
                {
                    MessageBox.Show("Sửa thành công");
                    ResetstatusUpdate();
                    dgvFood.DataSource = foodBLL.GetFoods();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                    ResetstatusUpdate();
                }

            }
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFood.Rows[e.RowIndex];

                selectedFoodId = Convert.ToInt32(row.Cells["FoodId"].Value);

                txtNameFood.Text = Convert.ToString(row.Cells["FoodName"].Value);
                cboCategory.Text = Convert.ToString(row.Cells["CategoryName"].Value);
                txtPrice.Text = Convert.ToString(row.Cells["Price"].Value);
                cboStatus.Text = Convert.ToString(row.Cells["Status"].Value);
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dgvFood.DataSource = foodBLL.SearchFood(txtSearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedFoodId == -1)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn xóa món này không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                if (foodBLL.Delete(selectedFoodId)) 
                {
                    MessageBox.Show("Xóa thành công!");
                    dgvFood.DataSource = foodBLL.GetFoods();
                    selectedFoodId = -1; 
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtNameFood.Text = "";
            txtPrice.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 1. Đưa các nút bấm về trạng thái ban đầu
            btnAdd.Text = "Add";
            btnUpdate.Text = "Update";

            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            btnNew.Enabled = false;

            // 2. Vô hiệu hóa các ô nhập liệu (Read-only)
            txtNameFood.Enabled = false;
            txtPrice.Enabled = false;
            cboCategory.Enabled = false;
            cboStatus.Enabled = false;
            btnChooseImg.Enabled = false;

            // 3. Xóa dữ liệu tạm đang nhập dở (Tùy chọn)
            // Nếu bạn muốn giữ lại dữ liệu cũ đã chọn trên bảng thì dùng:
            if (selectedFoodId != -1)
            {
                // Bạn có thể gọi lại hàm CellClick hoặc tự điền lại để "reset" giao diện về dòng đang chọn
                dgvFood_CellClick(dgvFood, new DataGridViewCellEventArgs(0, dgvFood.CurrentRow.Index));
            }
            else
            {
                txtNameFood.Text = "";
                txtPrice.Text = "";
                imageName = "";
                picFood.Image = null; // Xóa ảnh hiển thị nếu có
            }

            MessageBox.Show("Đã hủy thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

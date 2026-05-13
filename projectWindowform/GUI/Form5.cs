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
            }
            else
            {
                Food food = new Food();

                food.TenMon = txtNameFood.Text;
                food.DanhMucId = Convert.ToInt32(cboCategory.SelectedValue);
                food.Price = Convert.ToInt32(txtPrice.Text);
                food.HinhAnh = imageName;
                if (cboStatus.Text == "Còn bán")
                {
                    food.TrangThai = true ;
                }
                else
                {
                    food.TrangThai = false ;
                }    
                if(foodBLL.Insert(food.TenMon, food.Price, food.DanhMucId,food.HinhAnh,food.TrangThai))
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
            }
            else
            {
                Food food = new Food();
                food.TenMon = txtNameFood.Text;
                food.DanhMucId = Convert.ToInt32(cboCategory.SelectedValue);
                food.Price = Convert.ToInt32(txtPrice.Text);
                food.HinhAnh = imageName;
                if (cboStatus.Text == "Còn bán")
                {
                    food.TrangThai = true;
                }
                else
                {
                    food.TrangThai = false;
                }
                if (foodBLL.Update(selectedFoodId,food.TenMon, food.Price, food.DanhMucId, food.HinhAnh, food.TrangThai))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectWindowform.BLL;
using projectWindowform.DTO;

namespace projectWindowform.GUI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        StaffBLL staffBLL = new StaffBLL();
        int selectedStaffId = -1;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dgvStaff.DataSource = staffBLL.GetAll();
        }

        private void ResetAddState()
        {
            btnAdd.Text = "Add";
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (btnAdd.Text == "Add") // LẦN NHẤN THỨ NHẤT
            {
                btnAdd.Text = "Save";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

            }
            else // LẦN NHẤN THỨ HAI (Text đang là "Lưu")
            {
                Staff staff = new Staff();
                staff.TenDangNhap = txtUsername.Text;
                staff.MatKhau = txtPassword.Text;
                staff.VaiTro = txtRole.Text;
                staff.TenHienThi = txtDisplayName.Text;
                if (staffBLL.Insert(staff))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetAddState();
                    dgvStaff.DataSource = staffBLL.GetAll();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }

        }

        private void ResetUpdateState()
        {
            btnUpdate.Text = "Update";
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            txtUsername.ReadOnly = false;
            txtPassword.ReadOnly = false;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!");
                return;
            }

            if (btnUpdate.Text == "Update") // LẦN NHẤN THỨ NHẤT
            {
                btnUpdate.Text = "Save";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                txtUsername.ReadOnly = true;
                txtPassword.ReadOnly = true;

            }
            else // LẦN NHẤN THỨ HAI (Text đang là "Lưu")
            {
                // 1. Lấy dữ liệu từ giao diện
                Staff nhanviencapnhat = new Staff();
                nhanviencapnhat.Id = selectedStaffId;
                nhanviencapnhat.TenHienThi = txtDisplayName.Text;
                nhanviencapnhat.VaiTro = txtRole.Text;

                // 2. Gọi BLL để cập nhật
                if (staffBLL.Update(nhanviencapnhat))
                {
                    MessageBox.Show("Cập nhật thành công!");

                    // 3. Khôi phục trạng thái ban đầu
                    ResetUpdateState();

                    // 4. Load lại dữ liệu
                    dgvStaff.DataSource = staffBLL.GetAll();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại.");
                }
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];

                selectedStaffId = Convert.ToInt32(row.Cells["Id"].Value);

                txtUsername.Text = Convert.ToString(row.Cells["TenDangNhap"].Value);
                txtPassword.Text = Convert.ToString(row.Cells["MatKhau"].Value);
                txtDisplayName.Text = Convert.ToString(row.Cells["TenHienThi"].Value);
                txtRole.Text = Convert.ToString(row.Cells["VaiTro"].Value);
            }
        }

        private void ResetDeleteState()
        {
            btnDelete.Text = "Delete";
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;   
            txtUsername.ReadOnly = false;
            txtPassword.ReadOnly = false;
            txtDisplayName.ReadOnly = false;
            txtRole.ReadOnly = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Delete") 
            {
                btnDelete.Text = "Save";
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                txtUsername.ReadOnly = true;
                txtPassword.ReadOnly = true;
                txtDisplayName.ReadOnly = true;
                txtRole.ReadOnly = true;

            }
            else 
            {
                if(selectedStaffId == -1)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa!");
                    return;
                }

                if (staffBLL.Delete(selectedStaffId))
                {
                    MessageBox.Show("Xoá thành công!");

                    ResetDeleteState();

                    dgvStaff.DataSource = staffBLL.GetAll();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng kiểm tra lại.");
                }
            }
        }
    }
}

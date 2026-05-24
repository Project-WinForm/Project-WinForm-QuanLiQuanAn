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
using Sunny.UI;

namespace projectWindowform.GUI
{
    public partial class Form3 : UIForm
    {
            StaffBLL staffBLL = new StaffBLL();
            int selectedStaffId = -1;
        public Form3()
        {
            InitializeComponent();
            AllowShowTitle = false;
            // Thêm dữ liệu vào ComboBox bằng code
            cboRole.Items.Add("Admin");
            cboRole.Items.Add("Nhân viên");
        } 
        
        private void Form3_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
          
        }

        private void LoadDataGrid()
        {
            try
            {
                // Lấy dữ liệu mới nhất thông qua hàm GetAll() của StaffBLL
                dgvStaff.DataSource = staffBLL.GetAll();

                if (dgvStaff.Columns.Count > 0)
                {
                    // Định dạng Tiếng Việt cho tiêu đề các cột
                    dgvStaff.Columns["Id"].HeaderText = "Mã Số";
                    dgvStaff.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
                    dgvStaff.Columns["MatKhau"].HeaderText = "Mật Khẩu";
                    dgvStaff.Columns["TenHienThi"].HeaderText = "Tên Hiển Thị";
                    dgvStaff.Columns["VaiTro"].HeaderText = "Vai Trò";

                    // Tự động giãn đều khít màn hình rộng rãi
                    dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisplayName.Focus();
                return false;
            }

            if (cboRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRole.Focus();
                return false;
            }

            return true; 
        }


        private void ClearTextBoxes() // Xóa trống nội dung các TextBox
        {
            txtUsername.Text = "";   
            txtPassword.Text = "";
            txtDisplayName.Text = "";

            cboRole.SelectedIndex = -1;

            txtUsername.Focus();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Yêu cầu 1: Phải điền đủ dữ liệu mới cho làm việc
            if (!CheckInput()) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn THÊM nhân viên này không?",
                                              "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // Đổi thành lớp Staff theo đúng DTO của bạn định nghĩa
                Staff newStaff = new Staff
                {
                    TenDangNhap = txtUsername.Text,
                    MatKhau = txtPassword.Text,
                    TenHienThi = txtDisplayName.Text,
                    VaiTro = cboRole.Text
                };

                // Yêu cầu 2: Gọi đúng hàm Insert(newStaff) của StaffBLL để thêm dữ liệu thật vào SQL
                if (staffBLL.Insert(newStaff))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes(); 
                    LoadDataGrid();   
                }
                else
                {
                    MessageBox.Show("Thêm thất bại! Tên đăng nhập này có thể đã tồn tại.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã click chọn dòng nào dưới lưới chưa
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Vui lòng click chọn nhân viên muốn chỉnh sửa từ danh sách bảng trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckInput()) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn CẬP NHẬT thông tin nhân viên này?",
                                              "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Staff updateStaff = new Staff
                {
                    Id = selectedStaffId,
                    TenDangNhap = txtUsername.Text,
                    MatKhau = txtPassword.Text,
                    TenHienThi = txtDisplayName.Text,
                    VaiTro = cboRole.Text
                };

                // Gọi hàm Update của StaffBLL gửi dữ liệu thay đổi xuống database
                if (staffBLL.Update(updateStaff))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                    LoadDataGrid(); // Làm mới lại bảng dữ liệu
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Vui lòng click chọn nhân viên muốn xóa từ danh sách bảng trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Hành động này không thể hoàn tác! Bạn có thực sự muốn XÓA nhân viên này không?",
                                              "Cảnh báo nguy hiểm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                // Gọi hàm Delete truyền tham số mã Id đang chọn xuống SQL
                if (staffBLL.Delete(selectedStaffId))
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                    LoadDataGrid(); // Refresh lại lưới hiển thị
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];

                // Lưu lại mã ID của nhân viên đang chọn phục vụ cho Sửa/Xóa
                selectedStaffId = Convert.ToInt32(row.Cells["Id"].Value);

                // Đẩy thông tin ngược lên ô nhập
                txtUsername.Text = Convert.ToString(row.Cells["TenDangNhap"].Value);
                txtPassword.Text = Convert.ToString(row.Cells["MatKhau"].Value);
                txtDisplayName.Text = Convert.ToString(row.Cells["TenHienThi"].Value);
                cboRole.Text = Convert.ToString(row.Cells["VaiTro"].Value);
            }
        }
    }
}

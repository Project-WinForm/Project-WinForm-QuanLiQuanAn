using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectWindowform.BLL; // Gọi lớp BLL

namespace projectWindowform.GUI
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private StaffBLL staffBLL = new StaffBLL();

        private void btnLoginn_Click(object sender, EventArgs e)
        {
            // Kiểm tra và loại bỏ chữ placeholder trước khi gửi xuống BLL kiểm tra đăng nhập
            string username = txtUserN.Text == "UserName" ? "" : txtUserN.Text;
            string password = txtPassW.Text == "Password" ? "" : txtPassW.Text;

            if (staffBLL.Login(username, password))
            {
                if (staffBLL.IsAdmin(username))
                {
                    MessageBox.Show("Đăng nhập thành công với quyền quản trị!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    Form2 mainForm = new Form2(); // Mở Form quản trị của Admin
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    Form1 mainForm = new Form1(); // Mở Form bán hàng của Nhân viên
                    mainForm.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phần load form để hiển thị placeholder cho TextBox
        private void Form4_Load(object sender, EventArgs e)
        {
            txtUserN.Text = "UserName";
            txtPassW.Text = "Password";

            txtPassW.UseSystemPasswordChar = false;

            // Đăng ký sự kiện thay đổi trạng thái tích chọn cho CheckBox
            chkShowPass.CheckedChanged += chkShowPass_CheckedChanged;
        }

        // Xử lý ẩn/hiện mật khẩu dựa vào trạng thái CheckBox
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu ô mật khẩu đang hiển thị chữ placeholder "Password" thì không che/hiện
            if (txtPassW.Text == "Password")
            {
                return;
            }

            // Nếu CheckBox được TÍCH (Checked == true) -> Sử dụng ký tự thường (false)
            // Nếu CheckBox bỏ tích (Checked == false) -> Sử dụng ký tự hệ thống để che (true)
            txtPassW.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        // Các sự kiện Enter và Leave để xử lý placeholder cho TextBox
        private void txtUserN_Enter(object sender, EventArgs e)
        {
            if (txtUserN.Text == "UserName")
            {
                txtUserN.Text = "";
            }
        }

        private void txtUserN_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserN.Text))
            {
                txtUserN.Text = "UserName";
            }
        }

        private void txtPassW_Enter(object sender, EventArgs e)
        {
            if (txtPassW.Text == "Password")
            {
                txtPassW.Text = "";

                // Khi bắt đầu gõ mật khẩu, dựa vào CheckBox để che hay hiện
                txtPassW.UseSystemPasswordChar = !chkShowPass.Checked;
            }
        }

        private void txtPassW_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassW.Text))
            {
                txtPassW.UseSystemPasswordChar = false;
                txtPassW.Text = "Password";
            }
        }
    }
}
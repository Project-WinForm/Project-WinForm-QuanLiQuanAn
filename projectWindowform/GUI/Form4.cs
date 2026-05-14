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
            if (staffBLL.IsAdmin(txtUserN.Text))
            {
                MessageBox.Show("Đăng nhập thành công với quyền quản trị!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 mainForm = new Form2();
                mainForm.ShowDialog();
                this.Close();
            }
            else if (staffBLL.Login(txtUserN.Text, txtPassW.Text))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.ShowDialog();
                this.Close();
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
                txtPassW.UseSystemPasswordChar = true;
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

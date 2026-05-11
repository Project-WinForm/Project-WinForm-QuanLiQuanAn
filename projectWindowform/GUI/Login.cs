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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private StaffBLL staffBLL = new StaffBLL(); 
  
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(staffBLL.IsAdmin(txtUsername.Text))
            {
                MessageBox.Show("Đăng nhập thành công với quyền quản trị!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form2 mainForm = new Form2();
                mainForm.ShowDialog();
                this.Close();
            }
            else if(staffBLL.Login(txtUsername.Text, txtPassword.Text))
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
    }
}

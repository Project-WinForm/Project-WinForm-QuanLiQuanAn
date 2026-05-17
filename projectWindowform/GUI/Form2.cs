using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectWindowform.GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private Form currentFormChild;

        // Đổi màu các nút menu khi được chọn
        private void SetActiveButton(Button checkedButton)
        {
            List<Button> menuButtons = new List<Button> { button1, button2, button3 };

            foreach (Button btn in menuButtons)
            {
                if (btn == checkedButton)
                {
                    // Nút được chọn: Đổi nền xanh, chữ trắng
                    btn.BackColor = Color.FromArgb(0, 51, 153);
                    btn.ForeColor = Color.White;
                }
                else
                {
                    // Nút khác: Trả về nền trắng, chữ đen
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                }
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            SetActiveButton(null);//cho all về cũ
            label1.Text = "Form Main ";
        }

        private void panel_Top_Paint(object sender, PaintEventArgs e)
        {

        }
       private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton(button1);
            OpenChildForm(new Form3());
            label1.Text = " Staff Management ";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton(button2);
            OpenChildForm( new Form5() );
            label1.Text = " Food Management ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveButton(button3);
            OpenChildForm( new Form6() );
            label1.Text = "StatisticForm";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận đăng xuất quyền Quản trị viên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide(); // Ẩn cửa sổ quản trị hệ thống

                projectWindowform.GUI.Form4 loginForm = new projectWindowform.GUI.Form4();
                loginForm.ShowDialog(); // Quay trở lại màn hình Đăng nhập

                this.Close();
            }
        }
    }
}

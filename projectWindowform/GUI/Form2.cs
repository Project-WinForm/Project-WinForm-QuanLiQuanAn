using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sunny.UI;

namespace projectWindowform.GUI
{
    public partial class Form2 : UIForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private Form currentFormChild;

        // Đổi màu các nút menu khi được chọn

        private void SetActiveButton(UIButton checkedButton)
        {
            List<UIButton> menuButtons = new List<UIButton>
    {
        btnNV,btnFood, btnCS

    };

            foreach (UIButton btn in menuButtons)
            {
                btn.Selected = (btn == checkedButton);
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
            label1.Text = "Form chính ";
        }


        private void uiButton1_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnNV);
            OpenChildForm(new Form3());
            label1.Text = " Form Quản Lí Nhân Viên ";
        }

        private void btnCS_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnCS);
            OpenChildForm(new Form6());
            label1.Text = "Form Thống Kê";
        }

        private void btnFood_Click(object sender, EventArgs e)
        {

            SetActiveButton(btnFood);
            OpenChildForm(new Form5());
            label1.Text = " Form Quản lí đồ ăn ";
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
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

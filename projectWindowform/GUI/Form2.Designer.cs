namespace projectWindowform.GUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnCS = new Sunny.UI.UIButton();
            this.btnFood = new Sunny.UI.UIButton();
            this.btnNV = new Sunny.UI.UIButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.btnDangXuat = new Sunny.UI.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_Top.SuspendLayout();
            this.panel_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Navy;
            this.panelLeft.Controls.Add(this.btnCS);
            this.panelLeft.Controls.Add(this.btnFood);
            this.panelLeft.Controls.Add(this.btnNV);
            this.panelLeft.Controls.Add(this.pictureBox1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 35);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(167, 764);
            this.panelLeft.TabIndex = 0;
            // 
            // btnCS
            // 
            this.btnCS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCS.FillHoverColor = System.Drawing.Color.LightGreen;
            this.btnCS.FillPressColor = System.Drawing.Color.ForestGreen;
            this.btnCS.FillSelectedColor = System.Drawing.Color.ForestGreen;
            this.btnCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCS.Location = new System.Drawing.Point(0, 254);
            this.btnCS.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCS.Name = "btnCS";
            this.btnCS.RectColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCS.RectDisableColor = System.Drawing.Color.LightGreen;
            this.btnCS.RectHoverColor = System.Drawing.Color.LimeGreen;
            this.btnCS.Size = new System.Drawing.Size(167, 72);
            this.btnCS.TabIndex = 7;
            this.btnCS.Text = "Thống kê";
            this.btnCS.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCS.Click += new System.EventHandler(this.btnCS_Click);
            // 
            // btnFood
            // 
            this.btnFood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFood.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFood.FillHoverColor = System.Drawing.Color.LightGreen;
            this.btnFood.FillPressColor = System.Drawing.Color.ForestGreen;
            this.btnFood.FillSelectedColor = System.Drawing.Color.ForestGreen;
            this.btnFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnFood.Location = new System.Drawing.Point(0, 182);
            this.btnFood.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFood.Name = "btnFood";
            this.btnFood.RectColor = System.Drawing.Color.LightGreen;
            this.btnFood.RectDisableColor = System.Drawing.Color.Lime;
            this.btnFood.Size = new System.Drawing.Size(167, 72);
            this.btnFood.TabIndex = 6;
            this.btnFood.Text = "Quản lí món ăn";
            this.btnFood.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnNV
            // 
            this.btnNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNV.FillHoverColor = System.Drawing.Color.LightGreen;
            this.btnNV.FillPressColor = System.Drawing.Color.ForestGreen;
            this.btnNV.FillSelectedColor = System.Drawing.Color.ForestGreen;
            this.btnNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnNV.Location = new System.Drawing.Point(0, 110);
            this.btnNV.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnNV.Name = "btnNV";
            this.btnNV.RectColor = System.Drawing.Color.LightGreen;
            this.btnNV.RectDisableColor = System.Drawing.Color.Lime;
            this.btnNV.Size = new System.Drawing.Size(167, 72);
            this.btnNV.TabIndex = 5;
            this.btnNV.Text = "Nhân Viên";
            this.btnNV.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNV.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::projectWindowform.Properties.Resources.z7815713005338_dabb52cdbdac8b58406864113719fe9a;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Navy;
            this.panel_Top.Controls.Add(this.btnDangXuat);
            this.panel_Top.Controls.Add(this.label1);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(167, 35);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(1399, 128);
            this.panel_Top.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDangXuat.FillHoverColor = System.Drawing.Color.LightGreen;
            this.btnDangXuat.FillPressColor = System.Drawing.Color.ForestGreen;
            this.btnDangXuat.FillSelectedColor = System.Drawing.Color.ForestGreen;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDangXuat.Location = new System.Drawing.Point(1248, 0);
            this.btnDangXuat.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.RectColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDangXuat.Size = new System.Drawing.Size(151, 128);
            this.btnDangXuat.TabIndex = 8;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(517, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trang chính";
            // 
            // panel_Body
            // 
            this.panel_Body.Controls.Add(this.pictureBox2);
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(167, 163);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(1399, 636);
            this.panel_Body.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::projectWindowform.Properties.Resources.Gemini_Generated_Image_d0rne1d0rne1d0rn;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1399, 636);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1566, 799);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.panelLeft);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 1456, 686);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            this.panel_Body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Body;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIButton btnNV;
        private Sunny.UI.UIButton btnCS;
        private Sunny.UI.UIButton btnFood;
        private Sunny.UI.UIButton btnDangXuat;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
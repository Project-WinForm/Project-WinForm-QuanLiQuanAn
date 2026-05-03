namespace tieuluan
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.flpThucdon = new System.Windows.Forms.FlowLayoutPanel();
            this.lsvHoadon = new System.Windows.Forms.ListView();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThemmon = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.nmrSoluong = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSoluong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nmrSoluong);
            this.panel1.Controls.Add(this.btnThanhtoan);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThemmon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 100);
            this.panel1.TabIndex = 0;
            // 
            // flpTables
            // 
            this.flpTables.AutoScroll = true;
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpTables.Location = new System.Drawing.Point(0, 0);
            this.flpTables.Name = "flpTables";
            this.flpTables.Size = new System.Drawing.Size(238, 431);
            this.flpTables.TabIndex = 1;
            // 
            // flpThucdon
            // 
            this.flpThucdon.AutoScroll = true;
            this.flpThucdon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpThucdon.Location = new System.Drawing.Point(238, 0);
            this.flpThucdon.Name = "flpThucdon";
            this.flpThucdon.Size = new System.Drawing.Size(1010, 431);
            this.flpThucdon.TabIndex = 2;
            // 
            // lsvHoadon
            // 
            this.lsvHoadon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lsvHoadon.HideSelection = false;
            this.lsvHoadon.Location = new System.Drawing.Point(3, 3);
            this.lsvHoadon.Name = "lsvHoadon";
            this.lsvHoadon.Size = new System.Drawing.Size(308, 400);
            this.lsvHoadon.TabIndex = 3;
            this.lsvHoadon.UseCompatibleStateImageBehavior = false;
            this.lsvHoadon.View = System.Windows.Forms.View.Details;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.lsvHoadon);
            this.flowLayoutPanel5.Controls.Add(this.lblTong);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(940, 0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(308, 431);
            this.flowLayoutPanel5.TabIndex = 3;
            // 
            // btnThemmon
            // 
            this.btnThemmon.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemmon.Location = new System.Drawing.Point(553, 28);
            this.btnThemmon.Name = "btnThemmon";
            this.btnThemmon.Size = new System.Drawing.Size(150, 60);
            this.btnThemmon.TabIndex = 0;
            this.btnThemmon.Text = "THÊM MÓN";
            this.btnThemmon.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(989, 28);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(106, 60);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "XÓA MÓN";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhtoan.Location = new System.Drawing.Point(1115, 28);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(106, 60);
            this.btnThanhtoan.TabIndex = 2;
            this.btnThanhtoan.Text = "THANH TOÁN";
            this.btnThanhtoan.UseVisualStyleBackColor = true;
            // 
            // nmrSoluong
            // 
            this.nmrSoluong.Location = new System.Drawing.Point(415, 28);
            this.nmrSoluong.Name = "nmrSoluong";
            this.nmrSoluong.Size = new System.Drawing.Size(120, 22);
            this.nmrSoluong.TabIndex = 3;
            this.nmrSoluong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số lượng:";
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTong.ForeColor = System.Drawing.Color.Red;
            this.lblTong.Location = new System.Drawing.Point(3, 406);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(115, 25);
            this.lblTong.TabIndex = 4;
            this.lblTong.Text = "Tổng tiền:";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tên món";
            this.columnHeader4.Width = 126;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số lượng";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 65;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Thành tiền";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 111;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1248, 531);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.flpThucdon);
            this.Controls.Add(this.flpTables);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSoluong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.NumericUpDown nmrQuantity;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpTables;
        private System.Windows.Forms.FlowLayoutPanel flpThucdon;
        private System.Windows.Forms.ListView lsvHoadon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmrSoluong;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThemmon;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}


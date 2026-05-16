namespace projectWindowform.GUI
{
    partial class Form6
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFrom = new Sunny.UI.UIDatetimePicker();
            this.dtTo = new Sunny.UI.UIDatetimePicker();
            this.btnThongKe = new Sunny.UI.UIButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel_Revenue = new System.Windows.Forms.Panel();
            this.lblRevenueTitle = new Sunny.UI.UILabel();
            this.lblTotalRevenue = new Sunny.UI.UILabel();
            this.pnlFood = new System.Windows.Forms.Panel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.lblFoodTitle = new Sunny.UI.UILabel();
            this.pnlBill = new System.Windows.Forms.Panel();
            this.lblTotalBill = new Sunny.UI.UILabel();
            this.lblBillTitle = new Sunny.UI.UILabel();
            this.uiBarChart2 = new Sunny.UI.UIBarChart();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiBarChart1 = new Sunny.UI.UIBarChart();
            this.groupBox1.SuspendLayout();
            this.panel_Revenue.SuspendLayout();
            this.pnlFood.SuspendLayout();
            this.pnlBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "From: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(369, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "To: ";
            // 
            // dtFrom
            // 
            this.dtFrom.DateCultureInfo = new System.Globalization.CultureInfo("en-US");
            this.dtFrom.DateFormat = "dd/MM/yyyy";
            this.dtFrom.FillColor = System.Drawing.Color.White;
            this.dtFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Location = new System.Drawing.Point(103, 30);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtFrom.MaxLength = 10;
            this.dtFrom.MinimumSize = new System.Drawing.Size(55, 0);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtFrom.Size = new System.Drawing.Size(213, 31);
            this.dtFrom.SymbolDropDown = 61555;
            this.dtFrom.SymbolNormal = 61555;
            this.dtFrom.SymbolSize = 24;
            this.dtFrom.TabIndex = 3;
            this.dtFrom.Text = "16/05/2026";
            this.dtFrom.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dtFrom.Value = new System.DateTime(2026, 5, 16, 20, 51, 29, 952);
            this.dtFrom.Watermark = "";
            // 
            // dtTo
            // 
            this.dtTo.DateCultureInfo = new System.Globalization.CultureInfo("en-US");
            this.dtTo.DateFormat = "dd/MM/yyyy";
            this.dtTo.FillColor = System.Drawing.Color.White;
            this.dtTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Location = new System.Drawing.Point(447, 27);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtTo.MaxLength = 10;
            this.dtTo.MinimumSize = new System.Drawing.Size(55, 0);
            this.dtTo.Name = "dtTo";
            this.dtTo.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtTo.Size = new System.Drawing.Size(213, 34);
            this.dtTo.SymbolDropDown = 61555;
            this.dtTo.SymbolNormal = 61555;
            this.dtTo.SymbolSize = 24;
            this.dtTo.TabIndex = 4;
            this.dtTo.Text = "16/05/2026";
            this.dtTo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dtTo.Value = new System.DateTime(2026, 5, 16, 20, 51, 29, 952);
            this.dtTo.Watermark = "";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThongKe.Location = new System.Drawing.Point(746, 27);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnThongKe.MaximumSize = new System.Drawing.Size(93, 30);
            this.btnThongKe.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Radius = 1;
            this.btnThongKe.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThongKe.Size = new System.Drawing.Size(93, 30);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Statistics";
            this.btnThongKe.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThongKe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1386, 106);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // panel_Revenue
            // 
            this.panel_Revenue.BackColor = System.Drawing.Color.White;
            this.panel_Revenue.Controls.Add(this.lblTotalRevenue);
            this.panel_Revenue.Controls.Add(this.lblRevenueTitle);
            this.panel_Revenue.Location = new System.Drawing.Point(117, 115);
            this.panel_Revenue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel_Revenue.Name = "panel_Revenue";
            this.panel_Revenue.Size = new System.Drawing.Size(299, 106);
            this.panel_Revenue.TabIndex = 7;
            // 
            // lblRevenueTitle
            // 
            this.lblRevenueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblRevenueTitle.Location = new System.Drawing.Point(2, 21);
            this.lblRevenueTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRevenueTitle.Name = "lblRevenueTitle";
            this.lblRevenueTitle.Size = new System.Drawing.Size(169, 27);
            this.lblRevenueTitle.TabIndex = 0;
            this.lblRevenueTitle.Text = "Total Revenue:";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Green;
            this.lblTotalRevenue.Location = new System.Drawing.Point(148, 15);
            this.lblTotalRevenue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(149, 36);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "uiLabel2";
            // 
            // pnlFood
            // 
            this.pnlFood.BackColor = System.Drawing.Color.White;
            this.pnlFood.Controls.Add(this.uiLabel5);
            this.pnlFood.Controls.Add(this.lblFoodTitle);
            this.pnlFood.Location = new System.Drawing.Point(762, 112);
            this.pnlFood.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlFood.Name = "pnlFood";
            this.pnlFood.Size = new System.Drawing.Size(296, 106);
            this.pnlFood.TabIndex = 8;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel5.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.uiLabel5.Location = new System.Drawing.Point(140, 15);
            this.uiLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(146, 33);
            this.uiLabel5.TabIndex = 1;
            this.uiLabel5.Text = "uiLabel5";
            // 
            // lblFoodTitle
            // 
            this.lblFoodTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFoodTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblFoodTitle.Location = new System.Drawing.Point(14, 21);
            this.lblFoodTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFoodTitle.Name = "lblFoodTitle";
            this.lblFoodTitle.Size = new System.Drawing.Size(108, 24);
            this.lblFoodTitle.TabIndex = 0;
            this.lblFoodTitle.Text = "Total Food Sell: ";
            // 
            // pnlBill
            // 
            this.pnlBill.BackColor = System.Drawing.Color.White;
            this.pnlBill.Controls.Add(this.lblTotalBill);
            this.pnlBill.Controls.Add(this.lblBillTitle);
            this.pnlBill.Location = new System.Drawing.Point(447, 112);
            this.pnlBill.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Size = new System.Drawing.Size(290, 106);
            this.pnlBill.TabIndex = 9;
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalBill.Location = new System.Drawing.Point(120, 12);
            this.lblTotalBill.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(149, 36);
            this.lblTotalBill.TabIndex = 1;
            this.lblTotalBill.Text = "uiLabel7";
            // 
            // lblBillTitle
            // 
            this.lblBillTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBillTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblBillTitle.Location = new System.Drawing.Point(12, 21);
            this.lblBillTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBillTitle.Name = "lblBillTitle";
            this.lblBillTitle.Size = new System.Drawing.Size(104, 24);
            this.lblBillTitle.TabIndex = 0;
            this.lblBillTitle.Text = "Total Bill: ";
            // 
            // uiBarChart2
            // 
            this.uiBarChart2.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiBarChart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiBarChart2.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiBarChart2.Location = new System.Drawing.Point(711, 21);
            this.uiBarChart2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.uiBarChart2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBarChart2.Name = "uiBarChart2";
            this.uiBarChart2.Size = new System.Drawing.Size(673, 262);
            this.uiBarChart2.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiBarChart2.TabIndex = 11;
            this.uiBarChart2.Text = "TOP 5 MÓN BÁN CHẠY";
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.uiDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle13;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 513);
            this.uiDataGridView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.uiDataGridView1.Name = "uiDataGridView1";
            this.uiDataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.uiDataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.uiDataGridView1.RowTemplate.Height = 24;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.Size = new System.Drawing.Size(1386, 245);
            this.uiDataGridView1.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiBarChart1);
            this.groupBox2.Controls.Add(this.uiBarChart2);
            this.groupBox2.Location = new System.Drawing.Point(0, 227);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(1386, 286);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // uiBarChart1
            // 
            this.uiBarChart1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiBarChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiBarChart1.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiBarChart1.Location = new System.Drawing.Point(2, 21);
            this.uiBarChart1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.uiBarChart1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBarChart1.Name = "uiBarChart1";
            this.uiBarChart1.Size = new System.Drawing.Size(674, 262);
            this.uiBarChart1.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiBarChart1.TabIndex = 11;
            this.uiBarChart1.Text = "DOANH THU THEO NGÀY";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1386, 758);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.uiDataGridView1);
            this.Controls.Add(this.pnlBill);
            this.Controls.Add(this.pnlFood);
            this.Controls.Add(this.panel_Revenue);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form6";
            this.Text = "Form6";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_Revenue.ResumeLayout(false);
            this.pnlFood.ResumeLayout(false);
            this.pnlBill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UIDatetimePicker dtFrom;
        private Sunny.UI.UIDatetimePicker dtTo;
        private Sunny.UI.UIButton btnThongKe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel_Revenue;
        private Sunny.UI.UILabel lblTotalRevenue;
        private Sunny.UI.UILabel lblRevenueTitle;
        private System.Windows.Forms.Panel pnlFood;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel lblFoodTitle;
        private System.Windows.Forms.Panel pnlBill;
        private Sunny.UI.UILabel lblTotalBill;
        private Sunny.UI.UILabel lblBillTitle;
        private Sunny.UI.UIBarChart uiBarChart2;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Sunny.UI.UIBarChart uiBarChart1;
    }
}
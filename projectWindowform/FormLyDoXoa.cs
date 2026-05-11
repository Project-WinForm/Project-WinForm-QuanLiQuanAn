using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectWindowform
{
    public partial class FormLyDoXoa : Form
    {
        public FormLyDoXoa()
        {
            InitializeComponent();
        }
        public string LyDoChon { get; set; }

        private void AllButtons_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            LyDoChon = btn.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

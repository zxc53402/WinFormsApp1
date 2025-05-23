using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.初次練習;

namespace WinFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void 訂單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createorders frm = new createorders();
            frm.ShowDialog();
        }

        private void 產品資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.ShowDialog();
        }

        private void 訂單明細ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orders frm = new orders();
            frm.ShowDialog();
        }

        private void 供應商資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers frm = new Suppliers();
            frm.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void 查詢練習ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void 新增練習ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void 修改練習ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form3 frm = new Form3();
            frm.Show();
        }

        private void 刪除練習ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form4 frm = new Form4();
            frm.Show();
        }

        private void 查詢練習ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Work1 frm = new Work1();
            frm.Show();
        }

        private void 新增練習ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Work2 frm = new Work2();
            frm.Show();
        }

        private void 刪除練習ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Work3 frm = new Work3();
            frm.Show();
        }

        private void 修改練習ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Work4 frm = new Work4();
            frm.Show();
        }

        private void 產品下單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 frm = new Form10();
            frm.Show();
        }

        private void 新增產品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 frm = new Form9();
            frm.Show();
        }

        private void 新增產品種類ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 frm = new Form11();
            frm.Show();
        }

        private void 新增供應商ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 frm = new Form12();
            frm.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }
    }
}

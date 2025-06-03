using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class createsuppliers : Form
    {
        public createsuppliers()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("請輸入公司名稱及負責人!!!");
                return;
            }
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");

            var CN = textBox1.Text;
            var CtN = textBox2.Text;
            var CT = textBox3.Text;
            var Ad = textBox4.Text;
            var Ct = textBox5.Text;
            string Ph = textBox9.Text;

            var sql = "insert into Suppliers (CompanyName" +
                ",ContactName" +
                ",ContactTitle" +
                ",Address" +
                ",City" +
                ",Phone" +
                ",Fax" +
                ") values (" +
                "'" + CN + "'," +
                "'" + CtN + "'," +
                "'" + CT + "'," +
                "'" + Ad + "'," +
                "'" + Ct + "'," +
                "'" + Ph + "')";

            var rowsaffected = con.Execute(sql);
            if (rowsaffected > 0)
            {
                MessageBox.Show("新增成功");
            }
            else
            {
                MessageBox.Show("新增失敗");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

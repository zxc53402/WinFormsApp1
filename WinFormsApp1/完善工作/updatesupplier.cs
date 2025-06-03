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
using WinFormsApp1.Class;

namespace WinFormsApp1
{
    public partial class updatesupplier : Form
    {
        public string supID { get; set; }
        List<Suppliers1> suppliers;
        private Suppliers Suppliers;
        public updatesupplier(Suppliers Suppliers)
        {
            InitializeComponent();
            this.Suppliers = Suppliers;
        }

        private void updatesupplier_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql = "select *from Suppliers where SupplierID = @SupplierID";
            var results = con.Query<Suppliers1>(sql, new { SupplierID = supID }).ToList();
            suppliers = results;
            textBox1.Text = suppliers.FirstOrDefault()?.CompanyName;
            textBox2.Text = suppliers.FirstOrDefault()?.ContactName;
            textBox3.Text = suppliers.FirstOrDefault()?.ContactTitle;
            textBox4.Text = suppliers.FirstOrDefault()?.Address;
            textBox5.Text = suppliers.FirstOrDefault()?.City;
            textBox9.Text = suppliers.FirstOrDefault()?.Phone;
        }

        private void button1_Click(object sender, EventArgs e)
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

            var sql = "Update Suppliers set " +
                " CompanyName = @CompanyName, " +
                " ContactName = @ContactName, " +
                " ContactTitle = @ContactTitle, " +
                " Address = @Address, " +
                " City = @City, " +
                " Phone = @Phone " +
                " where SupplierID = @SupplierID";          

            var rowsaffected = con.Execute(sql, new { 
                CompanyName = CN,
                ContactName = CtN,
                ContactTitle = CT,
                Address = Ad,
                City = Ct,
                Phone = Ph,
                SupplierID = supID
            });
            if (rowsaffected > 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
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

        private void updatesupplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            Suppliers.sprefresh();
        }
    }
}

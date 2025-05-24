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
    public partial class Customer : Form
    {
        List<Customers> customera;
        public Customer()
        {
            InitializeComponent();
        }
        private void formloadagain()
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var results = con.Query<Customers>("select * from Customers").ToList();
            customera = results;
            var dGVct = customera.Select(x => new { x.CompanyName, x.ContactName, x.ContactTitle, x.Address, x.City, x.Country, x.Phone }).ToList();
            dataGridView1.DataSource = dGVct;
            customera.Insert(0, new Customers { CustomerID = "0", CompanyName = "-- 請選擇 --" });
            comboBox1.DataSource = customera;
            comboBox1.DisplayMember = "CompanyName";
            comboBox1.ValueMember = "CustomerID";
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            formloadagain();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Customers> customera=new List<Customers>();
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var cbc = comboBox1.SelectedValue;
            if (cbc != "0")
            {
                var sql = "select * from Customers where CustomerID = @customerID";
                var results2 = con.Query<Customers>(sql, new { customerID = cbc }).ToList();
                customera=results2;
                var dGVct2 = customera.Select(x => new { x.CompanyName, x.ContactName, x.ContactTitle, x.Address, x.City, x.Country, x.Phone }).ToList();
                dataGridView1.DataSource= dGVct2;
            }
            else
            {
                formloadagain();
            }
        }      

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != "0")
            {
                Form3 f3 = new Form3();
                f3.come = comboBox1.SelectedValue.ToString();
                f3.Show();
            }
            else
            {
                MessageBox.Show("請選擇公司名稱");
            }
        }
    }
}

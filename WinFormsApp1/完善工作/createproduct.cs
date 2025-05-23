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
    public partial class createproduct : Form
    {
        public createproduct()
        {
            InitializeComponent();
        }
        List<string> List1;
        List<string> List2;

        private void Form9_Load(object sender, EventArgs e)
        {
            List1 = new List<string>();
            List2 = new List<string>();
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var results1 = con.Query<dynamic>("select CategoryName,CategoryID from Categories ").ToList();
            var results2 = con.Query<dynamic>("select CompanyName,SupplierID from Suppliers ").ToList();
            foreach (var item in results1)
            {
                comboBox1.Items.Add(item.CategoryName);
                List1.Add(item.CategoryID.ToString());
            }
            foreach (var item in results2)
            {
                comboBox2.Items.Add(item.CompanyName);
                List2.Add(item.SupplierID.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var Name = textBox1.Text;
            var SP = List2[comboBox2.SelectedIndex];
            var CG = List1[comboBox1.SelectedIndex];
            var QP = textBox2.Text;
            var UP = textBox3.Text;
            var UI = textBox4.Text;
            var UO = textBox5.Text;
            var RL = textBox6.Text;
            var Dt = textBox7.Text;
            var sql = "insert into Products (" +
                      "ProductName" +
                      ",SupplierID" +
                      ",CategoryID" +
                      ",QuantityPerUnit" +
                      ",UnitPrice" +
                      ",UnitsInStock" +
                      ",UnitsOnOrder" +
                      ",ReorderLevel" +
                      ",Discontinued)" +
                      "values" +
                      "('" + Name +
                      "','" + SP +
                      "','" + CG +
                      "','" + QP +
                      "','" + UP +
                      "','" + UI +
                      "','" + UO +
                      "','" + RL +
                      "','" + Dt +
                      "')";
            var rowsaffected = con.Execute(sql);
            if(rowsaffected > 0)
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

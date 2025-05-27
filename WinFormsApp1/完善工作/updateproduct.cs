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
    
    public partial class updateproduct : Form
    {
        public string? upp { get; set; }
        List<Products> pds;
        List<Category> ctg;
        List<Suppliers1> sp1;
        public updateproduct()
        {
            InitializeComponent();
        }
        private void updateproduct_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql1 = "select CategoryID,CategoryName from Categories";
            var results1 = con.Query<Category>(sql1).ToList();
            ctg = results1;
            var sql2 = "select SupplierID,CompanyName from Suppliers";
            var results2 = con.Query<Suppliers1>(sql2).ToList();
            sp1 = results2;
            comboBox1.DataSource = ctg;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
            comboBox2.DataSource = sp1;
            comboBox2.DisplayMember = "CompanyName";
            comboBox2.ValueMember = "SupplierID";


            var sql = "  select " +
                "a.ProductName," +
                "a.CategoryID," +                
                "a.SupplierID," +
                "c.CompanyName as SupplierName," +
                "b.CategoryName," +
                "a.UnitPrice," +
                "a.UnitsInStock " +
                "from Products a  " +
                "left  join Categories b  on a.CategoryID = b.CategoryID " +
                "left  join Suppliers c on a.SupplierID = c.SupplierID  " +
                "where a.ProductID = @productID";
            var results = con.Query<Products>(sql, new { productID = upp }).ToList();
            pds = results;
            var ctID = pds[0].CategoryID;
            var supID = pds[0].SupplierID;
            textBox1.Text = pds.FirstOrDefault()?.ProductName;
            comboBox1.SelectedValue = ctID;
            comboBox2.SelectedValue = supID;
            textBox4.Text = pds.FirstOrDefault()?.UnitPrice;
            textBox5.Text = pds.FirstOrDefault()?.UnitsInStock;
        }
            private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql3 = "Update Products set " +
                "ProductName=@productName, " +
                "CategoryID=@categoryID, " +
                "SupplierID=@supplierID, " +
                "UnitPrice=@unitPrice, " +
                "UnitsInStock=@unitsInStock " +
                "where ProductID = @productID";
            var results1 = con.Query<Customers>(sql3, new
            {
                productName = textBox1.Text,
                categoryID = comboBox1.SelectedValue,
                supplierID = comboBox2.SelectedValue,
                unitPrice = textBox4.Text,
                UnitsInStock = textBox5.Text,
                productID = upp,                   
            });
            if (results1 != null)
            {
                MessageBox.Show("修改成功");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

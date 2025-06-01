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


namespace WinFormsApp1.初次練習
{
    public partial class ProductForm : Form
    {
        List<Category> category;        
        List<Products2> products2;
        List<Suppliers1> suppliers;
        public ProductForm()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");            
            var results = con.Query<Category>("select CategoryID,CategoryName from Categories").ToList();
            //var results4 = con.Query<Suppliers1>("select distinct SupplierID,CompanyName from Suppliers").ToList();
            category = results;
            
            category.Insert(0, new Category { CategoryID = "0", CategoryName = "" });

            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
            comboBox1.DataSource = category; 
            GetSupplier("");

            //comboBox2.DataSource = suppliers.ToList();
            //comboBox2.DisplayMember = "CompanyName";
            //comboBox2.ValueMember = "SupplierID";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");

            var sCategory = comboBox1.SelectedValue?.ToString()??"";
            var sSupplier = comboBox2.SelectedValue?.ToString()??"";
            var sql = "SELECT ";
            sql = sql + "  a.ProductID,";
            sql = sql + "  a.ProductName,";
            sql = sql + "  b.CompanyName AS SupplierName,";
            sql = sql + "  a.QuantityPerUnit,";
            sql = sql + "  a.UnitPrice,a.UnitsInStock,";
            sql = sql + "  a.ReorderLevel,";
            sql = sql + "  a.Discontinued ";
            sql = sql + "FROM Products a "; 
            sql = sql + "left join Suppliers b on a.SupplierID = b.SupplierID";
            sql = sql + " where 1 = 1 ";
            if (sCategory.Length > 0 && sCategory != "0") sql = sql + " and a.CategoryID = @Category";
            if (sSupplier.Length > 0 && sSupplier !="0") sql = sql + " and a.SupplierID = @Supplier";
            var results = con.Query<Products2>(sql, new { 
                Category = sCategory,
                Supplier = sSupplier
            }).ToList();           
            products2 = results;
            dataGridView1.DataSource = products2;

 

            //string selectedID = comboBox1.SelectedValue.ToString();
            //string selectedID2 = comboBox2.SelectedValue.ToString();
            //var sql = "SELECT " +
            //        "a.ProductID," +
            //        "a.ProductName," +
            //        "b.CompanyName AS SupplierName," +
            //        "a.QuantityPerUnit," +
            //        "a.UnitPrice,a.UnitsInStock," +
            //        "a.ReorderLevel," +
            //        "a.Discontinued " +
            //        "FROM Products a left join Suppliers b on a.SupplierID = b.SupplierID";

            //var sqlW = " where";
            //var sqland = " and";
            //var sql1 = " a.CategoryID = @Category";
            //var sql2 = " a.SupplierID = @Supplier";

            //if (selectedID != "0" && selectedID2 == "0")
            //{
            //    var results2 = con.Query<Products>(sql+sqlW+sql1, new { Category = selectedID }).ToList();
            //    products = results2;
            //}
            //if(selectedID=="0"&& selectedID2 != "0")
            //{
            //    var results2 = con.Query<Products>(sql+sqlW+sql2, new { Supplier = selectedID2 }).ToList();
            //    products = results2;
            //}
            //if(selectedID != "0" && selectedID2 != "0")
            //{
            //    var results2 = con.Query<Products>(sql + sqlW +sql1+sqland+ sql2, new { Category = selectedID, Supplier = selectedID2 }).ToList();
            //    products = results2;
            //}
            //if(selectedID == "0" && selectedID2 == "0")
            //{
            //    MessageBox.Show("請選擇產品種類或供應商");
            //}            
            //dataGridView1.DataSource = products;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column1" && e.RowIndex >= 0)
            {
                var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
                // 可先詢問是否刪除
                var result3 = MessageBox.Show("是否確定刪除這一列？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result3 == DialogResult.Yes)
                {
                    // 取得目前這列的資料對象
                    var pd1 = (Products2)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                    //先刪資料庫
                    var results3 = con.Execute("delete from Products where ProductID = @product",
                            new { product = pd1.ProductID });

                    // 從 list 中移除
                    products2.Remove(pd1);
                    if (products2.Count > 0)
                    {
                        MessageBox.Show("成功刪除 " + results3 + "項資料");
                    }

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = products2;
                }
            }
            if(dataGridView1.Columns[e.ColumnIndex].Name == "Column2" && e.RowIndex >= 0)
            {
                
                var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
                var pd1 = (Products2)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                updateproduct f2 = new updateproduct();
                f2.upp = pd1.ProductID;
                f2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            createproduct frm = new createproduct();
            frm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var selectedItem = (Category)comboBox1.SelectedItem;
            //GetSupplier(selectedItem.CategoryID??"");

            var selectedItem = comboBox1.SelectedValue?.ToString()??"";
            GetSupplier(selectedItem);
        }
        private void GetSupplier(string fsCategory ="")
        {          

            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql = "select distinct a.SupplierID,a.CompanyName " +
                " from Suppliers a " +
                " join Products b on a.SupplierID = b.SupplierID " +
                " join Categories c on b.CategoryID = c.CategoryID ";
                
            if(fsCategory != "") sql = sql + " where c.CategoryID = @categoryID"; 
            var results = con.Query<Suppliers1>(sql, new {
                categoryID = (fsCategory != "" ? Convert.ToInt16(fsCategory) : 0)
            }).ToList();
            results.Insert(0, new Suppliers1 { SupplierID = "0", CompanyName = "" });
            comboBox2.DisplayMember = "CompanyName";
            comboBox2.ValueMember = "SupplierID";
            comboBox2.DataSource = results;
        }
    }
}

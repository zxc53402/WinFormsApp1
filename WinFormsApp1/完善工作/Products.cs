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
        List<Products> products;
        public ProductForm()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");            
            var results = con.Query<Category>("select CategoryID,CategoryName,Description from Categories").ToList();
            category = results;
            string categoryID;
            string categoryName;
            foreach (var item in category)
            {
                categoryID = item.CategoryID ?? "";
                categoryName = item.CategoryName ?? "";                    
            }
            comboBox1.DataSource = category.ToList(); 
            comboBox1.DisplayMember = "CategoryName"; 
            comboBox1.ValueMember = "CategoryID";            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            string selectedID = comboBox1.SelectedValue.ToString();
            var results2 =con.Query<Products>("SELECT " +
                "a.ProductID," +
                "a.ProductName," +
                "b.CompanyName AS SupplierName," +
                "a.QuantityPerUnit," +
                "a.UnitPrice,a.UnitsInStock," +
                "a.ReorderLevel," +
                "a.Discontinued " +
                "FROM Products a left join Suppliers b on a.SupplierID = b.SupplierID " +
                "where a.CategoryID = '"+ selectedID + "'").ToList();
            products = results2;
            dataGridView1.DataSource = products;          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column1" && e.RowIndex >= 0)
            {
                var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
                // 可先詢問是否刪除
                var result = MessageBox.Show("是否確定刪除這一列？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (result == DialogResult.Yes)
                    {
                        // 取得目前這列的資料對象
                        var pd1 = (Products)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                        // 從 list 中移除
                        products.Remove(pd1);
                        var pd2 = pd1.ProductID;
                        if(products.Count > 0)
                        {
                            var results3 = con.Execute("delete from Products where ProductID = '" + pd2 + "'");
                            MessageBox.Show("成功刪除 " + results3 + "項資料");
                        }
                       
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = products;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            createproduct frm = new createproduct();
            frm.ShowDialog();
        }
    }
}

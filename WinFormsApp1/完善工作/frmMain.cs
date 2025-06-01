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
            this.Hide();
            createorders frm = new createorders();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();            
        }

        private void 產品資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm frm = new ProductForm();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();            
        }

        private void 訂單明細ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            orders frm = new orders();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();           
        }

        private void 供應商資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Suppliers frm = new Suppliers();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void 顧客資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer frm = new Customer();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
        }
        
        
        

        private void frmMain_Load(object sender, EventArgs e)
        {            
            //var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            //var sql = "select " +
            //    "c.ProductName," +
            //    "SUM(Quantity) as Quantity " +
            //    "from Orders a " +
            //    "left join [Order Details] b on a.OrderID = b.OrderID " +
            //    "left join Products c on b.ProductID = c.ProductID ";
            //var sqlnow = "where OrderDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) " +
            //    "AND OrderDate<DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) " +
            //    "AND c.ProductName IS NOT NULL " +
            //    "GROUP BY c.ProductName ";
            //var result = con.Query<TotaltotalQuantity>(sql+ sqlnow).ToList();
            //dataGridView1.DataSource = result;
            //dataGridView1.RowHeadersVisible = false;
            //var sql2 = "select " +
            //    "d.CompanyName," +
            //    "COUNT(*) AS Ordervolume," +
            //    "SUM(b.Quantity * b.UnitPrice) AS TotalSales " +
            //    "from Orders a " +
            //    "left join [Order Details] b on a.OrderID=b.OrderID " +
            //    "left join Products c on b.ProductID = c.ProductID " +
            //    "left join Customers d on a.CustomerID = d.CustomerID ";
            //var sqlnow2 = "where OrderDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) " +
            //    "AND OrderDate < DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) " +
            //    "GROUP BY d.CompanyName " +
            //    "HAVING SUM(b.Quantity * b.UnitPrice) > 0; ";

            //var result2 = con.Query<TotalSales>(sql2+ sqlnow2).ToList();
            //dataGridView2.DataSource = result2;
            //dataGridView2.RowHeadersVisible = false;
            for (int month = 1; month <= 12; month++)
            {
                comboBox1.Items.Add("" + month + "月");
            }
            
            int nowyear = DateTime.Now.Year;
            for (int year = nowyear-10; year <= nowyear + 10; year++)
            {
                comboBox2.Items.Add("" + year + "年");
            }
            comboBox1.SelectedIndex = DateTime.Now.Month - 2;
            comboBox2.SelectedItem = nowyear+"年";            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
        private void RefreshDataGrid()
        {
            string selected = comboBox1.Text;
            string selected2 = comboBox2.Text;
            if (selected != "" && selected2 != "")
            {
                using (var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;"))
                {
                    var sql = "select " +
                    "c.ProductName," +
                    "SUM(Quantity) as Quantity " +
                    "from Orders a " +
                    "left join [Order Details] b on a.OrderID = b.OrderID " +
                    "left join Products c on b.ProductID = c.ProductID ";
                    var sql2 = "select " +
                        "d.CompanyName," +
                        "COUNT(*) AS Ordervolume," +
                        "SUM(ISNULL(b.Quantity, 0) * ISNULL(b.UnitPrice, 0)) AS TotalSales " +
                        "from Orders a " +
                        "left join [Order Details] b on a.OrderID=b.OrderID " +
                        "left join Products c on b.ProductID = c.ProductID " +
                        "left join Customers d on a.CustomerID = d.CustomerID ";
                    int month = int.Parse(selected.Replace("月", ""));
                    int year = int.Parse(selected2.Replace("年", ""));
                    var sqlc = "WHERE YEAR(OrderDate) = @year AND MONTH(OrderDate) = @month ";                      
                    var GB1 = "AND B.ProductID is not null "+
                        "GROUP BY c.ProductName ";
                    var GB2 = "GROUP BY d.CompanyName "
                        /*"HAVING SUM(b.Quantity * b.UnitPrice) > 0; "*/;

                    if (selected != null && selected2 != null)
                    {
                        sql = sql + sqlc + GB1;
                        sql2 = sql2 + sqlc + GB2;
                    }
                    var result = con.Query<TotaltotalQuantity>(sql, new { year = year, month = month }).ToList();
                    dataGridView1.DataSource = result;
                    dataGridView1.RowHeadersVisible = false;
                    var result2 = con.Query<TotalSales>(sql2, new { year = year, month = month }).ToList();
                    dataGridView2.DataSource = result2;
                    dataGridView2.RowHeadersVisible = false;

                    //var sqlnow2 = "where OrderDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) " +
                    //    "AND OrderDate < DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) " +
                    //    "GROUP BY d.CompanyName " +
                    //    "HAVING SUM(b.Quantity * b.UnitPrice) > 0; ";


                }
            }
        }
    }
}

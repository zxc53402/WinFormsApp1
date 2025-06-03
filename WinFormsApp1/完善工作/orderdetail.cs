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
    public partial class orderdetail : Form
    {
        public string oDID { get; set; }        
        List<Odetail> odetail;
        public orderdetail()
        {
            InitializeComponent();
        }

        private void orderdetail_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql = "  select " +
                "b.ProductName," +
                "a.UnitPrice," +
                "a.Quantity," +
                "a.Discount  " +
                "from[Order Details] a " +
                "left join Products b on a.ProductID = b.ProductID  " +
                "where a.OrderID = @OrderID";
            var result = con.Query<Odetail>(sql, new {OrderID = oDID}).ToList();
            odetail = result;
            dataGridView1.DataSource = odetail;
            label3.Text = oDID;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

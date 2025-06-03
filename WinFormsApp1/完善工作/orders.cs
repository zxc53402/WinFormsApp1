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
    public partial class orders : Form
    {
        List<Orders> order1;            
        public orders()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var dates = dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00.000");
            var dateo = dateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59.999");
            var results = con.Query<Orders>("SELECT " +
                "a.OrderID" +
                ", b.CompanyName" +
                ", c.LastName as EmployeeName" +
                ", a.OrderDate" +
                ", a.RequiredDate" +
                ", a.ShipName " +
                "From Orders a left join Customers b on a.CustomerID = b.CustomerID " +
                "left join Employees c on a.EmployeeID = c.EmployeeID " +
                "WHERE OrderDate BETWEEN '"+ dates + "' AND '"+ dateo + "';").ToList();
            order1 = results;
            dataGridView1.DataSource = order1;          

        }

        private void orders_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column1" && e.RowIndex >= 0)
            {
                var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
                var pd1 = (Orders)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                orderdetail f2 = new orderdetail();
                f2.oDID = pd1.OrderID;
                f2.Show();
            }
        }
    }
}

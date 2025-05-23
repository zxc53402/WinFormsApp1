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
            var dates = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var dateo = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
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
    }
}

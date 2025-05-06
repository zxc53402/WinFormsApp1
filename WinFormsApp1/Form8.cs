using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Work4 : System.Windows.Forms.Form
    {
        public Work4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");

            var sql = "update Customers set " + textBox2.Text + " = '" + textBox3.Text + "' where CustomerID = '" + textBox1.Text + "'";

            con.Query<dynamic>(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

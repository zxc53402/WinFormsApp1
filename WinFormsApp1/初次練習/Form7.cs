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
    public partial class Work3 : System.Windows.Forms.Form
    {
        public Work3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 建立連線
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");

            var sql = "delete from Customers where CustomerID = ('" + textBox1.Text + "')";

            if (textBox1.Text == "")
            {
                MessageBox.Show("CustomerID can't null");
                return;
            }
                      
            //回傳
            con.Query<dynamic>(sql);

            //想做查詢是否成功

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

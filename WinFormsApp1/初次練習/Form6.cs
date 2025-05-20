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
    public partial class Work2 : System.Windows.Forms.Form
    {
        public Work2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //連線
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");

           if(tb1.Text == "" || tb2.Text == "")
            {
                MessageBox.Show("CustomerID & CompanyName can't null");
                return;
            }
            
            
            //資料庫新增資料語法
            string sql = " insert into Customers (" +
                "CustomerID" +
                ",CompanyName" +
                ",ContactName" +
                ",ContactTitle" +
                ",Address" +
                ",City" +
                ",Region" +
                ",PostalCode" +
                ",Country" +
                ",Phone" +
                ",Fax" +
                ") values ('" +
                 tb1.Text + "','" +
                 tb2.Text + "','" +
                 tb3.Text + "','" +
                 tb4.Text + "','" +
                 tb5.Text + "','" +
                 tb6.Text + "','" +
                 tb7.Text + "','" +
                 tb8.Text + "','" +
                 tb9.Text + "','" +
                 tb10.Text + "','" +
                 tb11.Text + "')";

            con.Execute(sql);

            MessageBox.Show("Save data success");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

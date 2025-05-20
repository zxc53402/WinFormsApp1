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

namespace WinFormsApp1
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
           
            var CN = textBox1.Text;
            var CtN = textBox2.Text;
            var CT = textBox3.Text;
            var Ad = textBox4.Text;
            var Ct = textBox5.Text;
            var Rg = textBox6.Text;
            var PC = textBox7.Text;
            var Coty = textBox8.Text;
            string Ph = textBox9.Text;
            string Fa = textBox10.Text;
            var HP = textBox11.Text;

            var sql = "insert into Suppliers (CompanyName" +
                ",ContactName" +
                ",ContactTitle" +
                ",Address" +
                ",City" +
                ",Region" +
                ",PostalCode" +
                ",Country" +
                ",Phone" +
                ",Fax" +
                ",HomePage" +
                ") values ('" +
                CN + "','" +
                CtN + "','" +
                CT + "','" +
                Ad + "','" +
                Ct + "','" +
                Rg + "','" +
                PC + "','" +
                Coty + "','" +
                Ph + "','" +
                Fa + "','" +
                HP + "')";

            var rowsaffected = con.Execute(sql);
            if (rowsaffected > 0)
            {
                MessageBox.Show("新增成功");
            }
            else
            {
                MessageBox.Show("新增失敗");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

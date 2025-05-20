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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string Details = textBox2.Text;
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql = "insert into Categories (CategoryName,Description) values ('"+
                Name +
                "','"+
                Details+
                "')";
            

            int RowsAffected = con.Execute(sql);

            if(RowsAffected > 0)
            {
                MessageBox.Show("成功新增" + RowsAffected + "筆產品種類");
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

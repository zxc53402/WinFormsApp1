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
    public partial class Work1 : System.Windows.Forms.Form
    {
        public Work1()
        {
            InitializeComponent();
        }

        private void Work1_Load(object sender, EventArgs e)
        {
            //建立連線
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            
            //定義results用於儲存查詢資料庫後的表單
            var results = con.Query<dynamic>("select distinct CompanyName from Customers ").ToList();
            
            //迴圈 將results中公司名稱跑進下拉選單
            foreach (var item in results)
            {
                comboBox1.Items.Add(item.CompanyName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //建立連線
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");

            //資料庫查詢語法
            var sql = "select * from Customers";
            
            //如果下拉選單有值
            if( comboBox1.Text != "")
            {
                sql = sql + " where CompanyName = '" + comboBox1.Text + "' ";
            }
            
            //定義results用於儲存查詢資料庫後的表單
            var results = con.Query<dynamic>(sql).ToList();

            //顯示查詢結果於下方
            dataGridView1.DataSource = results;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class updatecustomer : System.Windows.Forms.Form
    {
        public string come { get; set; }
        List<Customers> cus;
        public updatecustomer()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {            
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql = "select *from Customers where CustomerID = @customersID";
            var results = con.Query<Customers>(sql, new {customersID = come}).ToList();
            cus = results;
            txtCompanyName.Text =cus.FirstOrDefault()?.CompanyName ;
            textBox1.Text = cus.FirstOrDefault()?.ContactName;
            textBox7.Text = cus.FirstOrDefault()?.ContactTitle;
            textBox3.Text = cus.FirstOrDefault()?.Address;
            textBox4.Text = cus.FirstOrDefault()?.City;
            textBox5.Text = cus.FirstOrDefault()?.Country;
            textBox6.Text = cus.FirstOrDefault()?.Phone;            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("公司名稱及負責人不得為空");
                return;
            }
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql = "Update Customers set CompanyName=@Com , ContactName=@Con , ContactTitle=@Cont , Address=@Ad , City=@City , Country=@Cou , Phone=@Ph where CustomerID=@Cus";
            var results1 = con.Query<Customers>(sql, new
            {
                Com = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : txtCompanyName.Text,
                Con = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox1.Text,
                Cont = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox7.Text,
                Ad = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox3.Text,
                City = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox4.Text,
                Cou = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox5.Text,
                Ph = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox6.Text,
                Cus = come
            });
            if (results1!=null) 
            {
                MessageBox.Show("修改成功");
            }
        }
    }
}

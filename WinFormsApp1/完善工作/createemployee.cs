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
    public partial class createemployee : Form
    {
        List<Employees> employees;
        public createemployee()
        {
            InitializeComponent();
        }
        private void createemployee_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sqlt = "select distinct Title from Employees";
            var results = con.Query<Employees>(sqlt).ToList();
            employees=results;            
            cBT.DisplayMember = "Title";
            cBT.ValueMember = "Title";
            cBT.DataSource = employees;
            cBT.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            if (string.IsNullOrWhiteSpace(txtLastName.Text)|| string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("姓名不得為空");                
                return;
            }
            string rb = "";
            if (rB1.Checked)rb = "Mr.";
            else if (rB2.Checked)rb = "Mrs.";
            DateTime BD = dTPBD.Value;
            DateTime HD = dTPHD.Value;
            string Tt = cBT.SelectedValue?.ToString() ?? "";
            var sql = "insert into Employees (" +
                "LastName," +
                "FirstName," +
                "Title," +
                "TitleOfCourtesy," +
                "BirthDate," +
                "HireDate," +
                "Address," +
                "City)" +
                "values" +
                "(@LastName," +
                "@FirstName," +
                "@Title," +
                "@TitleOfCourtesy," +
                "@BirthDate," +
                "@HireDate," +
                "@Address," +
                "@City)";
            var result = con.Execute(sql, new
            {
                LastName = txtLastName.Text,
                FirstName =txtFirstName.Text,                              
                Title = Tt,                               
                TitleOfCourtesy = rb,                              
                BirthDate = BD,                               
                HireDate = HD,                               
                Address = txtAddress.Text,                               
                City = txtCity.Text
            });
            if (result > 0) 
            { 
                MessageBox.Show("新增成功");
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

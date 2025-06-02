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


namespace WinFormsApp1.完善工作
{
    public partial class updateemployee : Form
    {
        public string epID { get; set; }
        List<Employees> Lep;       
        private Employee employee;        

        public updateemployee(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void updateemployee_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql = "select *from Employees where EmployeeID = @EmployeeID";
            var result = con.Query<Employees>(sql, new { EmployeeID = epID }).ToList();
            var sqlt = "select distinct Title from Employees";
            var results = con.Query<Employees>(sqlt).ToList();
            Lep = result;
            txtLastName.Text = Lep.FirstOrDefault()?.LastName;
            txtFirstName.Text = Lep.FirstOrDefault()?.FirstName;
            txtCity.Text = Lep.FirstOrDefault()?.City;
            txtAddress.Text = Lep.FirstOrDefault()?.Address;

            cBT.DisplayMember = "Title";
            cBT.ValueMember = "Title";
            cBT.DataSource = results;
            cBT.SelectedValue = result[0].Title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("姓名不得為空");
                return;
            }
            string rb = "";
            if (rB1.Checked) rb = "Mr.";
            else if (rB2.Checked) rb = "Mrs.";
            DateTime BD = dTPBD.Value;
            DateTime HD = dTPHD.Value;
            string Tt = cBT.SelectedValue?.ToString() ?? "";
            var sql = "Update Employees set " +
                " LastName = @LastName," +
                " FirstName = @FirstName," +
                " Title = @Title," +
                " TitleOfCourtesy = @TitleOfCourtesy," +
                " BirthDate = @BirthDate," +
                " HireDate = @HireDate," +
                " Address = @Address," +
                " City = @City " +
                " where EmployeeID = @EmployeeID";
            var result = con.Execute(sql, new
            {
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Title = Tt,
                TitleOfCourtesy = rb,
                BirthDate = BD,
                HireDate = HD,
                Address = txtAddress.Text,
                City = txtCity.Text,
                EmployeeID = epID
            });
            if (result > 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateemployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            employee.refresh();
        }
    }
}

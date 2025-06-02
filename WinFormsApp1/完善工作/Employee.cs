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
using WinFormsApp1.完善工作;

namespace WinFormsApp1
{
    public partial class Employee : Form
    {
        List<Employees> employees;
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createemployee fc = new createemployee();
            fc.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column1" && e.RowIndex >= 0)
            {
                var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
                var cus = (Employees)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                updateemployee fr = new updateemployee(this);
                fr.epID = cus.EmployeeID;
                fr.Show();
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column2" && e.RowIndex >= 0)
            {
                var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");

                var result = MessageBox.Show("是否確定刪除這一列？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var cus = (Employees)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                    var results2 = con.Execute("delete from Employees where EmployeeID = @EmployeeID",
                            new { EmployeeID = cus.EmployeeID });

                    // 從 list 中移除
                    employees.Remove(cus);
                    if (employees.Count > 0)
                    {
                        MessageBox.Show("成功刪除 " + results2 + "項資料");
                        refresh();
                    }
                }
            }
        }
        public void refresh()
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var result = con.Query<Employees>("select * from Employees").ToList();
            employees = result;
            dataGridView1.DataSource = employees;
            dataGridView1.Columns["EmployeeID"].Visible = false;
        }
    }
}

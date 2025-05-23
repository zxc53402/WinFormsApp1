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
    public partial class Suppliers : Form
    {
        List<Suppliers1> suppliers;
        public Suppliers()
        {
            InitializeComponent();
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var results = con.Query<Suppliers1>("select distinct CompanyName,ContactName,ContactTitle,Address,City,Phone from Suppliers").ToList();
            suppliers = results;
            dataGridView1.DataSource = suppliers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createsuppliers frm = new createsuppliers();
            frm.FormClosed += (s, args) =>
            {
                Suppliers_Load(this, EventArgs.Empty);
            };
            frm.ShowDialog();
        }
    }
}

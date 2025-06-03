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
        public void sprefresh()
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var results = con.Query<Suppliers1>("select distinct SupplierID,CompanyName,ContactName,ContactTitle,Address,City,Phone from Suppliers").ToList();
            suppliers = results;
            dataGridView1.DataSource = suppliers;
            dataGridView1.Columns["SupplierID"].Visible = false;
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            sprefresh();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column1" && e.RowIndex >= 0)
            {

                var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
                var pd1 = (Suppliers1)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                updatesupplier f2 = new updatesupplier(this);
                f2.supID = pd1.SupplierID;
                f2.Show();
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column2" && e.RowIndex >= 0)
            {
                var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
                var result3 = MessageBox.Show("是否確定刪除這一列？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result3 == DialogResult.Yes)
                {                    
                    var pd1 = (Suppliers1)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                    var results3 = con.Execute("delete from Suppliers where SupplierID = @SupplierID",
                            new { SupplierID = pd1.SupplierID });
                    suppliers.Remove(pd1);
                    if (suppliers.Count > 0)
                    {
                        MessageBox.Show("成功刪除 " + results3 + "項資料");
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = suppliers;
                }
            }
        }
    }
}

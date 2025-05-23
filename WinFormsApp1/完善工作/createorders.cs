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
    public partial class createorders : Form
    {
        public createorders()
        {
            InitializeComponent();
        }
        List<string> cusID;
        List<string> shipID;
        List<string> epyID;
        List<string> pdID;
        List<string> pdN;
        

        private void Form13_Load(object sender, EventArgs e)
        {
            cusID = new List<string>();
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var results1 = con.Query<dynamic>("select distinct CompanyName,CustomerID from Customers").ToList();
            foreach(var item in results1)
            {
                comboBox1.Items.Add(item.CompanyName);
                cusID.Add(item.CustomerID);
            }
            shipID = new List<string>();
            var results2 = con.Query<dynamic>("select distinct CompanyName,ShipperID from Shippers").ToList();
            foreach (var item in results2)
            {
                comboBox2.Items.Add(item.CompanyName);
                shipID.Add(item.ShipperID.ToString());
            }
            epyID = new List<string>();
            var results3 = con.Query<dynamic>("select distinct LastName,EmployeeID from Employees").ToList();
            foreach ( var item in results3)
            {
                comboBox3.Items.Add(item.LastName);
                epyID.Add(item.EmployeeID.ToString());
            }
            pdID = new List<string>();
            pdN = new List<string>();
            var results4 = con.Query<dynamic>("select distinct ProductName,ProductID from Products").ToList();
            
            foreach ( var item in results4)
            {
               pdN.Add(item.ProductName);
               pdID.Add(item.ProductID.ToString());
            }
            var comboCol = (DataGridViewComboBoxColumn)dataGridView1.Columns["Column2"];
            comboCol.DataSource = pdN.ToList();            
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            DataGridViewRow currentRow = dataGridView1.CurrentRow;

            if (currentRow != null && !currentRow.IsNewRow)
            {
                var value = currentRow.Cells[1].Value;
                var sql = "SELECT DISTINCT UnitPrice, UnitsInStock FROM Products WHERE ProductName = @ProductName";
                var results4 = con.Query<dynamic>(sql, new { ProductName = value }).ToList();
                if (results4 != null)
                {

                    currentRow.Cells[2].Value = results4.FirstOrDefault<dynamic>()?.UnitPrice ?? "";
                    currentRow.Cells[3].Value = results4.FirstOrDefault<dynamic>()?.UnitsInStock;
                }
            }
        }
        //刪除鈕
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Column1")
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var cusID1 = cusID[comboBox1.SelectedIndex];
            var shipID1 = shipID[comboBox2.SelectedIndex];
            var epyID1 = epyID[comboBox3.SelectedIndex];
            var OD = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var SD = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var RD = dateTimePicker2.Value.AddDays(15).ToString("yyyy-MM-dd HH:mm:ss.fff");
            var getorder = "insert into Orders (CustomerID," +
                "EmployeeID," +
                "OrderDate," +
                "RequiredDate," +
                "ShippedDate," +
                "ShipVia" +
                ")values(" +
                "'" + cusID1 + "'" +
                ",'" + epyID1 + "'" +
                ",'" + OD + "'" +
                ",'" + RD + "'" +
                ",'" + SD + "'" +
                ",'" + shipID1 + "')";
            int GOC = con.Execute(getorder);
            var odID = "select distinct OrderID From Orders where OrderDate ='" + OD + "'";
            var results5 = con.Query<dynamic>(odID).ToList();
            var odID2 = results5[0].OrderID;
            if (GOC > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {                    
                    var pd2 = row.Cells["Column2"].Value?.ToString();
                    var pd3 = "select distinct ProductID from Products where ProductName = @ProductName";
                    var results6 = con.Query<dynamic>(pd3,new { ProductName = pd2 }).ToList();
                    if(results6.Count == 0)
                    {
                        MessageBox.Show("新增完成");
                        dataGridView1.Rows.Clear();
                        break;
                    }
                    var pdID2 = results6[0].ProductID;
                    string? price2 = row.Cells["Column3"].Value?.ToString();
                    string? Qt = row.Cells["Column4"].Value?.ToString();
                    if (string.IsNullOrEmpty(pd2) || string.IsNullOrEmpty(price2) || string.IsNullOrEmpty(Qt))
                    {
                        continue;  // 若資料有空值，跳過此筆資料
                    }
                    string CNM = @"
                                  INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity)
                                  VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity)
                                  ";
                    var CSS = @"
                               UPDATE Products
                               SET UnitsInStock = UnitsInStock - @Quantity
                               WHERE ProductID = @ProductID
                               AND UnitsInStock >= @Quantity;
                               ";

                    con.Execute(CNM, new
                    {
                        OrderID = odID2,     
                        ProductID = pdID2,
                        UnitPrice = price2,
                        Quantity = Qt
                    }
                    );
                    
                    con.Execute(CSS, new
                    {                        
                        ProductID = pdID2,                       
                        Quantity = Qt
                    }
                    );

                }            

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //下拉選單點一下就出來
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                dataGridView1.BeginEdit(true); // 讓儲存格進入編輯模式
                ComboBox? combo = dataGridView1.EditingControl as ComboBox;
                if (combo != null)
                {
                    combo.DroppedDown = true; // 展開下拉選單
                }
            }
        }
    }

}

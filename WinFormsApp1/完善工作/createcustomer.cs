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
    public partial class createcustomer : System.Windows.Forms.Form
    {
        private static Random random = new Random();

        private string GenerateRandomKey(int length = 5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
        public createcustomer()
        {
            InitializeComponent();
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");            
            
            bool IDr(string newId)
            {
                var count = con.ExecuteScalar<int>("SELECT COUNT(*) FROM Customers WHERE CustomerID = @id", new { id =newId });
                return count > 0;
            }
            string newId;
            do
            {
                newId = GenerateRandomKey();
            } while (IDr(newId));
            if (txtCompanyName.Text != null)
            {
                string sql = "insert into Customers (" + 
                    "CustomerID," +
                    "CompanyName," +
                    "ContactName," +
                    "ContactTitle," +
                    "Address," +
                    "City," +
                    "Country," +
                    "Phone" +
                    ") values(" + 
                    "@customerID," +
                    "@companyName," +
                    "@contactName," +
                    "@contactTitle," +
                    "@Address," +
                    "@City," +
                    "@Country," +
                    "@Phone)";

                var result = con.Query(sql, new
                {
                    customerID = newId,
                    companyName = txtCompanyName.Text,
                    contactName = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox1.Text,
                    contactTitle = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox7.Text,
                    Address = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox3.Text,
                    City = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox4.Text,
                    Country = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox5.Text,
                    Phone = string.IsNullOrWhiteSpace(txtCompanyName.Text) ? null : textBox6.Text,
                });
                if(result != null)
                {
                    MessageBox.Show("新增成功");
                    this.Close();
                }
               
            }
            else
            {
                MessageBox.Show("CompanyName為必填欄位");
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
            
    
             
    
        
    }
}

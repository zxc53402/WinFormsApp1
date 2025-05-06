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
    public partial class Form10 : System.Windows.Forms.Form
    {

        List<string> List1 ;
        List<string> List2 ;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            List1 = new List<string>();
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var results1 = con.Query<dynamic>("select distinct CategoryID,CategoryName from Categories ").ToList();
         
            foreach (var item in results1)
            {
                comboBox1.Items.Add(item.CategoryName);

                List1.Add(item.CategoryID.ToString());
            }
            
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List2 = new List<string>();
            comboBox2.Items.Clear();
            if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex < List1.Count)
            {
                string categoryId = List1[comboBox1.SelectedIndex];

                comboBox2.Items.Clear();

                using (var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;"))
                {
                    var results2 = con.Query<dynamic>(
                        "select distinct ProductID,ProductName from Products where CategoryID ='" +
                        List1[comboBox1.SelectedIndex] + "'").ToList();
                        

                    foreach (var item in results2)
                    {
                        comboBox2.Items.Add(item.ProductName);
                        List2.Add(item.ProductID.ToString());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var sql = "Update Products set UnitsInStock = UnitsInStock -" +
                textBox1.Text +
                "Where ProductID = '" +
                List2[comboBox2.SelectedIndex] + 
                "' and UnitsInStock >='" +
                textBox1.Text +
                "'";
            con.Query<dynamic>(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e
        }
    }
}

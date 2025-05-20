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
using WinFormsApp1.Class;

namespace WinFormsApp1.物件練習
{
    public partial class frmObjectPractice : Form
    {
        List<Products> products;
        List<OrderDetail> orderdetail;
        public frmObjectPractice()
        {
            InitializeComponent();
            Test();
        }
        private void Test() {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");

            var sql = "select distinct ProductID,ProductName,UnitPrice from Products ";
            var Sql = "select distinct ProductID,Uniprice,Quentity from [Order Details]";
            var results = con.Query<Products>(sql).ToList();
            var results2 = con.Query<OrderDetail>(Sql).ToList();
            products = results;
            orderdetail = results2;



            //ver.1
            

            //ver.2
            var productId2 = products.Where(x => x.ProductName == "Chai").FirstOrDefault()?.ProductID ?? "";
            var uniPrice2 = products.Where(x => x.ProductName == "Chai").FirstOrDefault()?.UnitPrice ?? "";

        }

        private int GetMax()
        {
            var array = new int[] { 1, 2, 3 };
            int max = 0;

            for (var i = 0; i < array.Length; i++)
            {
                if (i == 0) max = array[i];
                if (array[i] > max) max = array[i];
            }
            return max;
        }
        private void GetMin()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productId1;
            string uniPrice1;
            foreach (var item in products)
            {
                if (item.ProductName == "Chai")
                {
                    productId1 = item.ProductID ?? "";
                    uniPrice1 = item.UnitPrice ?? "";
                    
                    MessageBox.Show("'" + productId1 + "','" + uniPrice1 + "'");
                    break;
                }                
            }
            
        }             
    }

}


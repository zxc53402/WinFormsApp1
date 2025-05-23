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
        
        public frmObjectPractice()
        {
            InitializeComponent();
            Test();
        }
        private void Test() {
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");

            var sql = "select distinct ProductID,ProductName,UnitPrice from Products ";
            
            var results = con.Query<Products>(sql).ToList();
            
            products = results;
            



            //ver.1
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
    }

}


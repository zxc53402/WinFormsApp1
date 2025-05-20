using Dapper;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        List<string> arrTest ;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HELLO:" + txtSample.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // �إ߳s�u
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            // �d�߸�Ʈw�y�k
            var sql = "select * from Customers ";

            if (comboBox1.Text != "")
            {
                sql = sql + " where CompanyName = '"+ comboBox1.Text + "' ";
            }

            // ��جd�߫ᱵ��Ƥ覡    ���w�������� or dynamic �ʺA����(�i�H�k �����w��)
                var results = con.Query<dynamic>(sql).ToList();
            //var results = con.Query<CustomerGYY>("select * from Customers").ToList();

            var ContactNames = "";


            //�M��  ��k 1 
            for (int i = 0; i < results.Count; i++)
            {
                var item = results[i];
                ContactNames = ContactNames + "," + item.ContactName;
            }

            //�M��  ��k 2
            //foreach (var item in results) {
            //    ContactNames = ContactNames + "," + item.ContactName;
            //}


            //MessageBox.Show(ContactNames);

            //con.Execute("");

            dataGridView1.DataSource = results;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hellow World!");
        }

        private void ggyy_Click(object sender, EventArgs e)
        {

            MessageBox.Show(checkBox1.Checked ? "����" : "�S����");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
            MessageBox.Show(comboBox1.Text + " INDEX:" + 
                comboBox1.SelectedIndex  + "  arrTest["+comboBox1.SelectedIndex + "]:" +
                arrTest[comboBox1.SelectedIndex]);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            arrTest = new List<string>();
            var con = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
            var results = con.Query<dynamic>("select distinct CustomerID,CompanyName from Customers ").ToList();
            foreach (var item in results)
            {
                comboBox1.Items.Add(item.CompanyName);

                arrTest.Add(item.CustomerID);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}



public class CustomerGYY
{
    public string ContactName { get; set; }
}
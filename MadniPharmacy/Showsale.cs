using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadniPharmacy.Classes;
using System.Data.SqlClient;



namespace MadniPharmacy
{
    public partial class Showsale : Form
    {
        DataContext dc = new DataContext(Connection.dcc);
        DataTable dt = new DataTable();
        public void RefreshPage()
        {
            dt = new DataTable();
            Table<Sales> s = dc.GetTable<Sales>();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Sale Rate", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Price", typeof(double));
            dt.Columns.Add("Patient Name", typeof(string));
            var query = from k in s
                        select k;
            foreach (var j in query)
            {
                dt.Rows.Add(j.ID, j.Name, j.Category, j.Sale_rate, j.Quantity, j.Date, j.Price, j.Patient_name);
            }
            dataGridView1.DataSource = dt;
        }
        public Showsale()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");



        private void Showsale_Load(object sender, EventArgs e)
        {
            Table<Sales> s = dc.GetTable<Sales>();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Sale Rate", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Price", typeof(double));
            dt.Columns.Add("Patient Name", typeof(string));
            var query = from k in s
                        select k;
            foreach (var j in query)
            {
                dt.Rows.Add(j.ID, j.Name, j.Category, j.Sale_rate, j.Quantity, j.Date, j.Price, j.Patient_name);
            }
            dataGridView1.DataSource = dt;
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                sum = sum + double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
            }
            textBox2.Text = Convert.ToString(Math.Round(sum, 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cell = dataGridView1.SelectedCells[0];
            var row = dataGridView1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Table<Sales> c = dc.GetTable<Sales>();
            var query = from k in c
                        where k.ID == val
                        select k;
            foreach (var j in query)
            {
                c.DeleteOnSubmit(j);
            }
            dc.SubmitChanges();
            RefreshPage();
            MetroFramework.MetroMessageBox.Show(this, "Data Deleted Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cell = dataGridView1.SelectedCells[0];
            var row = dataGridView1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            UpdateSaleRecord uc = new UpdateSaleRecord();
            uc.ShowData(val);
            uc.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "";
            }
            else
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Name like '%{0}%'", textBox1.Text.Trim());
                dataGridView1.DataSource = dv;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelapp = new Microsoft.Office.Interop.Excel.Application();
                xcelapp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    xcelapp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;

                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        xcelapp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelapp.Columns.AutoFit();
                xcelapp.Visible = true;


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from  Sales where date between '"+dateTimePicker1.Value.ToString()+ "'and '"+dateTimePicker2.Value.ToString()+ "'",conn);

            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(Sales.option5 =="AdminMenu")
            {
                AdminMenu am = new AdminMenu();

                this.Close();
                am.Show();

            }
            else if(Sales.option5 =="UserMenu")
            {
                UserMenu sm = new UserMenu();
                sm.Show();
                this.Hide();

            }
        }
    }
}

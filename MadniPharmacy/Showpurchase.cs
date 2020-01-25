using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadniPharmacy.Classes;
using System.Data.Linq;

namespace MadniPharmacy
{
    public partial class Showpurchase : Form
    {
        public Showpurchase()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        DataTable dt = new DataTable();
        public void RefreshPage()
        {
            dt = new DataTable();
            Table<Purchase> c = dc.GetTable<Purchase>();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Purchase Rate", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Total Price", typeof(double));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Expiry Date", typeof(DateTime));
            var query = from k in c
                        select k;
            foreach (var j in query)
            {
                dt.Rows.Add(j.Id, j.Name, j.Type, j.Purchase_rate, j.Quantity,j.Total_price,j.Date,j.Expiry_date);
            }
            metroGrid1.DataSource = dt;
        }
        private void Showpurchase_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            Table<Purchase> c = dc.GetTable<Purchase>();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Purchase Rate", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Total Price", typeof(double));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Expiry Date", typeof(DateTime));
            var query = from k in c
                        select k;
            foreach (var j in query)
            {
                dt.Rows.Add(j.Id, j.Name, j.Type, j.Purchase_rate, j.Quantity, j.Total_price, j.Date, j.Expiry_date);
            }
            metroGrid1.DataSource = dt;
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
                metroGrid1.DataSource = dv;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Table<Purchase> c = dc.GetTable<Purchase>();
            var query = from k in c
                        where k.Id == val
                        select k;
            foreach (var j in query)
            {
                c.DeleteOnSubmit(j);
            }
            dc.SubmitChanges();
            RefreshPage();
            MetroFramework.MetroMessageBox.Show(this, "Data Deleted Successfully");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            UpdatePurchase uc = new UpdatePurchase();
            uc.ShowData(val);
            uc.Show();
            this.Hide();
        }
    }
}

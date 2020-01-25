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
    public partial class ShowSalesRecord : Form
    {
        public ShowSalesRecord()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        DataTable dt = new DataTable();
        public void RefreshPage()
        {
            dt = new DataTable();
            Table<Sales> d = dc.GetTable<Sales>();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            //dt.Columns.Add("Unit_Type", typeof(string));
            dt.Columns.Add("Sale_Rate", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Price", typeof(double));
            dt.Columns.Add("Patient_Name", typeof(string));
            var query = from k in d
                        select k;
            foreach (var i in query)
            {
                dt.Rows.Add(i.ID, i.Name, i.Category, i.Sale_rate, i.Quantity, i.Date, i.Price, i.Patient_name);
            }
            metroGrid1.DataSource = dt;
        }

        private void ShowSalesRecord_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_C__USERS_SUFYAN_AHMED_ONEDRIVE_DESKTOP_MADNIPHARMACY_MADNIPHARMACY_BIN_DEBUG_PHARMACY_MDFDataSet.sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter.Fill(this._C__USERS_SUFYAN_AHMED_ONEDRIVE_DESKTOP_MADNIPHARMACY_MADNIPHARMACY_BIN_DEBUG_PHARMACY_MDFDataSet.sales);
            this.ActiveControl = metroTextBox1;
            Table<Sales> s = dc.GetTable<Sales>();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            //dt.Columns.Add("Unit_Type", typeof(string));
            dt.Columns.Add("Sale_Rate", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Price", typeof(double));
            dt.Columns.Add("Patient_Name", typeof(string));
            var query = from k in s
                        select k;
            foreach(var i in query)
            {
                dt.Rows.Add(i.ID, i.Name, i.Category, i.Sale_rate, i.Quantity, i.Date, i.Price, i.Patient_name);
            }
            metroGrid1.DataSource = dt;
            double total_sale = 0;
            for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
            {

                total_sale = total_sale + double.Parse(metroGrid1.Rows[i].Cells[6].Value.ToString());
            }
            Sales.result = total_sale;
            textBox1.Text = Convert.ToString(Math.Round(Sales.result,2));
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Table<Sales> d = dc.GetTable<Sales>();
            var query = from k in d
                        where k.ID == val
                        select k;
            foreach (var j in query)
            {
                d.DeleteOnSubmit(j);
            }
            dc.SubmitChanges();
            RefreshPage();
            MetroFramework.MetroMessageBox.Show(this, "Data Deleted Successfully");
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Updatedistributer ud = new Updatedistributer();
            ud.ShowData(val);
            ud.Show();
            this.Hide();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                metroTextBox1.Text = "";
            }
            else
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Name like '%{0}%'", metroTextBox1.Text.Trim());
                metroGrid1.DataSource = dv;
            }
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton1.Focus();
            }
        }

        private void metroButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton2.Focus();
            }
        }

        private void metroButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton3.Focus();
            }
        }

        private void metroButton3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox1.Focus();
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

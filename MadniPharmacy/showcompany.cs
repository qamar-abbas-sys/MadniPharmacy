using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadniPharmacy.Classes;

namespace MadniPharmacy
{
    public partial class showcompany : MetroFramework.Forms.MetroForm
    {
        public showcompany()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        DataTable dt = new DataTable();
        public void RefreshPage()
        {
            dt = new DataTable();
            Table<company> c = dc.GetTable<company>();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Services", typeof(string));
            dt.Columns.Add("Trade No", typeof(string));
            var query = from k in c
                        select k;
            foreach (var j in query)
            {
                dt.Rows.Add(j.ID, j.Name, j.Address, j.Services, j.Tradeno);
            }
            metroGrid1.DataSource = dt;
        }
        private void showcompany_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            Table<company> c = dc.GetTable<company>();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Services", typeof(string));

            dt.Columns.Add("Trade No", typeof(string));
            var query = from k in c
                        select k;
            foreach( var j in query)
            {
                dt.Rows.Add(j.ID, j.Name, j.Address, j.Services, j.Tradeno);
            }
            metroGrid1.DataSource = dt;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Table<company> c = dc.GetTable<company>();
            var query = from k in c
                        where k.ID == val
                        select k;
            foreach( var j in query)
            {
                c.DeleteOnSubmit(j);
            }
            dc.SubmitChanges();
            RefreshPage();
            MetroFramework.MetroMessageBox.Show(this, "Data Deleted Successfully");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text =="")
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            updatecompany uc = new updatecompany();
            uc.ShowData(val);
            uc.Show();
            this.Hide();
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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
                textBox1.Focus();
            }
        }
    }
}

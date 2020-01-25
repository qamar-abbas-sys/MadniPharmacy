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
    public partial class Showdistributer : MetroFramework.Forms.MetroForm
    {
        public Showdistributer()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        DataTable dt = new DataTable(); 
        public void RefreshPage()
        {
            dt = new DataTable();
            Table<Distributer> d = dc.GetTable<Distributer>();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Cell No", typeof(string));
            dt.Columns.Add("CNIC", typeof(string));
            var query = from k in d
                        select k;
            foreach (var j in query)
            {
                dt.Rows.Add(j.ID, j.Name, j.Email, j.CellNo, j.CNIC);
            }
            metroGrid1.DataSource = dt;
        }
        private void Showdistributer_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            Table<Distributer> d = dc.GetTable<Distributer>();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name",typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Cell No", typeof(string));
            dt.Columns.Add("CNIC", typeof(string));
            var query = from k in d
                        select k;
            foreach( var j in query)
            {
                dt.Rows.Add( j.ID,j.Name, j.Email, j.CellNo, j.CNIC);
            }
            metroGrid1.DataSource = dt;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Table<Distributer> d = dc.GetTable<Distributer>();
            var query = from k in d
                        where k.ID == val
                        select k;
            foreach(var j in query)
            {
                d.DeleteOnSubmit(j);
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
            Updatedistributer ud = new Updatedistributer();
            ud.ShowData(val);
            ud.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                textBox1.Text = "";
            }
            else
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format(" Name like '%{0}%'", textBox1.Text.Trim());
                metroGrid1.DataSource = dv;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            am.Show();
            this.Hide();
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

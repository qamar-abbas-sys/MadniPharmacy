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
    public partial class ShowUser : Form
    {
        public ShowUser()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        DataTable dt = new DataTable();
        public void RefreshPage()
        {
            dt = new DataTable(); 
            Table<User> u = dc.GetTable<User>();
           
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            var query = from k in u
                        select k;
            foreach (var i in query)
            {
                dt.Rows.Add(i.ID, i.Name, i.Pass,i.Type);
            }
            metroGrid1.DataSource = dt;
        }
        private void ShowUser_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroButton1;
            Table<User> u = dc.GetTable<User>();
           
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            var query = from k in u
                        select k;
            foreach(var i in query)
            {
                dt.Rows.Add(i.ID, i.Name, i.Pass,i.Type);
            }
            metroGrid1.DataSource = dt;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Updateuser u = new Updateuser();
            u.ShowData(val);
            this.Hide();
            u.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Table<User> u = dc.GetTable<User>();
            var query = from k in u
                        where k.ID == val
                        select k;
            foreach( var j in query)
            {
                u.DeleteOnSubmit(j);
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
                metroButton1.Focus();
            }
        }
    }
}

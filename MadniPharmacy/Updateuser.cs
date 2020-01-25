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
    public partial class Updateuser : MetroFramework.Forms.MetroForm
    {
        public Updateuser()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        int iid;
        public void ShowData(int id)
        {
            iid = id;
            Table<User> u = dc.GetTable<User>();
            var query = from k in u
                        where k.ID == id
                        select k;
            foreach( var j in query)
            {
                metroTextBox1.Text = j.Name;
                metroTextBox2.Text = j.Pass;
                metroComboBox1.Text = j.Type;
            }
        }
        private void Updateuser_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroTextBox1;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           
                Table<User> u = dc.GetTable<User>();
                var query = from k in u
                            where k.ID == iid
                            select k;
                foreach (var j in query)
                {
                    j.Name = metroTextBox1.Text;
                    j.Pass = metroTextBox2.Text;
                j.Type = metroComboBox1.Text;
                }
                dc.SubmitChanges();
                MetroFramework.MetroMessageBox.Show(this, "Data Updated Successfully");
                ShowUser us = new ShowUser();
                us.Show();
                this.Hide();
           
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            ShowUser su = new ShowUser();
            this.Close();
            su.Show();
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox2.Focus();
            }
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
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
                metroTextBox1.Focus();
            }
        }
    }
}

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
    public partial class updatecompany : MetroFramework.Forms.MetroForm
    {
        public updatecompany()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        int iid;
        public void ShowData( int id)
        {
            iid = id;
            Table<company> c = dc.GetTable<company>();
            var query = from k in c
                        where k.ID == id
                        select k;
            foreach( var j in query)
            {
                metroTextBox1.Text = j.Name;
                metroTextBox2.Text = j.Address;
                metroTextBox3.Text = j.Services;
                metroTextBox4.Text = j.Tradeno;
            }
        }
        private void updatecompany_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroTextBox1;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
                Table<company> c = dc.GetTable<company>();
                var query = from k in c
                            where k.ID == iid
                            select k;
                foreach (var j in query)
                {
                    j.Name = metroTextBox1.Text;
                    j.Address = metroTextBox2.Text;
                    j.Services = metroTextBox3.Text;
                    j.Tradeno = metroTextBox4.Text;

                }
                dc.SubmitChanges();
                MetroFramework.MetroMessageBox.Show(this, "Data Updated Successfully");
                showcompany sc = new showcompany();
                sc.Show();
                this.Hide();
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            showcompany sc = new showcompany();
            sc.Show();
            this.Hide();
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
                metroTextBox4.Focus();
            }
        }

        private void metroTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox3.Focus();
            }
        }

        private void metroTextBox3_KeyDown(object sender, KeyEventArgs e)
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

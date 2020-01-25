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
    public partial class addcompany : MetroFramework.Forms.MetroForm
    {
        public addcompany()
        {
            InitializeComponent();
        }
        DataContext dc = new DataContext(Connection.dcc);
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");

        private void addcompany_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroTextBox1;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           
                Table<company> c1 = dc.GetTable<company>();
                company c = new company();
                c.Name = metroTextBox1.Text;
                c.Address = metroTextBox2.Text;
            c.Services = metroTextBox3.Text;
                c.Tradeno = metroTextBox4.Text;
                c1.InsertOnSubmit(c);
                dc.SubmitChanges();
                MetroFramework.MetroMessageBox.Show(this, "Data Added Successfully");
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
           
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

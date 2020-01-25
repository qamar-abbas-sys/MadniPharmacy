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
    public partial class Adduser : MetroFramework.Forms.MetroForm
    {
        public Adduser()
        {
            InitializeComponent();
        }
       // DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);

        private void Adduser_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
                
           
         
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            Table<User> u = dc.GetTable<User>();
            User u1 = new User();
            u1.Name = metroTextBox1.Text;
            u1.Pass = metroTextBox2.Text;
            u1.Type = metroComboBox1.Text;
            u.InsertOnSubmit(u1);
            dc.SubmitChanges();
            MetroFramework.MetroMessageBox.Show(this, "Data Saved");
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox2.Focus();
            }
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroComboBox1.Focus();
            }
        }

        private void metroComboBox1_KeyDown(object sender, KeyEventArgs e)
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

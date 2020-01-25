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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Table<Admin> am = dc.GetTable<Admin>();
            Table<User> u = dc.GetTable<User>();
            User u1 = new User();
            Admin a1 = new Admin();
            a1.Name = metroTextBox1.Text;
            a1.Pass = metroTextBox2.Text;
            a1.Type = metroComboBox1.Text;
            u1.Name = metroTextBox1.Text;
            u1.Pass = metroTextBox2.Text;
            u1.Type = metroComboBox1.Text;
            if (metroComboBox1.Text == "Admin")
            {
                am.InsertOnSubmit(a1);
                dc.SubmitChanges();
                MetroFramework.MetroMessageBox.Show(this, "Account Created");
            }
            else if(metroComboBox1.Text == "User")
            {
                u.InsertOnSubmit(u1);
                dc.SubmitChanges();
                MetroFramework.MetroMessageBox.Show(this, "Account Created");
            }
                
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Close();
            l.Show();
        }
    }
}

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
using System.Threading;

namespace MadniPharmacy
{
    public partial class Login : Form
    {
        
        public Login()
        {
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();

            t.Abort();
        }
        public void SplashStart()
        {
            Application.Run(new SplashSecreen_1());
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Parse("02/10/2020");//mm/dd/yyyy
            if(dt1.Date > dt2.Date)
            {
                MetroFramework.MetroMessageBox.Show(this, "Your Application License has been Expired");
            }
            else
            {

                // for login for super admin
                if (metroComboBox1.Text == "Admin")
                {
                    Sales.option5 = "AdminMenu";
                    Purchase.option4 = "AdminMenu";
                    Table<Admin> sa1 = dc.GetTable<Admin>();
                    var query = from k in sa1
                                select k;
                    foreach (var k in query)
                    {

                        if (k.Name == metroTextBox1.Text && k.Pass == metroTextBox2.Text)
                        {
                            Admin.option = k.Name;
                            AdminMenu sam1 = new AdminMenu();
                            this.Hide();
                            sam1.Show();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "User Not found");
                        }

                    }
                }
                // for login for  user
                else if (metroComboBox1.Text == "User")
                {
                    Sales.option5 = "UserMenu";
                    Purchase.option4 = "UserMenu";
                    Table<User> sa1 = dc.GetTable<User>();
                    var query = from k in sa1
                                select k;
                    foreach (var k in query)
                    {
                        if (k.Name == metroTextBox1.Text && k.Pass == metroTextBox2.Text)
                        {
                            User.option = k.Name;
                            UserMenu am1 = new UserMenu();
                            this.Hide();
                            am1.Show();
                        }
                        else
                        {
                            //MetroFramework.MetroMessageBox.Show(this, "User Not found");
                        }

                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Admin Not selected");
                }

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroTextBox1;

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                metroButton3.Focus();
            }
        }
    }
}

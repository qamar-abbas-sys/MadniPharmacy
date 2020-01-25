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

namespace MadniPharmacy
{
    public partial class UserMenu : Form
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            SaleProduct sp = new SaleProduct();
            sp.Show();
            this.Hide();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            PurchaseProduct pp = new PurchaseProduct();
            pp.Show();
            this.Hide();
        }

        private void UserMenu_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroButton2;
        }

        private void metroButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ShiftKey)
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

        private void metroButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton2.Focus();
            }
        }
    }
}

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
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            //metroLabel14.Text = Sales.option5;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Adduser au = new Adduser();
            au.Show();
            this.Hide();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            ShowUser su = new ShowUser();
            su.Show();
            this.Hide();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            ProductForm pf = new ProductForm();
            pf.Show();
            this.Hide();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            showproductform sp = new showproductform();
            sp.Show();
            this.Hide();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            addcompany ac = new addcompany();
            ac.Show();
            this.Hide();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            showcompany sc = new showcompany();
            sc.Show();
            this.Hide();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            Adddistributerform ad = new Adddistributerform();
            ad.Show();
            this.Hide();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            Showdistributer sd = new Showdistributer();
            sd.Show();
            this.Hide();
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            SaleProduct sp = new SaleProduct();
            sp.Show();
            this.Hide();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            PurchaseProduct pp = new PurchaseProduct();
            pp.Show();
            this.Hide();
        }

        private void metroLabel12_Click(object sender, EventArgs e)
        {
            
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
                metroButton4.Focus();
            }
        }

        private void metroButton4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton5.Focus();
            }
        }

        private void metroButton5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton6.Focus();
            }
        }

        private void metroButton6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton7.Focus();
            }
        }

        private void metroButton7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton8.Focus();
            }
        }

        private void metroButton8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton9.Focus();
            }
        }

        private void metroButton10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton11.Focus();
            }
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            Showpurchase sp = new Showpurchase();
            this.Hide();
            sp.Show();
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            Showsale ss = new Showsale();
            this.Hide();
            ss.Show();
        }

        private void metroButton11_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.ShiftKey)
            {
                metroButton12.Focus();
            }
        }

        private void metroButton12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroButton13.Focus();
            }
        }
    }
}

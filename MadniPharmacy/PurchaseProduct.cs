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
    public partial class PurchaseProduct : Form
    {
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        public PurchaseProduct()
        {
            InitializeComponent();
        }
        public void RefreshPage()
        {
            metroComboBox1.Text = null;
            metroTextBox1.Text = null;
            metroTextBox2.Text = null;
           // metroTextBox3.Text = null;
        }

        private void PurchaseProduct_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroComboBox1;
            Table<MadniPharmacy.Classes.Product> p1 = dc.GetTable<MadniPharmacy.Classes.Product>();
            var query = from k in p1
                        select k;
            foreach(var i in query)
            {
                metroComboBox1.Items.Add(i.Name);
            }
            
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Table<MadniPharmacy.Classes.Product> p1 = dc.GetTable<MadniPharmacy.Classes.Product>();
            var query = from k in p1
                       where k.Name == Convert.ToString(metroComboBox1.Text)
                       select k;
            foreach(var i in query)
            {
                metroTextBox1  .Text = i.Type;
                metroTextBox2.Text = Convert.ToString(i.Purchase_rate);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Table<Purchase> p1 = dc.GetTable<Purchase>();
            Purchase p = new Purchase();
            p.Name = metroComboBox1.Text;
            p.Type = metroTextBox1.Text;
            p.Purchase_rate = Convert.ToDouble(metroTextBox2.Text);
            p.Quantity = Convert.ToInt32(metroTextBox3.Text);
            p.Total_price = Convert.ToDouble(metroTextBox4.Text);
            p.Date = Convert.ToDateTime(metroDateTime1.Text);
            p.Expiry_date = Convert.ToDateTime(metroDateTime2.Text);
            p1.InsertOnSubmit(p);
            dc.SubmitChanges();
            RefreshPage();
            MetroFramework.MetroMessageBox.Show(this, "Invoice Date Saved");
        }

        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {
            //if(metroTextBox3.Text == "")
            //{
            //    metroTextBox3.Text = "0";
            //}
            int quantity = Convert.ToInt32(metroTextBox3.Text);
            double purchase_rate = Convert.ToDouble(metroTextBox2.Text);
            double total_price = Convert.ToDouble(metroTextBox4.Text);
            total_price = quantity * purchase_rate;
            metroTextBox4.Text = Convert.ToString(Math.Round(total_price,2));
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(Purchase.option4 == "AdminMenu")
            {
                AdminMenu am = new AdminMenu();
                this.Close();
                am.Show();
            }
            else if(Purchase.option4 == "UserMenu")
            {
                UserMenu um = new UserMenu();
                this.Close();
                um.Show();
            }
            
        }

        private void metroComboBox1_KeyDown(object sender, KeyEventArgs e)
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
                metroTextBox3.Focus();
            }
        }

        private void metroTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroDateTime2.Focus();
            }
        }

        private void metroDateTime2_KeyDown(object sender, KeyEventArgs e)
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
                metroComboBox1.Focus();
            }
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
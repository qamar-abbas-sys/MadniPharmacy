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
    public partial class UpdatePurchase : Form
    {
        public UpdatePurchase()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        int iid;
        public void ShowData(int id)
        {
            iid = id;
            Table<Purchase> c = dc.GetTable<Purchase>();
            var query = from k in c
                        where k.Id == id
                        select k;
            foreach (var j in query)
            {
                metroTextBox5.Text = j.Name;
                metroTextBox1.Text = j.Type;
                metroTextBox2.Text = Convert.ToString(j.Purchase_rate);
                metroTextBox3.Text = Convert.ToString(j.Quantity);
                metroTextBox4.Text = Convert.ToString(j.Total_price);
            }
        }
        private void UpdatePurchase_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Table<Purchase> c = dc.GetTable<Purchase>();
            var query = from k in c
                        where k.Id == iid
                        select k;
            foreach (var j in query)
            {
                j.Name = metroTextBox5.Text;
                j.Type = metroTextBox1.Text;
                j.Purchase_rate = Convert.ToDouble(metroTextBox2.Text);
                j.Quantity = Convert.ToInt32(metroTextBox3.Text);
                j.Total_price = Convert.ToDouble(metroTextBox4.Text);
                j.Type = metroTextBox1.Text;
            }
            dc.SubmitChanges();
            MetroFramework.MetroMessageBox.Show(this, "Data Updated Successfully");
            Showpurchase sc = new Showpurchase();
            sc.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Showpurchase sp = new Showpurchase();
            this.Close();
            sp.Show();
        }
    }
}

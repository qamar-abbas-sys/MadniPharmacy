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
    public partial class UpdateSaleRecord : Form
    {
        public UpdateSaleRecord()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        int iid;
        public void ShowData(int id)
        {
            iid = id;
            Table<Sales> d = dc.GetTable<Sales>();
            var query = from k in d
                        where k.ID == id
                        select k;
            foreach (var j in query)
            {
                metroTextBox6.Text = j.Patient_name;
                metroComboBox1.Text = j.Name;
                metroTextBox1.Text = j.Category;
                //metroComboBox2.Text = j.Unit_type;
                metroTextBox2.Text = Convert.ToString(j.Sale_rate);
                metroTextBox3.Text = Convert.ToString(j.Quantity);
                metroDateTime1.Text = Convert.ToString(j.Date);
                metroTextBox5.Text = Convert.ToString(j.Price);
            }
        }

        private void UpdateSaleRecord_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroTextBox6;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Showsale ss = new Showsale();
            this.Close();
            ss.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Table<Sales> c = dc.GetTable<Sales>();
            var query = from k in c
                        where k.ID == iid
                        select k;
            foreach (var j in query)
            {
                j.Patient_name = metroTextBox6.Text;
                j.Name = metroComboBox1.Text;
                j.Category = metroTextBox1.Text;
                //j.Unit_type = metroComboBox2.Text;
                j.Sale_rate = Convert.ToDouble(metroTextBox2.Text);
                j.Quantity  = Convert.ToInt32(metroTextBox3.Text);
                j.Date = Convert.ToDateTime(metroDateTime1.Text);
                j.Price = Convert.ToDouble(metroTextBox5.Text);

            }
            dc.SubmitChanges();
            MetroFramework.MetroMessageBox.Show(this, "Data Updated Successfully");
            Showsale sr = new Showsale();
            this.Close();
            sr.Show();
        }

        private void metroTextBox6_KeyDown(object sender, KeyEventArgs e)
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
                metroComboBox2.Focus();
            }
        }

        private void metroComboBox2_KeyDown(object sender, KeyEventArgs e)
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
                metroTextBox6.Focus();
            }
        }
    }
}

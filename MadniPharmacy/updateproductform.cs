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
    public partial class updateproductform : MetroFramework.Forms.MetroForm
    {
        public updateproductform()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        int idd;
        public void ShowData( int id)
        {
            idd = id;
            Table<Product> p = dc.GetTable<Product>();
            var query = from k in p
                        where k.ID == id
                        select k;
            foreach( var j in query)
            {
                metroTextBox12.Text = j.Name;
                metroComboBox5.Text = j.Type;
                metroComboBox2.Text = j.Package_name;
                metroTextBox1.Text = Convert.ToString(j.Purchase_rate);
                metroTextBox5.Text = Convert.ToString(j.Sale_rate);
                metroTextBox2.Text = Convert.ToString(j.No_of_items_in_pack);
                metroComboBox3.Text = j.Item_type;
                metroTextBox4.Text = Convert.ToString(j.Item_unit_cost);
                metroTextBox3.Text = Convert.ToString(j.No_of_sub_items_in_item);
                metroComboBox4.Text = j.Sub_item_type;
                metroTextBox6.Text = Convert.ToString(j.Sub_item_unit_cost);
                metroTextBox8.Text = Convert.ToString(j.No_of_tablets_in_pack);
                metroTextBox9.Text = Convert.ToString(j.Quantity);
                metroDateTime1.Text = Convert.ToString(j.Date);
                metroTextBox7.Text = j.Batchno;
                metroTextBox10.Text = j.Cname;


            }
        }

        private void updateproductform_Load(object sender, EventArgs e)
        {
            this.ActiveControl = metroTextBox12;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
           
                
          

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            showproductform sp = new showproductform();
            this.Close();
            sp.Show();
            
        }

        private void htmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            Table<Product> p = dc.GetTable<Product>();
            var query = from k in p
                        where k.ID == idd
                        select k;
            foreach (var j in query)
            {
               j.Name = metroTextBox12.Text;
               j.Type = metroComboBox5.Text;
               j.Package_name =  metroComboBox2.Text;
               j.Purchase_rate = Convert.ToDouble(metroTextBox1.Text);
               j.Sale_rate = Convert.ToDouble(metroTextBox5.Text);
               j.No_of_items_in_pack = Convert.ToInt32(metroTextBox2.Text);
               j.Item_type = metroComboBox3.Text;
               j.Item_unit_cost = Convert.ToDouble(metroTextBox4.Text);
               j.No_of_sub_items_in_item = Convert.ToInt32(metroTextBox3.Text);
               j.Sub_item_type = metroComboBox4.Text;
               j.Sub_item_unit_cost = Convert.ToDouble(metroTextBox3.Text);
               j.No_of_tablets_in_pack = Convert.ToInt32(metroTextBox8.Text);
               j.Quantity = Convert.ToInt32(metroTextBox9.Text);
               j.Date = Convert.ToDateTime(metroDateTime1.Text);
               j.Batchno = metroTextBox7.Text;
               j.Cname = metroTextBox10.Text;

            }
            dc.SubmitChanges();
            MetroFramework.MetroMessageBox.Show(this, "Data Updated Successfully");
            showproductform sh = new showproductform();
            sh.Show();
            this.Hide();
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            showproductform sh = new showproductform();
            sh.Show();
            this.Hide();
        }

        private void metroTextBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroComboBox5.Focus();
            }
        }

        private void metroComboBox5_KeyDown(object sender, KeyEventArgs e)
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
                metroTextBox1.Focus();
            }
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox5.Focus();
            }
        }

        private void metroTextBox5_KeyDown(object sender, KeyEventArgs e)
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
                metroComboBox3.Focus();
            }
        }

        private void metroComboBox3_KeyDown(object sender, KeyEventArgs e)
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
                metroComboBox4.Focus();
            }
        }

        private void metroComboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox6.Focus();
            }
        }

        private void metroTextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox8.Focus();
            }
        }

        private void metroTextBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox9.Focus();
            }
        }

        private void metroTextBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox11.Focus();
            }
        }

        private void metroTextBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroDateTime1.Focus();
            }
        }

        private void metroDateTime1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox7.Focus();
            }
        }

        private void metroTextBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox10.Focus();
            }
        }

        private void metroTextBox10_KeyDown(object sender, KeyEventArgs e)
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
                metroTextBox12.Focus();
            }
        }
    }
}

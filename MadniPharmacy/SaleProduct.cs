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
    public partial class SaleProduct : Form
    {
        public SaleProduct()
        {
            InitializeComponent();
        }
        DataContext dc = new DataContext(Connection.dcc);
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }
        DataTable dt;
        private void SaleProduct_Load(object sender, EventArgs e)
        {

            this.ActiveControl = metroTextBox6;
            dt = new DataTable();
            dt.Columns.Add("Patient Name", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            //dt.Columns.Add("Unit Type", typeof(string));
            dt.Columns.Add("Sale Rate", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Price", typeof(double));
            metroGrid1.DataSource = dt;
            Table<Classes.Product> p = dc.GetTable<Classes.Product>();
            var query = from k in p
                        select k;
            foreach (var i in query)
            {
                comboBox1.Items.Add(i.Name);
            }

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Table<Classes.Product> p = dc.GetTable<Classes.Product>();
            var query = from k in p
                        where k.Name == Convert.ToString(comboBox1.Text)
                        select k;
            foreach (var i in query)
            {
                if (metroTextBox1.Text == "Other")
                {
                    metroTextBox2.Text = Convert.ToString(i.Item_unit_cost);
                }
                else
                {
                    metroTextBox1.Text = i.Type;
                    metroTextBox2.Text = Convert.ToString(i.Sub_item_unit_cost);
                }

            }
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void metroTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox3.Text == "")
            {
                metroTextBox3.Text = "0";
            }
            double sale_rate = Convert.ToDouble(metroTextBox2.Text);
            int quantity = Convert.ToInt32(metroTextBox3.Text);
            double total_price = Convert.ToDouble(metroTextBox5.Text);
            total_price = sale_rate * quantity;
            metroTextBox5.Text = Convert.ToString(total_price);


        }

        private void metroTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            metroGrid1.DataSource = null;
            comboBox1.Text = null;
            //metroComboBox2.Text = null;
            metroTextBox1.Text = "";
            metroTextBox2.Text = "0.00";
            //metroTextBox3.Text = "";
            metroTextBox5.Text = "";
            metroTextBox4.Text = "";
            metroTextBox6.Text = "";
            //metroGrid1.Rows.Clear();
            // dt.Columns.Add("Patient Name", typeof(string));
            dt = new DataTable();
            dt.Columns.Add("Patient Name", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            //dt.Columns.Add("Unit Type", typeof(string));
            dt.Columns.Add("Sale Rate", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Price", typeof(double));
            metroGrid1.DataSource = dt;
            //metroGrid1.Refresh();

            //  metroGrid1.DataSource = dt;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            dt.Rows.Add(metroTextBox6.Text, comboBox1.Text, metroTextBox1.Text, metroTextBox2.Text, metroTextBox3.Text, metroDateTime1.Text, metroTextBox5.Text);
            for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
            {

                sum = sum + double.Parse(metroGrid1.Rows[i].Cells[6].Value.ToString());
            }

            metroTextBox4.Text = Convert.ToString(Math.Round(sum, 2));
            //metroGrid1.DataSource = null;
            comboBox1.Text = null;
            //metroComboBox2.Text = null;
            metroTextBox1.Text = "";
            metroTextBox2.Text = "0.00";
            metroTextBox3.Text = "";
            metroTextBox5.Text = "";
            //metroTextBox4.Text = null;
            //metroTextBox6.Text = "";
            //metroGrid1.Rows.Clear();
            //metroGrid1.Refresh();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("MADNI MEDICAL STORE", new Font("Agency FB", 30, FontStyle.Bold),
                Brushes.Black, new Point(25, 70));
            e.Graphics.DrawString("Milad Chowk DINGA", new Font("Arial", 18, FontStyle.Bold),
                Brushes.Black, new Point(25, 125));
            e.Graphics.DrawString("PH:- 0301-6263105,053-7404933", new Font("Agency FB", 22, FontStyle.Bold),
                Brushes.Black, new Point(25, 150));
            e.Graphics.DrawString("Date: " + metroDateTime1.Text, new Font("Arial", 12, FontStyle.Bold),
                Brushes.Red, new Point(25, 250));
            e.Graphics.DrawString(metroLabel6.Text, new Font("Arial", 12, FontStyle.Bold),
                Brushes.Red, new Point(25, 230));
            e.Graphics.DrawString("Patient Name:" + metroTextBox6.Text, new Font("Arial", 12, FontStyle.Bold),
                Brushes.Red, new Point(25, 200));
            e.Graphics.DrawString("Name:", new Font("Arial", 12, FontStyle.Bold),
                Brushes.Red, new Point(25, 300));
            e.Graphics.DrawString("Qty: ", new Font("Arial", 12, FontStyle.Bold),
                Brushes.Red, new Point(150, 300));
            e.Graphics.DrawString("Price: ", new Font("Arial", 12, FontStyle.Bold),
                Brushes.Red, new Point(250, 300));
            e.Graphics.DrawString("G.T: " + metroTextBox4.Text, new Font("Arial", 16, FontStyle.Bold),
                Brushes.Red, new Point(275, 200));
            // e.Graphics.DrawString(Admin.option, new Font("Arial", 16, FontStyle.Bold),
            //Brushes.Red, new Point(310, 330));
            e.Graphics.DrawString(User.option, new Font("Arial", 16, FontStyle.Bold),
            Brushes.Red, new Point(310, 330));
            e.Graphics.DrawString("Dis%" + metroTextBox7.Text, new Font("Arial", 16, FontStyle.Bold),
                Brushes.Red, new Point(310, 350));
            int a = 0;
            for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
            {
                //  e.Graphics.DrawString(metroGrid1.Rows[i].Cells[0].Value.ToString(),
                //new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 350 + (i * 20)));
                e.Graphics.DrawString(metroGrid1.Rows[i].Cells[1].Value.ToString(),
              new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(25, 350 + (i * 20 + a)));
                e.Graphics.DrawString(metroGrid1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 12,
              FontStyle.Bold), Brushes.Black, new Point(150, 380 + (i * 20 + a)));
                e.Graphics.DrawString(metroGrid1.Rows[i].Cells[6].Value.ToString(), new Font("Arial", 12,
                FontStyle.Bold), Brushes.Black, new Point(250, 380 + (i * 20 + a)));
                a += 30;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string name, category, patient_name;
            double sale_rate = 0.0;
            int quantity = 0;
            DateTime date;
            double price = 0.0;
            //double grand_total = 0.0;
            for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
            {
                patient_name = metroGrid1.Rows[i].Cells[0].Value.ToString();
                name = metroGrid1.Rows[i].Cells[1].Value.ToString();
                category = metroGrid1.Rows[i].Cells[2].Value.ToString();
                sale_rate = Convert.ToDouble(metroGrid1.Rows[i].Cells[3].Value.ToString());
                quantity = Convert.ToInt32(metroGrid1.Rows[i].Cells[4].Value.ToString());
                date = Convert.ToDateTime(metroGrid1.Rows[i].Cells[5].Value.ToString());
                price = Convert.ToDouble(metroGrid1.Rows[i].Cells[6].Value.ToString());
                Table<Sales> s1 = dc.GetTable<Sales>();
                Sales s = new Sales();
                s.Name = name;
                s.Patient_name = patient_name;
                s.Category = category;
                s.Sale_rate = sale_rate;
                s.Quantity = quantity;
                s.Date = date;
                s.Price = price;
                s1.InsertOnSubmit(s);
                dc.SubmitChanges();

            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string name, category, patient_name;
            double sale_rate = 0.0;
            int quantity = 0;
            DateTime date;
            double price = 0.0;
            double grand_total = 0.0;
            for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
            {
                patient_name = metroGrid1.Rows[i].Cells[0].Value.ToString();
                name = metroGrid1.Rows[i].Cells[1].Value.ToString();
                category = metroGrid1.Rows[i].Cells[2].Value.ToString();
                sale_rate = Convert.ToDouble(metroGrid1.Rows[i].Cells[3].Value.ToString());
                quantity = Convert.ToInt32(metroGrid1.Rows[i].Cells[4].Value.ToString());
                date = Convert.ToDateTime(metroGrid1.Rows[i].Cells[5].Value.ToString());
                price = Convert.ToDouble(metroGrid1.Rows[i].Cells[6].Value.ToString());
                grand_total = Convert.ToDouble(metroTextBox4.Text);
                Table<Sales> s1 = dc.GetTable<Sales>();
                Sales s = new Sales();
                s.Name = name;
                s.Patient_name = patient_name;
                s.Category = category;
                s.Sale_rate = sale_rate;
                s.Quantity = quantity;
                s.Date = date;
                s.Price = price;
                s1.InsertOnSubmit(s);
                dc.SubmitChanges();

            }
            MetroFramework.MetroMessageBox.Show(this, "Saved");
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (Sales.option5 == "AdminMenu")
            {
                AdminMenu am = new AdminMenu();
                this.Hide();
                am.Show();
            }
            else if (Sales.option5 == "UserMenu")
            {
                UserMenu um = new UserMenu();
                this.Close();
                um.Show();
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            int rowindex = metroGrid1.CurrentCell.RowIndex;
            metroGrid1.Rows.RemoveAt(rowindex);
            double sum = 0;
            dt.Rows.Add(metroTextBox6.Text, comboBox1.Text, metroTextBox1.Text, metroTextBox2.Text, metroTextBox3.Text, metroDateTime1.Text, metroTextBox5.Text);
            for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
            {

                sum = sum + double.Parse(metroGrid1.Rows[i].Cells[7].Value.ToString());

            }
            metroTextBox4.Text = Convert.ToString(Math.Round(sum, 2));


        }

        private void metroTextBox5_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox5.Text == "")
            {
                metroTextBox5.Text = "0.00";
            }
        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroTextBox7_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox7.Text == "")
            {
                metroTextBox7.Text = "0";
            }
            int discount = Convert.ToInt32(metroTextBox7.Text);
            double grand_total_without_discount = Convert.ToDouble(metroTextBox4.Text);
            double discount_value;
            double grand_total_with_discount = Convert.ToDouble(metroTextBox4.Text);
            discount_value = grand_total_without_discount * discount / 100;
            grand_total_with_discount = grand_total_without_discount - discount_value;
            metroTextBox4.Text = Convert.ToString(Math.Round(grand_total_with_discount, 2));
        }

        private void metroTextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                comboBox1.Focus();
            }
        }

        private void metroComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox3.Focus();
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
                metroButton6.Focus();
            }
        }

        private void metroButton6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                metroTextBox6.Focus();
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Table<Classes.Product> p = dc.GetTable<Classes.Product>();
            var query = from k in p
                        where k.Name == Convert.ToString(comboBox1.Text)
                        select k;
            foreach (var i in query)
            {
                if (metroTextBox1.Text == "Other")
                {
                    metroTextBox2.Text = Convert.ToString(i.Item_unit_cost);
                }
                else
                {
                    metroTextBox1.Text = i.Type;
                    metroTextBox2.Text = Convert.ToString(i.Sub_item_unit_cost);
                }
            }
        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox7_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }
    }
}

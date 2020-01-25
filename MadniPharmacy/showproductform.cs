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
    public partial class showproductform :MetroFramework.Forms.MetroForm
    {
        public showproductform()
        {
            InitializeComponent();
        }
        //DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataContext dc = new DataContext(Connection.dcc);
        DataTable dt = new DataTable();
        public void RefreshPage()
        {
            dt = new DataTable();
            Table<Product> p = dc.GetTable<Product>();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Batch No", typeof(string));
            dt.Columns.Add("Company Name", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Package Name", typeof(string));
            dt.Columns.Add("Purchase Rate", typeof(int));
            dt.Columns.Add("Sale Rate", typeof(int));
            dt.Columns.Add("No Of Item In Pack", typeof(int));
            dt.Columns.Add("Item Type", typeof(string));
            dt.Columns.Add("Item Unit Cost", typeof(float));
            dt.Columns.Add("No Of Sub_Item In Item", typeof(int));
            dt.Columns.Add("Sub Item Type", typeof(string));
            dt.Columns.Add("Sub Item Unit Cost", typeof(float));
            dt.Columns.Add("No Of Tablets in Pack", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            var query = from k in p
                        select k;
            foreach (var i in query)
            {
                dt.Rows.Add(i.ID,i.Name,i.Batchno,i.Cname,i.Type,i.Package_name,i.Purchase_rate,i.Sale_rate,i.No_of_items_in_pack,i.Item_type,i.Item_unit_cost,i.No_of_sub_items_in_item,i.Sub_item_type,i.Sub_item_unit_cost,i.No_of_tablets_in_pack,i.Quantity,i.Date);
            }
            metroGrid1.DataSource = dt;
        }
        private void showproductform_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            Table<Product> p = dc.GetTable<Product>();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Batch No", typeof(string));
            dt.Columns.Add("Company Name", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Package Name", typeof(string));
            dt.Columns.Add("Purchase Rate", typeof(int));
            dt.Columns.Add("Sale Rate", typeof(int));
            dt.Columns.Add("No Of Item In Pack", typeof(int));
            dt.Columns.Add("Item Type", typeof(string));
            dt.Columns.Add("Item Unit Cost", typeof(float));
            dt.Columns.Add("No Of Sub_Item In Item", typeof(int));
            dt.Columns.Add("Sub Item Type", typeof(string));
            dt.Columns.Add("Sub Item Unit Cost", typeof(float));
            dt.Columns.Add("No Of Tablets in Pack", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            var query = from k in p
                        select k;
            foreach( var i in query)
            {
                dt.Rows.Add(i.ID, i.Name, i.Batchno, i.Cname, i.Type, i.Package_name, i.Purchase_rate, i.Sale_rate, i.No_of_items_in_pack, i.Item_type, i.Item_unit_cost, i.No_of_sub_items_in_item, i.Sub_item_type, i.Sub_item_unit_cost, i.No_of_tablets_in_pack, i.Quantity, i.Date);
            }
            metroGrid1.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Table<Product> p = dc.GetTable<Product>();
            var query = from k in p
                        where k.ID == val
                        select k;
            foreach( var j in query)
            {
                p.DeleteOnSubmit(j);
            }
            dc.SubmitChanges();
            RefreshPage();
            MetroFramework.MetroMessageBox.Show(this, "Data Deleted Successfully");
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            updateproductform upf = new updateproductform();
            upf.ShowData(val);
            upf.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == "")

            {
                textBox1.Text = "";
            }
            else
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("Name like '%{0}%'", textBox1.Text.Trim());
                metroGrid1.DataSource = dv;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            this.Close();
            am.Show();
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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
                textBox1.Focus();
            }
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //var cell = metroGrid1.SelectedCells[0];
            //var row = metroGrid1.Rows[cell.RowIndex];
            //int val = Convert.ToInt32(row.Cells[0].Value);
            //Table<Product> c = dc.GetTable<Product>();
            //var query = from k in c
            //            where k.ID == val
            //            select k;
            //foreach (var j in query)
            //{
            //    c.DeleteOnSubmit(j);
            //}
            //dc.SubmitChanges();
            //RefreshPage();
            //MetroFramework.MetroMessageBox.Show(this, "Data Deleted Successfully");
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton6_Click_1(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            am.Show();
            this.Hide();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            Table<Product> c = dc.GetTable<Product>();
            var query = from k in c
                        where k.ID == val
                        select k;
            foreach (var j in query)
            {
                c.DeleteOnSubmit(j);
            }
            dc.SubmitChanges();
            RefreshPage();
            MetroFramework.MetroMessageBox.Show(this, "Data Deleted Successfully");
        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            var cell = metroGrid1.SelectedCells[0];
            var row = metroGrid1.Rows[cell.RowIndex];
            int val = Convert.ToInt32(row.Cells[0].Value);
            updateproductform upf = new updateproductform();
            upf.ShowData(val);
            upf.Show();
            this.Hide();

        }
    }
}

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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MadniPharmacy
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        DataTable dt = new DataTable();

        private void Report_Load(object sender, EventArgs e)
        {
            Table<Sales> s = dc.GetTable<Sales>();
            
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Product_Name", typeof(string));
            //dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("Price", typeof(int));

            var query = from k in s
                        select k;
            foreach(var i in query)
            {
                dt.Rows.Add(i.ID, i.Name, i.Quantity, i.Price);
            }
            metroGrid1.DataSource = dt;
            int sum = 0;
            for (int i = 0; i < metroGrid1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(metroGrid1.Rows[i].Cells[4].Value);
            }
            metroLabel1.Text = "Total Sale ="+sum.ToString();
            
        }
        
    }
}

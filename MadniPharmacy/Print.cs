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
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
            
        }
        DataContext dc = new DataContext("Data Source=.;Initial Catalog=pharmacy;Integrated Security=True");
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Welcome to the Company", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 10));
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Sales s = new Sales();
        }

        private void Print_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}

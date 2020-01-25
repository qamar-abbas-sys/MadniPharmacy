using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadniPharmacy.Classes
{
    [Table(Name ="purchase")]
    class Purchase
    {
        int id;
        [Column(Name = "id", IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        string name;
        [Column(Name = "name")]
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        string type;
        [Column(Name = "type")]
        public string Type
        {
            set
            {
                type = value;
            }
            get
            {
                return type;
            }
        }
        double purchase_rate;
        [Column(Name = "purchase_rate")]
        public double Purchase_rate
        {
            set
            {
                purchase_rate = value;
            }
            get
            {
                return purchase_rate;
            }
        }
        int quantity;
        [Column(Name = "quantity")]
        public int Quantity
        {
            set
            {
                quantity = value;
            }
            get
            {
                return quantity;
            }
        }
        double total_price;
        [Column(Name = "total_price")]
        public double Total_price
        {
            set
            {
                total_price = value;
            }
            get
            {
                return total_price;
            }
        }
        DateTime date;
        [Column(Name = "date")]
        public DateTime Date
        {
            set
            {
                date = value;
            }
            get
            {
                return date;
            }
        }
        DateTime expiry_date;
        [Column(Name = "expiry_date")]
        public DateTime Expiry_date
        {
            set
            {
                expiry_date = value;
            }
            get
            {
                return expiry_date;
            }
        }
        public static string option4;
    }
}

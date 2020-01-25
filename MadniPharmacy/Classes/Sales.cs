using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadniPharmacy.Classes
{
    [Table(Name ="Sales")]
    class Sales
    {
        int id;
        [Column(Name = "id", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID
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
        string category;
        [Column(Name = "category")]
        public string Category
        {
            set
            {
                category = value;
            }
            get
            {
                return category;
            }
        }

        
      
        double sale_rate;
        [Column(Name = "sale_rate")]
        public double Sale_rate
        {
            set
            {
                sale_rate = value;
            }
            get
            {
                return sale_rate;
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
        double price;
        [Column(Name = "price")]
        public double Price
        {
            set
            {
                price = value;
            }
            get
            {
                return price;
            }
        }
        string patient_name;
        [Column(Name = "patient_name")]
        public string Patient_name
        {
            set
            {
                patient_name = value;
            }
            get
            {
                return patient_name;
            }
        }
        public static string option5;
        public static double result;
    }
}

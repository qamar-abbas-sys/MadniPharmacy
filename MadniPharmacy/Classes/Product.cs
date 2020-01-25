using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadniPharmacy.Classes
{
    [Table(Name ="product")]
    class Product
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
        string batchno;
        [Column(Name = "batchno")]
        public string Batchno
        {
            set
            {
                batchno = value;
            }
            get
            {
                return batchno;
            }
        }
        string cname;
        [Column(Name = "cname")]
        public string Cname
        {
            set
            {
                cname = value;
            }
            get
            {
                return cname;
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
        string package_name;
        [Column(Name = "package_name")]
        public string Package_name
        {
            set
            {
                package_name = value;
            }
            get
            {
                return package_name;
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
        int no_of_items_in_pack;
        [Column(Name = "no_of_items_in_pack")]
        public int No_of_items_in_pack
        {
            set
            {
                no_of_items_in_pack = value;
            }
            get
            {
                return no_of_items_in_pack;
            }
        }
        string item_type;
        [Column(Name = "item_type")]
        public string Item_type
        {
            set
            {
                item_type = value;
            }
            get
            {
                return item_type;
            }
        }
        double item_unit_cost;
        [Column(Name = "item_unit_cost")]
        public double Item_unit_cost
        {
            set
            {
                item_unit_cost = value;
            }
            get
            {
                return item_unit_cost;
            }
        }
        int no_of_sub_items_in_item;
        [Column(Name = "no_of_sub_items_in_item")]
        public int No_of_sub_items_in_item
        {
            set
            {
                no_of_sub_items_in_item = value;
            }
            get
            {
                return no_of_sub_items_in_item;
            }
        }
        string sub_item_type;
        [Column(Name = "sub_item_type")]
        public string Sub_item_type
        {
            set
            {
                sub_item_type = value;
            }
            get
            {
                return sub_item_type;
            }
        }
        double sub_item_unit_cost;
        [Column(Name = "sub_item_unit_cost")]
        public double Sub_item_unit_cost
        {
            set
            {
                sub_item_unit_cost = value;
            }
            get
            {
                return sub_item_unit_cost;
            }
        }
        int no_of_tablets_in_pack;
        [Column(Name = "no_of_tablets_in_pack")]
        public int No_of_tablets_in_pack
        {
            set
            {
                no_of_tablets_in_pack = value;
            }
            get
            {
                return no_of_tablets_in_pack;
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
        //public static string option3;
    }
}

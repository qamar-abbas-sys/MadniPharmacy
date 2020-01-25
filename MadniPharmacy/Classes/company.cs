using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadniPharmacy.Classes
{
    [Table(Name ="company")]
    class company
    {
        int id;
        [Column(Name ="id",IsDbGenerated =true,IsPrimaryKey =true)]
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
        [Column(Name ="name")]
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
        string tradeno;
        [Column(Name = "tradeno")]
        public string Tradeno
        {
            set
            {
                tradeno = value;
            }
            get
            {
                return tradeno;
            }
        }
        string address;
        [Column(Name = "address")]
        public string Address
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }
        }
        string services;
        [Column(Name = "services")]
        public string Services
        {
            set
            {
                services = value;
            }
            get
            {
                return services;
            }
        }
        //public static string option1;
    }
}

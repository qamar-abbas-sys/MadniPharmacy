using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadniPharmacy.Classes
{
    [Table(Name="Admin")]
    class Admin
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
        string pass;
        [Column(Name = "pass")]
        public string Pass
        {
            set
            {
                pass = value;
            }
            get
            {
                return pass;
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
        public static string option;
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadniPharmacy.Classes
{
    [Table(Name ="distributer")]
    class Distributer
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
        string email;
        [Column(Name = "email")]
        public string Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }
        string cnic;
        [Column(Name = "cnic")]
        public string CNIC
        {
            set
            {
                cnic = value;
            }
            get
            {
                return cnic;
            }
        }
        int cellno;
        [Column(Name ="cellno")]
        public int CellNo
        {
            set
            {
                cellno = value;
            }
            get
            {
                return cellno;
            }
        }
        //public static string option2;
    }
}

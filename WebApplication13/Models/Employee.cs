using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    [Table("Table1")]

    public class Employee

    {

        [Key]

        public int id { get; set; }

        public string name { get; set; }

        public char gender { get; set; }

        public string City { get; set; }

 

    }
}
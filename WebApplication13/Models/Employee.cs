using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    [Table("EmployeeTable")]

    public class Employee

    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public int DepartmentId { get; set; }



    }
}
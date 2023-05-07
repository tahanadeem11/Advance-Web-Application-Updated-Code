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
        [Required(ErrorMessage = "Please enter an ID")]
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please select a Gender")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Please enter an ID")]
        public string city { get; set; }
        [Required(ErrorMessage = "Please select a department")]
        public int DepartmentId { get; set; }




    }
}
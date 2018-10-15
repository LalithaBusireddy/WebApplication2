using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models
{
    public class Employee
    { 
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployeeName { get; set; }
        public string Location { get; set; }
        //test
    }
}
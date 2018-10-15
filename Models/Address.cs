using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public int HouseNo { get; set; }
        [Required]
        [MaxLength(50)]
        public String StreetName { get; set; }
        [Required]
        [MaxLength(50)]
        public String City { get; set; }
        [Required]
        [MaxLength(50)]
        public String State { get; set; }
        [Required]
        [MaxLength(50)]
        public String Country { get; set; }
        [Required]
        public int Zipcode { get; set; }
        public override string ToString()
        {
            return this.HouseNo + "|" + this.StreetName + "|" + this.City + "|" +  this.State + "|" + this.Country + "|" + this.Zipcode;
            //return base.ToString();
        }


    }
}
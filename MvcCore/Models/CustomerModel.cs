using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Models
{
    public class CustomerModel
    {
        public int id { get; set; }
        //Data Annotations -- Validation
        [Required]
        //[RegularExpression ("^[a-z],{1,10}$")]
        public string name { get; set; }
        // one to many relationship
        public List<Address> addresses { get; set; }

    }
    public class Address
    {
        public int id { get; set; }
        [Required]
        public string address { get; set; }
       
        public CustomerModel customer { get; set; }
    }

}

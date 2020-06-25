using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Models
{
    public class CustomerModel
    {
        //Data Annotations -- Validation
        [Required]
        //[RegularExpression ("^[a-z],{1,10}$")]
        public string name { get; set; }

        [Required]
        public string address { get; set; }

    }
}

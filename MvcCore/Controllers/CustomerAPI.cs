using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcCore.dal;
using MvcCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcCore.Controllers
{
    [Authorize]    //JWT:step 3
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAPI : ControllerBase
    {
       
        // GET: api/<CustomerAPI>
        [HttpGet]
        public IActionResult Get(string customerName)
        {
            CustomerDal dal = new CustomerDal();
            //LINQ code
            List<CustomerModel> search = (from temp in dal.CustomerModels
                                          where temp.name == customerName
                                          select temp).ToList<CustomerModel>();
            return Ok(search);
        }

        // GET api/<CustomerAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerAPI>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel obj)
        {
            //create context object
            var context = new ValidationContext(obj, null, null);
            // add error in result collecton
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, result, true);

            if (result.Count == 0)
            {
                CustomerDal dal = new CustomerDal();
                dal.Database.EnsureCreated();  // creates tblCustomer if not created
                dal.Add(obj);  // add in memory
                dal.SaveChanges(); // entry in database

                List<CustomerModel> recs = dal.CustomerModels.ToList<CustomerModel>();

                return StatusCode(200, recs); // 200 (Success)
            }
            else
            {
                return StatusCode(500, result);  // 500 (Error)
            }
        }

        // PUT api/<CustomerAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Models.Relational;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly CustomerRelationalRepository _sqlRepository;

        public CustomerController(CustomerRelationalRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _sqlRepository.GetAll();
            if (customers == null)
            {
                return NotFound();
            }
            return new ObjectResult(customers);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(long id)
        {
            var customer = _sqlRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return new ObjectResult(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerRecord customer)
        {
            CustomerRecord created = _sqlRepository.Create(customer);
            return CreatedAtRoute("GetCustomer", new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] CustomerRecord customer)
        {
            var record = _sqlRepository.GetById(id);
            if (record == null)
            {
                return NotFound();
            }
            customer.Id = id;
            _sqlRepository.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var record = _sqlRepository.GetById(id);
            if (record == null)
            {
                return NotFound();
            }
            _sqlRepository.Remove(id);
            return NoContent();
        }

    }
}

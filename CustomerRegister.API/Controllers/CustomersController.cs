using CustomerRegister.Application.Commands.CreateCustomer;
using CustomerRegister.Application.Commands.DeleteCustomer;
using CustomerRegister.Application.Commands.UpdateCustomer;
using CustomerRegister.Application.Queries.GetAllCustomers;
using CustomerRegister.Application.Queries.GetCustomerByEmail;
using CustomerRegister.Application.Queries.GetCustomerById;
using CustomerRegister.Application.ViewModels;
using CustomerRegister.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace CustomerRegister.API.Controllers
{
    [Route("api/Customers")]
    public class CustomersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("[action]/{email}", Name = "GetCustomerByEmail")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var customer = await _mediator.Send(new GetCustomerByEmailQuery(email));

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id:length(24)}", Name = "UpdateCustomer")]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateCustomerCommand command)
        {
            if (command.FullName.Length > 200)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteCustomer")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string email)
        {
            var customer = await _mediator.Send(new GetCustomerByEmailQuery(email));

            if (customer == null)
                return NotFound();

            await _mediator.Send(new DeleteCustomerCommand(customer.Email));

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(string query)
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery(query));

            return Ok(customers);
        }
    }
}

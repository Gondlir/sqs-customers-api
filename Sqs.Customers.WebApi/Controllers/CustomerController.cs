using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sqs.Customers.Application.CustomersServices;
using Sqs.Infrastructure.DTO;
using System.Diagnostics;

namespace Sqs.Customers.WebApi.Controllers
{
    //[ApiVersionNeutral]
    //[Authorize]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersServices _customerService;

        public CustomerController(ICustomersServices customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetCustomerById(Guid id) 
        {
            try
            {
                var customer = _customerService.GetById(id);
                return customer == null ? BadRequest("Cliente não existe em nossa base.") 
                    : Ok(new { customer.Name, customer.Email, customer.GitHubUsername });
                
                //return Ok(new { customer.Name, customer.Email, customer.GitHubUsername });
            }
            catch (Exception ex)
            {
                var error = new
                {
                    Message = "Houve algum erro ao solicitar serviço.",
                    ExceptionMessage = ex.Message,
                    InnerException = ex.InnerException.Message,
                    StackTrace = ex.StackTrace
                };
                throw;
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert([FromBody] CreateCustomerDTO dto)
        {
            try
            {
                var response = _customerService.InsertCustomer(dto);
                return Ok(new { response.CustomerId, response.Name, response.GitHubUserName });
            }
            catch (Exception ex)
            {
                var error = new
                {
                    Message = "Houve algum erro ao solicitar serviço.",
                    ExceptionMessage = ex.Message,
                    InnerException = ex.InnerException.Message,
                    StackTrace = ex.StackTrace
                };
                return BadRequest(error);
                throw;
            }
            //add a action result pattern to handle responses 
        }
        [HttpPut]
        [Route("[action]/{customerId}")]
        public IActionResult Update(Guid customerId, [FromBody] UpdateCustomerDTO dto)
        {
            try
            {
                dto.Id = customerId;
                var response = _customerService.UpdateCustomer(dto);
                return Ok(new { response.CustomerId, response.Name, response.GitHubUserName });
            }
            catch (Exception ex)
            {
                var error = new
                {
                    Message = "Houve algum erro ao solicitar serviço.",
                    ExceptionMessage = ex.Message,
                    InnerException = ex.InnerException.Message,
                    StackTrace = ex.StackTrace
                };
                return BadRequest(error);
                throw;
            }
        }

        [HttpDelete]
        [Route("[action]/{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            try
            {
                _customerService.DeleteCustomer(customerId);
                return Ok("Cliente excluido!");
            }
            catch (Exception ex)
            {
                var error = new
                {
                    Message = "Houve algum erro ao solicitar serviço.",
                    ExceptionMessage = ex.Message,
                    InnerException = ex.InnerException.Message,
                    StackTrace = ex.StackTrace
                };
                return BadRequest(error);
                throw;
            }
             
        }
    }
}

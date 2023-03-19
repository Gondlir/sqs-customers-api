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
    }
}

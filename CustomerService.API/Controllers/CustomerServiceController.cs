using CustomerService.API.Models;
using CustomerService.Domain.Entities;
using CustomerService.Domain.Interfaces;
using CustomerService.Service.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceController : ControllerBase
    {
        private IBaseService<ClientEntity> _baseUserService;

        public CustomerServiceController(IBaseService<ClientEntity> baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateClientModel user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Add<CreateClientModel, ClientModel, CreditValidator>(user));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseUserService.Get<ClientModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById<ClientModel>(id));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateClientModel user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<UpdateClientModel, ClientModel, CreditValidator>(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseUserService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

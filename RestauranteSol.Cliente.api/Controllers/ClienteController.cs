using Microsoft.AspNetCore.Mvc;

using RestaurantePro.Cliente.Domain.Interface;
using RestaurantePro.Cliente.Application;
using RestaurantePro.Cliente.Application.Dtos;
using RestaurantePro.Cliente.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestauranteSol.Cliente.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;
        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet("GetCliente")]


        public IActionResult Get()
        {
            var result = this.clienteService.GetClientes();
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);

        }


        [HttpGet("GetClientebyId")]
        public IActionResult Get(int id)
        {
            var result = this.clienteService.GetCliente(id);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }


        [HttpPost("SaveCliente")]
        public IActionResult Post([FromBody] ClienteSaveDto clienteSaveDto)
        {
            clienteSaveDto.ChangeDate = DateTime.Now;
            clienteSaveDto.ChangeUser = 1;
            var result = this.clienteService.saveCliente(clienteSaveDto);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }


        [HttpPost("UpdateCliente")]
        public IActionResult Put(ClienteUpdateDto clienteUpdateDto)
        {
            var result = this.clienteService.updateCliente(clienteUpdateDto);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost("RemoveCliente")]
        public IActionResult Delete(ClienteRemoveDto clienteRemoveDto)
        {
            var result = this.clienteService.removeCliente(clienteRemoveDto);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }


    
}



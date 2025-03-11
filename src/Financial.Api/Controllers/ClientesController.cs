using Financial.Application.models;
using Financial.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(ILogger<ClientesController> logger, IClienteAppService clienteAppService)
        {
            _logger = logger;
            _clienteAppService = clienteAppService;
        }

        [HttpPost(Name = "CreateCliente")]
        public async Task<IActionResult> Post(ClienteViewModel cliente)
        {
            var result = await _clienteAppService.RegistrarCliente(cliente);

            if (result.IsValid)
            {
                return Ok("Cliente cadastrado com sucesso!");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}

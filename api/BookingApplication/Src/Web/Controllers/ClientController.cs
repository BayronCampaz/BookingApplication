using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _service;

        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _service = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            return Ok(await this._service.CreateClient(client));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await _service.GetAllClients());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            return Ok(await _service.GetClientById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, Client client)
        {
            return this.Ok(await this._service.UpdateClient(id, client));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            return this.Ok(await this._service.DeleteClient(id));
        }


    }
}

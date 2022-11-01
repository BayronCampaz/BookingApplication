using Domain.Abstractions.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ILogger<TableController> _logger;
        private readonly ITableService _service;

        public TableController(ILogger<TableController> logger, ITableService tableService)
        {
            _logger = logger;
            _service = tableService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(Table table)
        {
            return Ok(await this._service.Create(table));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(Guid id, Table table)
        {
            return this.Ok(await this._service.Update(id, table));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(Guid id)
        {
            return this.Ok(await this._service.Delete(id));
        }


    }
}

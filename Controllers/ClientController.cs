using Cofetarie.Entities;
using Cofetarie.Managers;
using Cofetarie.Models;
using Cofetarie.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Cofetarie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientsManager manager;

        public ClientController(IClientsManager clientsManager)
        {
            this.manager = clientsManager;
        }

        [HttpGet]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetClients()
        { 
            //select * from Clients;
            var clients = manager.GetClients();

            return Ok(clients);
        }

        [HttpGet("select")]
        public async Task<IActionResult> GetClientsIds()
        {
            //select Id from Clients;
            var clientsIds = manager.GetClientsIds();

            return Ok(clientsIds);
        }

        [HttpGet("eager-join")]
        public async Task<IActionResult> JoinEager()
        {
            var clients = manager.GetClientsWithJoin();
            /* var clients = db.Clients
                 .Include(x => x.Orders)
                 .ToList();*/

            foreach (var x in clients)
            {
                var y = x.Orders;
            }
            return Ok(clients);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter()
        {
            var clients = manager.GetClientsFiltered();
        /*    var clients = db.Clients
                .Include(x => x.Orders)
                .Where(x => x.Orders.Price > 50)
                .Select(x => new { Id = x.Id, OrderId = x.Orders.FirstOrDefault().Id })
                .ToList();*/

            return Ok(clients);
        }
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] string firstname)
        {
            var newClient = new Client
            {
                FirstName = firstname
            };

            //db.Add(newClient);
            await manager.Create(newClient);

            return Ok();
        }

        [HttpPost("withObj")]
        public async Task<IActionResult> Create([FromBody] ClientModel clientModel)
        {
            var newClient = new Client
            {
                FirstName = clientModel.FirstName,
                LastName = clientModel.LastName,
                Phone = clientModel.Phone
            };

            await manager.Create(newClient);

            return Ok();
        }

        [HttpPut("withObj")]
        public async Task<IActionResult> Update([FromBody] ClientModel clientModel)
        {
            await manager.Update(clientModel) ;

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            manager.Delete(id);

            return Ok();
        }

    }
}

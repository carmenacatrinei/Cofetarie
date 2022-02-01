using Cofetarie.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly CofetarieContext db;

        public ClientsRepository(CofetarieContext db)
        {
            this.db = db;
        }

        public IQueryable<Client> GetClients()
        {
            var clients = db.Clients;

            return clients;
        }

        public IQueryable<int> GetClientsIds()
        {
            var clientIds = db.Clients.Select(x => x.Id);

            return clientIds;
        }

        public IQueryable<int> GetOrderPrice()
        {
            var price = db.Orders.Select(x => x.Price);

            return price;
        }

        public IQueryable<Client> GetClientsWithJoin()
        {
            var clientsJoin = db.Clients
                .Include(x => x.Orders);

            return clientsJoin;
        }

        public async Task Create(Client client)
        {
            await db.Clients.AddAsync(client);

            await db.SaveChangesAsync();

        }
        public async Task Update(Client client)
        {
            db.Clients.Update(client);

            await db.SaveChangesAsync();
        }

        public async Task Delete(Client client)
        {
            db.Clients.Remove(client);

            await db.SaveChangesAsync();
        }

    }
}

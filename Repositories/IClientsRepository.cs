using Cofetarie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Repositories
{
    public interface IClientsRepository
    {
        IQueryable<Client> GetClients();

        IQueryable<int> GetClientsIds();

        IQueryable<int> GetOrderPrice();

        IQueryable<Client> GetClientsWithJoin();

        Task Create(Client client);

        Task Update(Client client);

        Task Delete(Client client);
    }
}

using Cofetarie.Entities;
using Cofetarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Managers
{
    public interface IClientsManager
    {
        List<Client> GetClients();
        //select
        List<int> GetClientsIds();

        List<Client> GetClientsWithJoin();

        Client GetClientById(int id);

        List<int> GetPrices();

        List<ClientPriceOrderModel> GetClientsFiltered();

        Task Create(Client product);

        Task Update(ClientModel product);

        Task Delete(Client product);

        public void Delete(int id);
    }
}

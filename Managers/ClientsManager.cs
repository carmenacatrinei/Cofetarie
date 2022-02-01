using Cofetarie.Entities;
using Cofetarie.Models;
using Cofetarie.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Managers
{
    public class ClientsManager : IClientsManager
    {
        private readonly IClientsRepository clientsRepository;

        public ClientsManager(IClientsRepository repository)
        {
            this.clientsRepository = repository;
        }

        public async Task Create(Client product)
        {
            await clientsRepository.Create(product);
        }

        public async Task Delete(Client product)
        {
            await clientsRepository.Delete(product);
        }
        public Client GetClientById(int id)
        {
            var client = clientsRepository.GetClients()
                .FirstOrDefault(x => x.Id == id);

            return client;
        }

        public void Delete(int id)
        {
            var client = GetClientById(id);

            clientsRepository.Delete(client);
        }

        public List<Client> GetClients()
        {
            return clientsRepository.GetClients().ToList();
        }

        public List<int> GetPrices()
        {
            return clientsRepository.GetOrderPrice().ToList();
        }

        //nu functioneaza exact cum vreau, nu imi dau seama cum ar trebui sa fac
        //selectez clientii a caror comanda depaseste 50
        public List<ClientPriceOrderModel> GetClientsFiltered()
        {
            var clients = clientsRepository.GetClientsWithJoin();
            var price = clientsRepository.GetOrderPrice();
            var clientsFiltered = clients.Where(price => price.Id > 50)
               .Select(x => new ClientPriceOrderModel { Id = x.Id, OrderId = x.Orders.FirstOrDefault().Id })
               .ToList();
           return clientsFiltered;
        }

        public List<int> GetClientsIds()
        {
            return clientsRepository.GetClientsIds().ToList();
        }


        public List<Client> GetClientsWithJoin()
        {
            return clientsRepository.GetClientsWithJoin().ToList();
        }

        public async Task Update(ClientModel clientModel)
        {
            var client = clientsRepository
                .GetClients()
                .FirstOrDefault(x => x.Id == clientModel.Id);

            client.FirstName = clientModel.FirstName;

            await clientsRepository.Update(client);
        }
    }
}


using LifeBoat_API.Models;
using Microsoft.AspNetCore.SignalR;

namespace LifeBoat_API.Hubs
{
    public class InfoHub : Hub
    {
        private ISupplyRepository _supplyRepository;
        public async Task GetSupply(string name)
        {
            Supply supply = _supplyRepository.Get(name);
            await this.Clients.Caller.SendAsync("SupplyInfo", supply);
        }
        public async Task GetSupplies() 
        {
            var supplies = _supplyRepository.GetSupplies();
            await this.Clients.Caller.SendAsync("Supplies", supplies);
        }
        public async Task Ping()
        {
            await this.Clients.Caller.SendAsync("Ping", "ping");
        }

        public InfoHub(ISupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }
    }
}

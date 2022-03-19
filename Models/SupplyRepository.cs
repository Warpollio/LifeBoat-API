using System.Data;
using Dapper;
using LifeBoat_API.Utils;
using Npgsql;

namespace LifeBoat_API.Models
{
    public interface ISupplyRepository
    {
        Supply Get(string name);
        List<Supply> GetSupplies();
    }
    public class SupplyRepository : ISupplyRepository
    {
        private readonly DapperContext context;
        public SupplyRepository(DapperContext context) 
        {
            this.context = context;
        }
        public List<Supply> GetSupplies() 
        {
            using (var connection = context.CreateConnection())
            {
                return connection.Query<Supply>("SELECT * FROM supply").ToList();
            }
        }
        public Supply Get(string name)
        {
            using (var connection = context.CreateConnection())
            {
                return connection.Query<Supply>("SELECT * FROM supply WHERE Name = @name", new { name }).First();
            }
        }
    }
}

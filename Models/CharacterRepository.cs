using LifeBoat_API.Utils;
using Dapper;

namespace LifeBoat_API.Models
{
    public interface ICharacterRepository
    { 
        Character Get(string name);

        List<Character> GetCharacters(int amount);

        List<Character> GetCharacters();
    }
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DapperContext context;

        public CharacterRepository(DapperContext context)
        { 
            this.context = context;
        }
        public Character Get(string name)
        {
            using (var connection = context.CreateConnection())
            {
                return connection.Query<Character>("SELECT * FROM character WHERE Name = @name", new { name }).First();
            }
        }
        public List<Character> GetCharacters(int amount)
        {
            using (var connection = context.CreateConnection())
            {
                return connection.Query<Character>("SELECT * FROM character").Take(amount).ToList();
            }
        }
        public List<Character> GetCharacters()
        {
            using (var connection = context.CreateConnection())
            {
                return connection.Query<Character>("SELECT * FROM character").ToList();
            }
        }
    }
}

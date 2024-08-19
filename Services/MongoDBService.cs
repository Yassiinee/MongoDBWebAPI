using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBWebAPI.Models;

namespace MongoDBWebAPI.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Person> _people;
        private readonly IMongoCollection<KeyDocument> _keyCollection;
        private string _cryptedKey;
        private bool _isConnected = false;

        public MongoDBService()
        {
            var client = new MongoClient("mongodb://localhost:27017/");
            var database = client.GetDatabase("Person");
            _people = database.GetCollection<Person>("Person");
            _keyCollection = database.GetCollection<KeyDocument>("KeyDocument");
        }
        public async Task ConnectAsync()
        {
            if (_isConnected)
                return;

            _cryptedKey = await FetchCryptedKeyAsync();
            _isConnected = true;
        }
        private async Task<string> FetchCryptedKeyAsync()
        {
            try
            {
                var filter = Builders<KeyDocument>.Filter.Eq(doc => doc._id, "2ef31263-8de5-95b8-de46-658265924e35"); // Adjust filter based on your key document's ID or criteria
                var keyDocument = await _keyCollection.Find(filter).FirstOrDefaultAsync();

                if (keyDocument == null)
                {
                    throw new Exception("Key document not found.");
                }
                return keyDocument.key;

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<Person>> GetPeopleAsync()
        {
            if (!_isConnected)
                throw new InvalidOperationException("Service not connected. Call ConnectAsync first.");

            return await _people.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreatePersonAsync(Person person)
        {
            if (!_isConnected)
                throw new InvalidOperationException("Service not connected. Call ConnectAsync first.");

            await _people.InsertOneAsync(person);
        }
    }
}

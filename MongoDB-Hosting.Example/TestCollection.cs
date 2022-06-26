using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDBHosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Hosting.Example
{
    public class RandomCollection : CollectionBase<RandomModel>
    {
        public RandomCollection(MongoClient client) : base(client, "Example") { }

        public async Task AddRandom(int Number)
            => await Collection.InsertOneAsync(new RandomModel(Number));

        public async Task DeleteRandom(int Number)
            => await Collection.DeleteOneAsync(filter => filter.Number == Number);
    }

    public class RandomModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int Number { get; set; }

        public RandomModel(int Number)
        {
            this.Number = Number;
        }
    }
}

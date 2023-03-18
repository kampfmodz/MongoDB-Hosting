using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBHosting
{
    public abstract class CollectionExtention<T>
    {
        protected IMongoCollection<T> Collection { get; }

        /// <summary>
        /// Constructor for an MongoDB Collection
        /// </summary>
        /// <param name="client">MongoDB Client - gets injected</param>
        /// <param name="Database">Name of the database - gets NOT injected</param>
        public CollectionExtention(MongoClient client, string Database)
        {
            IMongoDatabase mongoDatabase = client.GetDatabase(Database);
            string CollectionName = GetCollectionName(Database);

            if (!mongoDatabase.ListCollectionNames().ToList().Contains(CollectionName))
                mongoDatabase.CreateCollection(CollectionName);

            Collection = mongoDatabase.GetCollection<T>(CollectionName);
        }

        private string GetCollectionName(string Database)
        {
            string CollectionName = typeof(T).Name;
            if (CollectionName.Contains("Model"))
                return CollectionName.Replace("Model", "");
            else
                return CollectionName;
        }
    }
}

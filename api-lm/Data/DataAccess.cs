using Common.Providers;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data
{
    public class DataAccess
    {
        public MongoProvider _Provider { get; private set; }
        public DataAccess()
        {
            _Provider = new MongoProvider();
        }

        private IMongoDatabase DataBase
        {
            get
            {
                return _Provider.GetApplicationDatabase(_Provider.InitializeDatabase(Database.ConnectionString));
            }
        }

        public IEnumerable<BsonDocument> GetFromCollection(string CollectionName, FilterDefinition<BsonDocument> Filter)
        {
            var collection = DataBase.GetCollection<BsonDocument>(CollectionName, null);
            var filteredCollection = collection.Find(Filter);


            using (var cursor = filteredCollection.ToCursor())
            {
                while (cursor.MoveNext())
                {
                    foreach (var current in cursor.Current)
                    {
                        yield return current;
                    }
                }
            }
        }

        public IEnumerable<BsonDocument> GetFromCollection(string CollectionName)
        {
            var filter = Builders<BsonDocument>.Filter.Where(a => true);
            return GetFromCollection(CollectionName, filter);
        }
    }
}

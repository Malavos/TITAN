using Common.Providers;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<BsonDocument>> GetFromCollectionAsync(string CollectionName, FilterDefinition<BsonDocument> Filter)
        {
            var collection = DataBase.GetCollection<BsonDocument>(CollectionName, null);
            var filteredCollection = collection.Find(Filter);


            using (var cursor = await filteredCollection.ToCursorAsync())
            {
                return await cursor.ToListAsync();
            }
        }

        public async Task<IEnumerable<BsonDocument>> GetFromCollectionAsync(string CollectionName)
        {
            var filter = Builders<BsonDocument>.Filter.Where(a => true);
            return await GetFromCollectionAsync(CollectionName, filter);
        }

        public void InsertInCollection(string CollectionName, BsonDocument Entidade)
        {
            var collection = DataBase.GetCollection<BsonDocument>(CollectionName, null);

            collection.InsertOne(Entidade);
        }

        public async void InsertInCollectionAsync(string CollectionName, BsonDocument Entidade)
        {
            var collection = DataBase.GetCollection<BsonDocument>(CollectionName, null);

            await collection.InsertOneAsync(Entidade);
        }

        public void InsertInCollection(string CollectionName, IEnumerable<BsonDocument> Entidades)
        {
            var collection = DataBase.GetCollection<BsonDocument>(CollectionName, null);

            collection.InsertMany(Entidades);
        }

        public async void InsertInCollectionAsync(string CollectionName, IEnumerable<BsonDocument> Entidades)
        {
            var collection = DataBase.GetCollection<BsonDocument>(CollectionName, null);

            await collection.InsertManyAsync(Entidades);
        }

        public void UpdateCollection(string CollectionName, BsonDocument Entidade, FilterDefinition<BsonDocument> Filter, UpdateDefinition<BsonDocument> Update)
        {
            var collection = DataBase.GetCollection<BsonDocument>(CollectionName);

            collection.UpdateOne(Filter, Update);
        }

        //public void UpdateCollection(string CollectionName, BsonDocument Entidade)
        //{
        //    var collection = DataBase.GetCollection<BsonDocument>(CollectionName);

        //    var Filter = new FilterDefinitionBuilder<BsonDocument>().Eq("_id",Entidade["_id"]);
        //    var Update = new UpdateDefinitionBuilder<BsonDocument>();


        //    collection.UpdateOne(Filter, Update);
        //}
    }
}

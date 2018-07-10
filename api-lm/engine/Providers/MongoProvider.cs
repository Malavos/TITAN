using Common.Constantes;
using Engine;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Common.Providers
{
    public static class Database
    {
        #region Properties
        /// <summary>
        /// Connection string for api to DB connection.
        /// </summary>
        public static string ConnectionString { get; set; } = String.Empty;
        /// <summary>
        /// Name of our collection to be used, for non-relational databases. 
        /// </summary>
        public static string CollectionName { get; set; } = String.Empty;
        /// <summary>
        /// TODO: Enum for the type of database. SQL? Oracle? Mongo? For now we only use MongoDB.
        /// </summary>
        public static int DataBase { get; set; } = 0;
        #endregion
    }

    public class MongoProvider : Base
    {
        #region Overrides
        public bool SetConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(Mensagens.Excecoes.ARGUMENTOS_NULOS);
            Database.ConnectionString = connectionString;
            return true;
        }

        public string GetConnectionString()
        {
            return Database.ConnectionString;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialize the MongoDatabase MongoClient object, using a connection string.
        /// </summary>
        /// <param name="connectionString">Connection string to be used. Can be found on MongoDB Atlas panel, on the "Connect" menu.</param>
        /// <returns></returns>
        public MongoClient InitializeDatabase(string connectionString)
        {
            var mongoClient = new MongoClient(connectionString);
            return mongoClient;
        }

        /// <summary>
        /// Get our applicationDatabase.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public IMongoDatabase GetApplicationDatabase(MongoClient client)
        {
            var database = client.GetDatabase("titan");
            if (database == null)
                throw new MongoException("");
            else
                return database;
        }

        #endregion
    }
}

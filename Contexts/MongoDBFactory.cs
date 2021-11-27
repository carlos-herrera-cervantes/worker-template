using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace WokerCloud.Contexts
{
    public class MongoDBFactory
    {
        public static MongoClient CreateClient(string connectionString)
            => new MongoClient(connectionString);
    }
}
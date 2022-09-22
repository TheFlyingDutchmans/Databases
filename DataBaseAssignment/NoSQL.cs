using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataBaseAssignment
{
    class NoSQL
    {
        private static MongoClientSettings settings;
        private static MongoClient client;
        private static IMongoDatabase database;

        public NoSQL()
        {
            settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            client = new MongoClient(settings);
            database = client.GetDatabase("netflix");
        }

        public void CreateEntry(int entries)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var collectionUser = database.GetCollection<BsonDocument>("user");
            var collectionProf = database.GetCollection<BsonDocument>("profile");
            var collectionSub = database.GetCollection<BsonDocument>("subscription");

            var userFilter = Builders<BsonDocument>.Filter.Gte("userID", 0);
            var userSort = Builders<BsonDocument>.Sort.Descending("userID");
            var userProjection = Builders<BsonDocument>.Projection.Include("userID").Exclude("_id");
            var lastUserIDDocument = collectionUser.Find(userFilter).Sort(userSort).Project(userProjection).First();
            var lastUserID = lastUserIDDocument.GetValue(0).AsInt32;

            var profFilter = Builders<BsonDocument>.Filter.Gte("profileID", 0);
            var profSort = Builders<BsonDocument>.Sort.Descending("profileID");
            var profProjection = Builders<BsonDocument>.Projection.Include("profileID").Exclude("_id");
            var lastProfIDDocument = collectionProf.Find(profFilter).Sort(profSort).Project(profProjection).First();
            var lastProfID = lastProfIDDocument.GetValue(0).AsInt32;

            var subFilter = Builders<BsonDocument>.Filter.Gte("subscriptionID", 0);
            var subSort = Builders<BsonDocument>.Sort.Descending("subscriptionID");
            var subProjection = Builders<BsonDocument>.Projection.Include("subscriptionID").Exclude("_id");
            var lastSubIDDocument = collectionSub.Find(subFilter).Sort(subSort).Project(subProjection).First();
            var lastSubID = lastSubIDDocument.GetValue(0).AsInt32;

            for (int i = 1; i < entries + 1; i++)
            {
                var newInsertedDocument = new BsonDocument
                {
                    {"profileID", 0},
                    {"profileName", "test" }
                };

                var newUserDocument = new BsonDocument
                {
                    {"userID", lastUserID++ },
                    {"firstName", "test" },
                    {"lastName", "test" },
                    {"profile", newInsertedDocument }
                };

                var newProfDocument = new BsonDocument
                {
                    {"profileID", lastProfID++ },
                    {"profileName", "test" },
                    {"userID", 1 }
                };

                var newSubDocument = new BsonDocument
                {
                    {"subscriptionID", lastSubID++ },
                    {"userID", 1 },
                    {"subcriptionType", 1 }
                };

                collectionUser.InsertOneAsync(newUserDocument);
                collectionProf.InsertOneAsync(newProfDocument);
                collectionSub.InsertOneAsync(newSubDocument);

                Console.WriteLine("Added user, profile and subscription with these IDs: " + lastUserID + " " + lastProfID + " " + lastSubID);
            }
            sw.Stop();
            Console.WriteLine(" Time elapsed: {0} ", sw.Elapsed);
        }
        
        public void ReadEntry(int entries)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var collectionUser = database.GetCollection<BsonDocument>("user");
            var collectionProf = database.GetCollection<BsonDocument>("profile");

            for (int i = 0; i < entries; i++)
            {
                var userFilter = Builders<BsonDocument>.Filter.Eq("userID", i);
                var userProjection = Builders<BsonDocument>.Projection.Include("userID").Include("firstName").Include("lastName").Exclude("_id");
                var userDocument = collectionUser.Find(userFilter).Project(userProjection).FirstOrDefault();

                var profFilter = Builders<BsonDocument>.Filter.Eq("userID", i);
                var profProjection = Builders<BsonDocument>.Projection.Include("profileID").Include("profileName").Exclude("_id");
                var profDocument = collectionProf.Find(profFilter).Project(profProjection).FirstOrDefault();

                Console.WriteLine("User: "+ userDocument);
                Console.WriteLine("Profiles: " + profDocument);
            }

            sw.Stop();
            Console.WriteLine(" Time elapsed: {0} ", sw.Elapsed);
        }

        public void UpdateEntry(int entries)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var collectionSub = database.GetCollection<BsonDocument>("subscription");
            var collectionProf = database.GetCollection<BsonDocument>("profile");

            for (int i = 0; i < entries; i++)
            {
                var update = Builders<BsonDocument>.Update.Set("userID", i + 1);

                var subFilter = Builders<BsonDocument>.Filter.Eq("userID", i);
                collectionSub.UpdateOne(subFilter, update);

                var profFilter = Builders<BsonDocument>.Filter.Eq("userID", i);
                collectionProf.UpdateOne(profFilter, update);

                Console.WriteLine("UserID: " + i);
            }

            sw.Stop();
            Console.WriteLine(" Time elapsed: {0} ", sw.Elapsed);
        }

        public void DeleteEntry(int entries)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var collectionUser = database.GetCollection<BsonDocument>("user");
            var collectionProf = database.GetCollection<BsonDocument>("profile");
            var collectionSub = database.GetCollection<BsonDocument>("subscription");

            var userFilter = Builders<BsonDocument>.Filter.Gte("userID", 0);
            var userSort = Builders<BsonDocument>.Sort.Descending("userID");
            var userProjection = Builders<BsonDocument>.Projection.Include("userID").Exclude("_id");
            var lastUserIDDocument = collectionUser.Find(userFilter).Sort(userSort).Project(userProjection).First();
            var lastUserID = lastUserIDDocument.GetValue(0).AsInt32;

            for (int i = lastUserID; i > lastUserID - entries; i--)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("userID", i);

                collectionUser.DeleteOne(filter);
                collectionProf.DeleteMany(filter);
                collectionSub.DeleteMany(filter);

                Console.WriteLine("Deleted userID: " + i);
            }
            sw.Stop();
            Console.WriteLine(" Time elapsed: {0} ", sw.Elapsed);
        }

        public void PrintDatabases()
        {
            var dbList = client.ListDatabases().ToList();

            foreach (var db in dbList)
            Console.WriteLine(db);
        }
    }
}
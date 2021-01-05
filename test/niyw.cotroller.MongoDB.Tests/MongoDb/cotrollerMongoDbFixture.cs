using System;
using Mongo2Go;

namespace niyw.cotroller.MongoDB
{
    public class cotrollerMongoDbFixture : IDisposable
    {
        private static readonly MongoDbRunner MongoDbRunner;
        public static readonly string ConnectionString;

        static cotrollerMongoDbFixture()
        {
            MongoDbRunner = MongoDbRunner.Start(singleNodeReplSet: true, singleNodeReplSetWaitTimeout: 20);
            ConnectionString = MongoDbRunner.ConnectionString;
        }

        public void Dispose()
        {
            MongoDbRunner?.Dispose();
        }
    }
}

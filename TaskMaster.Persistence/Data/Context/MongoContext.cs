using MongoDB.Driver;
using TaskMaster.Persistence.Data.Options;

namespace TaskMaster.Persistence.Data.Context;

public abstract class MongoContext<T>
{
    protected IMongoCollection<T> Collection { get; }
    private readonly IMongoOption _option;
    protected MongoContext(IMongoOption option)
    {
        _option = option;
        var mongoClient = new MongoClient(_option.ConnectionString);
        var database = mongoClient.GetDatabase(_option.DatabaseName);
        Collection = database.GetCollection<T>(typeof(T).Name);
    }

}

using MongoDB.Driver;
using System.Linq.Expressions;
using TaskMaster.Core.Interfaces;
using TaskMaster.Persistence.Data.Options;

namespace TaskMaster.Persistence.Data.Context;



public abstract class MongoContext<T> : IMongoContext<T>
    where T : IModel
{
    /// <summary>
    /// Gets the MongoDB collection for the data type T.
    /// </summary>
    protected IMongoCollection<T> Collection { get; }

    /// <summary>
    /// The IMongoOption object contains the connection string and database name to connect to.
    /// </summary>
    private readonly IMongoOption _option;

    /// <summary>
    /// Initializes a new instance of the <see cref="MongoContext{T}"/> class.
    /// </summary>
    /// <param name="option">The IMongoOption object containing the connection information.</param>
    protected MongoContext(IMongoOption option)
    {
        _option = option;
        var mongoClient = new MongoClient(_option.ConnectionString);
        var database = mongoClient.GetDatabase(_option.DatabaseName);
        Collection = database.GetCollection<T>(typeof(T).Name);
    }


    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default(CancellationToken))
    {
        return filter is not null ? await Collection.Find<T>(filter: filter).ToListAsync(cancellationToken)
                              : await Collection.Find<T>(x => true).ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(T document, CancellationToken cancellationToken = default(CancellationToken))
    {
        await Collection.InsertOneAsync(document: document, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(T document, CancellationToken cancellationToken = default(CancellationToken))
    {
        await Collection.ReplaceOneAsync(filter: x => x.Id == document.Id, replacement: document, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
    {
        await Collection.FindOneAndDeleteAsync(filter: x => x.Id == id, cancellationToken: cancellationToken);
    }
}




using MongoDB.Driver;
using TaskMaster.Persistence.Data.Options;

namespace TaskMaster.Persistence.Data.Context;


/// <summary>
/// The MongoContext class is designed to provide access to a MongoDB collection for a given data type T. It serves as a base class that can be inherited by other classes that need MongoDB access.
/// </summary>
/// <typeparam name="T">The type of data that will be stored in the MongoDB collection.</typeparam>
public abstract class MongoContext<T>
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
}



/*
The MongoContext class is designed to provide access to a MongoDB collection for a given data type T. It serves as a base class that can be inherited by other classes that need MongoDB access.

The class takes in an IMongoOption object as input, which contains the connection string and database name to connect to.

In the constructor, it uses this input to create a MongoClient and get a reference to the desired database. It then calls the GetCollection method to get the MongoDB collection for the data type T, based on its name.

The Collection property returns this MongoDB collection object, allowing consumer classes to perform CRUD operations on the data.

So in summary, MongoContext sets up the MongoDB client and handles connecting to the database. Subclasses can then use the Collection property to start querying and manipulating the data they need. This abstraction separates the database connection logic from the data access logic for clean separation of concerns.

The main purpose is to reduce duplicate connection logic and setup needed across classes that interact with MongoDB. By inheriting from MongoContext, these classes get the Collection property ready to go without having to handle the MongoDB client initialization each time.

*/
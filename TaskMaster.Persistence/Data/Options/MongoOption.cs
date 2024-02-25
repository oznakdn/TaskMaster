namespace TaskMaster.Persistence.Data.Options;

public class MongoOption : IMongoOption
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}

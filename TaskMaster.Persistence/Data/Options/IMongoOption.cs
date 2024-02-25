namespace TaskMaster.Persistence.Data.Options;

public interface IMongoOption
{
     string ConnectionString { get; set; }
     string DatabaseName { get; set; }

}

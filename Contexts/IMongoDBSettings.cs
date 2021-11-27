namespace WokerCloud.Contexts
{
    public interface IMongoDBSettings
    {
         string ConnectionString { get; set; }
         string Database { get; set; }
    }
}
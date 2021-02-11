namespace ConsoleApi.Models{

    public interface IConsoleDatabaseSettings{
        string ConsolesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class ConsoleDatabaseSettings : IConsoleDatabaseSettings{
        public string ConsolesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
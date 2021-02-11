namespace GameApi.Models{

    public interface IGameDatabaseSettings{
        string GamesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class GameDatabaseSettings : IGameDatabaseSettings{
        public string GamesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
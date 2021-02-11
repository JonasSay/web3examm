using MongoDB.Driver;
using ConsoleApi.Models;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApi.Services{


    public class ConsolesService {


        private readonly IMongoCollection<Console> _consoles;

        public ConsolesService(IConsoleDatabaseSettings settings){
            var client = new MongoClient( settings.ConnectionString );
            var database = client.GetDatabase ( settings.DatabaseName );

            _consoles = database.GetCollection<Console>( settings.ConsolesCollectionName );
        }

        public List<Console> Get(){
            return _consoles.Find( console => true ).ToList();
        }

        public Console Get(string id) {
            return _consoles.Find( console => console.Id == id ).SingleOrDefault();
        }

        public Console Create(Console console) {
            _consoles.InsertOne(console);
            return console;
        }

        public void Update(string id, Console consoleIn) {
            _consoles.ReplaceOne( console => console.Id == id, consoleIn);
        }

        public void Remove(string id){
            _consoles.DeleteOne( console => console.Id == id);
        }

    }
}
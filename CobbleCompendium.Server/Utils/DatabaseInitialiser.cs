using Microsoft.Data.Sqlite;

namespace CobbleCompendium.Server.Utils;

public class DatabaseInitialiser{

    public DatabaseInitialiser(){
        using (var connection = new SqliteConnection("Data Source = ../Database/CobbleCompendium.db")){
            connection.Open();

        }
    }

}

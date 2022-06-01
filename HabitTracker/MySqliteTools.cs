using System;
using Microsoft.Data.Sqlite;

public class MySqliteTools
{

	static string connectionString = @"Data Source=habit-tracker.db";

	public void CreateDatabase()
	{
		/* Creates a Sqlite connection passing the connectionString
		 * as an argument.  This will create the database. */
		using (var connection = new SqliteConnection(connectionString))
        {
			// This is the command to send to the DB
			using (var tableCmd = connection.CreateCommand())
            {
				connection.Open();

				// The SQL syntax command is a property of tableCmd
				tableCmd.CommandText =
					@"CREATE TABLE IF NOT EXISTS yourHabit (
						Id INTEGER PRIMARY KEY AUTOINCREMENT,
						Date TEXT,
						Quantity INTEGER
						)";

				// Executing the command, which is not a query,
				// not fetching data
				tableCmd.ExecuteNonQuery();
            }
        }
	}
}

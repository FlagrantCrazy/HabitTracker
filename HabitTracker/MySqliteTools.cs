using System;
using Microsoft.Data.Sqlite;

public class MySqliteTools
{

	static string connectionString = @"Data Source=habit-tracker.db";

	public static void CreateDatabase()
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
					@"CREATE TABLE IF NOT EXISTS CodingHours (
					Id INTEGER PRIMARY KEY AUTOINCREMENT,
					Date TEXT,
					Quantity INTEGER
					)";

				// Executing the command, which is not a query,
				// not fetching data
				tableCmd.ExecuteNonQuery();
			}
		}
		// Note 'using' closes the connection automatically like with ... as ...
	}

	public static void CreateNewRecord(DateOnly date, int hoursCoded)
	{
		using (var connection = new SqliteConnection(connectionString))
		{
			// This is the command to send to the DB
			using (var tableCmd = connection.CreateCommand())
			{
				connection.Open();

				// The SQL syntax command is a property of tableCmd
				tableCmd.CommandText =
					$@"INSERT INTO CodingHours (Date, Quantity)
					VALUES ('{date.ToString()}', {hoursCoded});";

				// Executing the command, which is not a query,
				// not fetching data
				tableCmd.ExecuteNonQuery();
			}
		}
		// Note 'using' closes the connection automatically like with ... 
	}

	public static List<string[]> ReadAllRecords()
	{
		using (SqliteConnection connection = new SqliteConnection(connectionString))
		{
			// This is the command to send to the DB
			using (SqliteCommand tableCmd = connection.CreateCommand())
			{
				connection.Open();

				// The SQL syntax command is a property of tableCmd
				tableCmd.CommandText =
					@"SELECT * FROM CodingHours;";

				// Executing the command and getting a data reader
				SqliteDataReader reader = tableCmd.ExecuteReader();

				// Initialise an empty List to store the records in
				List<string[]> records = new List<string[]>();

				// Advance through each record in the reader and add the record to the list
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						string[] record = new string[3] { reader.GetString(0), reader.GetString(1), reader.GetString(2) };
						records.Add(record);
					}
				}
				return records;
			}
		}
	}

	public static void UpdateExistingRecord(int id, DateOnly date, int hoursCoded)
	{
		using (SqliteConnection connection = new SqliteConnection(connectionString))
		{
			// This is the command to send to the DB
			using (SqliteCommand tableCmd = connection.CreateCommand())
			{
				connection.Open();

				// The SQL syntax command is a property of tableCmd
				tableCmd.CommandText =
					$@"UPDATE CodingHours
					   SET Date = '{date.ToString()}', Quantity = {hoursCoded}
					   WHERE Id = {id}";

				// Executing the command and getting a data reader
				tableCmd.ExecuteNonQuery();

			}
		}
	} //quietly does nothing if target id doesn't exist

	public static void DeleteRecord(int id)
	{
		using (SqliteConnection connection = new SqliteConnection(connectionString))
		{
			// This is the command to send to the DB
			using (SqliteCommand tableCmd = connection.CreateCommand())
			{
				connection.Open();

				// The SQL syntax command is a property of tableCmd
				tableCmd.CommandText =
					$@"DELETE FROM CodingHours WHERE Id = {id}";

				// Executing the command and getting a data reader
				tableCmd.ExecuteNonQuery();

			}
		}
	}
}
using Microsoft.Data.Sqlite;

namespace HabitTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqliteTools.CreateDatabase();
        }
    }
}

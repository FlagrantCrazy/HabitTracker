namespace HabitTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqliteTools.CreateDatabase();

            DateOnly mydate = new DateOnly(1994, 11, 2);

            MySqliteTools.UpdateToDatabase(mydate, 1);
        }
    }
}

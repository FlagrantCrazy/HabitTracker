using Microsoft.Data.Sqlite;

namespace HabitTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqliteTools.CreateDatabase();

            string input;
            do
            {
                MyMenuTools.PrintOptions();
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Console.WriteLine("Exiting... bye!");
                        break;

                    case "1":
                        MyMenuTools.AddNewRecord();
                        break;

                    case "2":
                        MyMenuTools.ViewRecords();
                        break;

                    case "3":
                        MyMenuTools.UpdateRecord();
                        break;

                    case "4":
                        MyMenuTools.DeleteRecord();
                        break;

                    default:
                        Console.WriteLine($"\n'{input}' is not a valid option");
                        break;
                }
            } while (input != "0");

        }
    }
}

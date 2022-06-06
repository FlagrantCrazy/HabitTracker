using System;
using System.Globalization;


namespace HabitTracker
{
    public class MyUserInputTools
    {
        
        public static object[] GetNewRecord()
        {
            DateOnly date = DateOnly.MinValue;
            int hoursCoded = int.MaxValue;
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "d";

            Console.WriteLine("Enter a new date in the format DD/MM/YYYY or enter 'today'");
            while (date == DateOnly.MinValue)
                try
                {
                    string input = Console.ReadLine();
                    if (input == "today")
                    {
                        date = DateOnly.FromDateTime(DateTime.Now);
                        break;
                    }

                    date = DateOnly.ParseExact(input, format, provider);
                }

                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid date in the format DD/MM/YYYY or 'today'");
                }

            Console.WriteLine("Enter the number of hours coded as a non-negative integer. Must be less than or equal to 24\nRound down, or code longer next time!");
            while (hoursCoded > 24 | hoursCoded < 0)
                try
                {
                    hoursCoded = int.Parse(Console.ReadLine());
                    if (hoursCoded > 24) { throw new FormatException(); }
                    if (hoursCoded < 0 ) { throw new FormatException(); }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Must be entered as a non-negative integer and must be less than or equal to 24");
                }


            return new object[] { date, hoursCoded };

        }

        public static bool RecordIdExists(int idToCheck)
        {
            List<string[]> records = MySqliteTools.ReadAllRecords();
            foreach (string[] record in records)
            {
                if (int.Parse(record[0]) == idToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public static int GetExistingId()
        {
            int id = -1;
            while (id <= 0 | !RecordIdExists(id))
            {
                try
                {
                    id = int.Parse(Console.ReadLine());
                    if (!RecordIdExists(id))
                    {
                        Console.WriteLine("That record ID doesn't exist.  Check the list again and enter another ID");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Record IDs must be an integer");
                }
            }

            return id;
        }

        

    }
}

using System;

namespace HabitTracker
{
    public class MyMenuTools
    {
        public static void PrintOptions()
        {
            Console.WriteLine("\nHabitTracker Main Menu\n--------\nSelect an option:");
            Console.WriteLine("0 : exit");
            Console.WriteLine("1 : add a new habit record");
            Console.WriteLine("2 : view your existing habit records");
            Console.WriteLine("3 : update an existing habit record");
            Console.WriteLine("4 : delete an existing habit record");
        }

        public static void AddNewRecord()
        {
            object[] newRecord = MyUserInputTools.GetNewRecord();
            MySqliteTools.CreateNewRecord(newRecord);
            Console.WriteLine($"\nCreated a new record:\n--------\nDate: {newRecord[0]}\nHours Coded: {newRecord[1]}");
        }

        public static bool ViewRecords() // returns false if there are no records
        {
            List<string[]> records = MySqliteTools.ReadAllRecords();
            if (records.Count > 0)
            {
                Console.WriteLine("\nHere are all your records:");
                foreach (string[] record in records)
                {
                    Console.WriteLine($"--------\nID: {record[0]}\nDate: {record[1]}\nHours Coded: {record[2]}");
                }
                return true;
            }
            else
            {
                Console.WriteLine("\nThere are no records!");
                return false;
            }
        }

        public static void UpdateRecord()
        {
            if (ViewRecords())
            {
                Console.WriteLine("\nEnter the ID of the record you wish to update");
                int idToUpdate = MyUserInputTools.GetExistingId();
                object[] newRecord = MyUserInputTools.GetNewRecord();
                MySqliteTools.UpdateExistingRecord(idToUpdate, newRecord);
                Console.WriteLine($"\nUpdated record to:\n--------\nID: {idToUpdate}\nDate: {newRecord[0]}\nHours Coded: {newRecord[1]}");
            }
        }

        public static void DeleteRecord()
        {
            if (ViewRecords())
            {
                Console.WriteLine("\nEnter the ID of the record you wish to delete");
                int idToDelete = MyUserInputTools.GetExistingId();
                MySqliteTools.DeleteRecord(idToDelete);
                Console.WriteLine($"\nDeleted record with ID: {idToDelete}");
            }
        }
        
    }
}

using System;
using System.Collections.Generic;

namespace LeftToDo
{
    public class ArchiveList : List
    {
        public List<Task> listOfArchive = new List<Task>();

        public override void AddTaskToList(Task typeOfArchivedTaskToAdd)
        {
            listOfArchive.Add(typeOfArchivedTaskToAdd);
        }

        public override void RemoveTaskFromList(int index)
        {
            listOfArchive.RemoveAt(index);
        }

        public override void DisplayListContent()
        {
            foreach (Task archivedTask in listOfArchive)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Uppgift: {archivedTask.activityName} Utförd {0}", Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
        }
    }
}
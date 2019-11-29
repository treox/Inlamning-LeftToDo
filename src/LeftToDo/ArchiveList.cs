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
    }
}
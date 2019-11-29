namespace LeftToDo
{
    public abstract class List
    {
        public abstract void AddTaskToList(Task typeOfTask);

        public abstract void RemoveTaskFromList(int index);

        public abstract void DisplayListContent();
    }
}
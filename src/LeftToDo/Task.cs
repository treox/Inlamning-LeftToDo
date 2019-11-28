namespace LeftToDo
{
    public class Task
    {
        public string activityName { get; protected set;}
        public string activityDueDate { get; protected set; }
        public bool done { get; set; }
    }
}
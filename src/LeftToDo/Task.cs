namespace LeftToDo
{
    public class Task
    {
        public string activityName { get; private set;}

        public string activityDueDate { get; private set;}
        public bool done { get; set;}

        public Task(string activityName, string activityDueDate, bool done)
        {
            this.activityName = activityName;
            this.activityDueDate = activityDueDate;
            this.done = done;
        }
    }
}
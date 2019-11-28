namespace LeftToDo
{
    public class TaskWithDueDate : Task
    {
        // public string activityName { get; private set;}

        // public string activityDueDate { get; set;}
        // public bool done { get; set;}

        public TaskWithDueDate(string activityName, string activityDueDate, bool done)
        {
            this.activityName = activityName;
            this.activityDueDate = activityDueDate;
            this.done = done;
        }
    }
}
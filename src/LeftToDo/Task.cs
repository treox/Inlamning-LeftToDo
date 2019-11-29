namespace LeftToDo
{
    public abstract class Task
    {
        public string activityName { get; protected set;}
        public string activityDueDate { get; protected set; }
        public bool done { get; set; }

        public Task(string activityName, string activityDueDate, bool done)
        {
            this.activityName = activityName;
            this.activityDueDate = activityDueDate;
            this.done = done;
        }
    }
}
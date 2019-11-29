using System.Collections.Generic;

namespace LeftToDo
{
    public class TaskWithChecklist : Task
    {
        List<string> checklist;

        public TaskWithChecklist(string activityName, string activityDueDate, bool done) : base(activityName, activityDueDate, done)
        {
            this.activityName = activityName;
            this.activityDueDate = activityDueDate;
            this.done = done;
            checklist = new List<string>();
        }
    }
}
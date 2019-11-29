using Xunit;

namespace LeftToDo.Tests
{
    public class LeftToDoTests
    {
        [Fact]
        public void AddATaskToList()
        {
            // arrange
            TaskList taskList = new TaskList();
            bool throwError;

            // act
            try
            {
                taskList.AddTaskToList(new TaskWithDueDate("Testtask 1", "2019.11.29", false));
                throwError = false;
            }
            catch
            {
                throwError = true;
            }

            // assert
            Assert.True(!throwError);
        }

        [Fact]
        public void MarkATaskAsDone()
        {
            // arrange
            TaskList taskList = new TaskList();
            
            // act
            taskList.AddTaskToList(new TaskWithDueDate("Testtask 1", "2019.11.29", false));
            taskList.AddTaskToList(new TaskWithDueDate("Testtask 2", "2019.11.29", false));
            taskList.listOfTasks[1].done = true;

            // assert
            Assert.True(!taskList.listOfTasks[0].done);
            Assert.True(taskList.listOfTasks[1].done);

        }

        [Fact]
        public void ArchiveFinishedTasks()
        {
            // arrange
            TaskList taskList = new TaskList();
            ArchiveList archiveList = new ArchiveList();
            
            // act
            taskList.AddTaskToList(new TaskWithDueDate("Testtask 1", "2019.11.29", true));
            taskList.AddTaskToList(new TaskWithDueDate("Testtask 2", "2019.11.29", true));

            int count = 0;
            foreach (Task task in taskList.listOfTasks)
            {
                count += 1;
                if (task.done == true)
                {
                    archiveList.AddTaskToList(new TaskWithDueDate(task.activityName, task.activityDueDate, task.done));
                }
            }

            startLoop:
            int atIndex = -1;
            foreach (Task task in taskList.listOfTasks)
            {
                atIndex += 1;
                if (task.done == true)
                {
                    taskList.RemoveTaskFromList(atIndex);
                    goto startLoop;
                }
            }

            // assert
            Assert.Equal(2, archiveList.listOfArchive.Count);
            Assert.Empty(taskList.listOfTasks);
        } 
    }
}

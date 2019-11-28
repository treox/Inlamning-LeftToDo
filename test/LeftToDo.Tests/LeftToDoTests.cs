using System;
using System.Collections.Generic;
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
                taskList.listOfTasks.Add(new Task("Testtask 1", "2019.11.29", false));
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
            taskList.listOfTasks.Add(new Task("Testtask 1", "2019.11.29", false));
            taskList.listOfTasks.Add(new Task("Testtask 2", "2019.11.29", false));
            taskList.listOfTasks[1].done = true;

            // assert
            Assert.True(!taskList.listOfTasks[0].done);
            Assert.True(taskList.listOfTasks[1].done);

        }
    }
}

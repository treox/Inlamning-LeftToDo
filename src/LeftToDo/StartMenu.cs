using System;

namespace LeftToDo
{

    class StartMenu
    {

        private ConsoleKeyInfo startMenuChoice;

        TaskList taskList = new TaskList();
        ArchiveList archiveList = new ArchiveList(); 

        public void PresentStartMenu()
        {
            start:
            Console.WriteLine();
            Console.WriteLine("[1] Lägg till aktivitet");
            Console.WriteLine("[2] Visa aktivitetslista");
            Console.WriteLine("[3] Arkivera uppgifter");
            Console.WriteLine("[4] Visa arkiv");
            Console.WriteLine("[5] Avsluta");
            Console.WriteLine("Välj:");

            startMenuChoice = Console.ReadKey();

            switch(startMenuChoice.Key)
            {
                case ConsoleKey.D1:
                    taskList.CreateTask();
                    goto start;
                case ConsoleKey.D2:
                    int count = 0;
                    foreach(Task task in taskList.listOfTasks)
                    {
                        count += 1;
                        if (task.done == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Aktivitet {count}: {task.activityName} Done {0}", Console.ForegroundColor);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.WriteLine($"Aktivitet {count}: {task.activityName} Deadline: {task.activityDueDate}");
                        }
                    }
                    taskList.ChangeStateOfTask();
                    goto start;
                case ConsoleKey.D3:
                    int index = 0;
                    foreach (Task task in taskList.listOfTasks)
                    {
                        index += 1;
                        if (task.done == true)
                        {
                            Console.WriteLine(task.activityName);
                            archiveList.listOfArchive.Add(new Task(task.activityName, task.activityDueDate, task.done));
                        }
                        else if(task.done == false)
                        {
                            continue;
                        }
                    }

                    int atIndex = -1;
                    startLoop:
                    foreach (Task task in taskList.listOfTasks)
                    {
                        atIndex += 1;
                        if (task.done == true)
                        {
                            Console.WriteLine(atIndex);
                            taskList.listOfTasks.RemoveAt(atIndex);
                            goto startLoop;
                        }
                        else
                        {
                            continue;
                        }
                    }                    
                    goto start;
                case ConsoleKey.D4:
                    count = 0;
                    foreach (Task archivedTask in archiveList.listOfArchive)
                    {
                        count += 1;
                        Console.WriteLine($"Aktivitet {count}: {archivedTask.activityName} Done");
                    }
                    goto start;
                case ConsoleKey.D5:
                    return;
                default:
                    goto start;
            }
        }
    }
}
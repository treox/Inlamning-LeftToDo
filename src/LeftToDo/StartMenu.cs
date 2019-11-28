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
            Console.WriteLine("[1] Lägg till uppgift med deadline");
            Console.WriteLine("[2] Lägg till uppgift med checklista");
            Console.WriteLine("[3] Visa lista på uppgifter");
            Console.WriteLine("[4] Arkivera uppgifter");
            Console.WriteLine("[5] Visa arkiv");
            Console.WriteLine("[6] Avsluta");
            Console.WriteLine("Välj:");

            startMenuChoice = Console.ReadKey();

            switch(startMenuChoice.Key)
            {
                case ConsoleKey.D1:
                    taskList.CreateTaskWithDueDate();
                    goto start;

                case ConsoleKey.D2:
                    taskList.CreateTaskWithChecklist();
                    goto start;

                case ConsoleKey.D3:
                    int count = 0;
                    foreach(Task task in taskList.listOfTasks)
                    {
                        count += 1;
                        if (task.done == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Uppgift [{count}]: {task.activityName} Utförd {0}", Console.ForegroundColor);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            if (task.activityDueDate != null)
                            {
                                Console.WriteLine($"Uppgift [{count}]: {task.activityName} Deadline: {task.activityDueDate}");
                            }
                            else
                            {
                                Console.WriteLine($"Uppgift [{count}]: {task.activityName}");
                            }
                        }
                    }
                    taskList.ChangeStateOfTask();
                    goto start;

                case ConsoleKey.D4:
                    int index = 0;
                    foreach (Task task in taskList.listOfTasks)
                    {
                        index += 1;
                        if (task.done == true)
                        {
                            Console.WriteLine(task.activityName);
                            archiveList.listOfArchive.Add(new TaskWithDueDate(task.activityName, task.activityDueDate, task.done));
                        }
                        else if(task.done == false)
                        {
                            continue;
                        }
                    }

                    startLoop:
                    int atIndex = -1;
                    foreach (Task task in taskList.listOfTasks)
                    {
                        atIndex += 1;
                        if (task.done == true)
                        {
                                Console.WriteLine(atIndex);
                                taskList.listOfTasks.RemoveAt(atIndex);
                                goto startLoop;
                        }
                        else if (task.done == false)
                        {
                           continue;     
                        }
                    }                    
                    goto start;

                case ConsoleKey.D5:
                    foreach (Task archivedTask in archiveList.listOfArchive)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Uppgift: {archivedTask.activityName} Utförd {0}", Console.ForegroundColor);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    goto start;

                case ConsoleKey.D6:
                    return;
                default:
                    goto start;
            }
        }
    }
}
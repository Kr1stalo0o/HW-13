using System;
using System.Collections.Generic;

class TodoApp
{
    private List<(string Task, bool IsCompleted)> todoList = new List<(string Task, bool IsCompleted)>();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\nTo-Do List Application");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Show All Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1": AddTask(); break;
                case "2": ShowTasks(); break;
                case "3": MarkTaskAsCompleted(); break;
                case "4": DeleteTask(); break;
                case "5": Console.WriteLine("Goodbye!"); return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    private void AddTask()
    {
        Console.Write("Enter the task: ");
        string task = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(task))
        {
            todoList.Add((task, false));
            Console.WriteLine("Task added.");
        }
        else
        {
            Console.WriteLine("Task cannot be empty.");
        }
    }

    private void ShowTasks()
    {
        if (todoList.Count == 0)
        {
            Console.WriteLine("No tasks in the list.");
        }
        else
        {
            Console.WriteLine("\nTo-Do List:");
            for (int i = 0; i < todoList.Count; i++)
            {
                var (task, isCompleted) = todoList[i];
                Console.WriteLine($"{i + 1}. {task} {(isCompleted ? "[Completed]" : "[Pending]")}");
            }
        }
    }

    private void MarkTaskAsCompleted()
    {
        ShowTasks();
        if (todoList.Count > 0)
        {
            Console.Write("Enter task number to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0 && number <= todoList.Count)
            {
                todoList[number - 1] = (todoList[number - 1].Task, true);
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }
    }

    private void DeleteTask()
    {
        ShowTasks();
        if (todoList.Count > 0)
        {
            Console.Write("Enter task number to delete: ");
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0 && number <= todoList.Count)
            {
                todoList.RemoveAt(number - 1);
                Console.WriteLine("Task deleted.");
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }
    }

    static void Main(string[] args)
    {
        new TodoApp().Run();
    }
}

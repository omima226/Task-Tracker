namespace Task_Tracker
{
    internal class Program
    {
        private static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To My Task Tracker !");
            Console.WriteLine("--------------------------------------------------------");

            while (true)
            {
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View All Tasks");
                Console.WriteLine("3. Mark Task Complete");
                Console.WriteLine("4. Remove Task");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Your Choice Please (1-5): ");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        ViewAllTasks();
                        break;

                    case "3":
                        MarkComplete();
                        break;

                    case "4":
                        DeleteTask();
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter a number from 1 to 5.");
                        break;
                }
                Console.WriteLine("-----------------------------------------------------");
            }
        
    }
        private static void AddTask()
        {
            Console.Write("Enter Task Description: ");
            string taskDescription = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(taskDescription))
            {
                Console.WriteLine("Task description cannot be empty.");
                return;
            }

            tasks.Add(new Task { Description = taskDescription, IsCompleted = false });
            Console.WriteLine("Task Added");
        }


        private static void ViewAllTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("Your Task List:");
            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].IsCompleted ? "<<COMPLETED>>" : "<<PENDING>>";
                Console.WriteLine($"{i + 1}. {tasks[i].Description} - {status}");
            }
        }

        private static void MarkComplete()
        {
            Console.Write("Enter Task Number to Mark Complete: ");
            if (int.TryParse(Console.ReadLine(), out int taskId) && taskId > 0 && taskId <= tasks.Count)
            {
                tasks[taskId - 1].IsCompleted = true;
                Console.WriteLine("Task marked as complete.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
        private static void DeleteTask()
        {
            Console.Write("Enter Task Number to Delete: ");
            if (int.TryParse(Console.ReadLine(), out int taskId) && taskId > 0 && taskId <= tasks.Count)
            {
                tasks.RemoveAt(taskId - 1);
                Console.WriteLine("Task deleted.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
    }
}

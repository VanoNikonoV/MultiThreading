namespace MultiThreading
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Начало метода {Thread.CurrentThread.Name = "Main"}, ID Main: {Thread.CurrentThread.ManagedThreadId}");

            var task1 = FirstMetodAsync();
            var task2 = SecondMetodAsync();
            var task3 = FirdMetodAsync();

            var tasks = new List<Task> { task1, task2, task3 };

            while (tasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(tasks);
                if (finishedTask == task1)
                {
                    Console.WriteLine("\tПервая задача закончена!");
                }
                else if (finishedTask == task2)
                {
                    Console.WriteLine("\tВторая задача закончена!");
                }
                else if (finishedTask == task3)
                {
                    Console.WriteLine("\tТретья задача закончена!");
                }
                await finishedTask;
                tasks.Remove(finishedTask);
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine($"Вот и сказке конец");

            Console.ReadKey();

            static async Task FirstMetodAsync()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ID потока первой задачи: {Thread.CurrentThread.GetHashCode()}, имя потока: {Thread.CurrentThread.Name = "Первый"}");
                await Task.Delay(3000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ID потока первой задачи: {Thread.CurrentThread.GetHashCode()}, имя потока: {Thread.CurrentThread.Name = "Первый"}");
                await Task.Delay(1500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ID потока первой задачи: {Thread.CurrentThread.GetHashCode()}, имя потока: {Thread.CurrentThread.Name = "Первый"}");
                return;
            }

            static async Task SecondMetodAsync()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"ID потока второй задачи: {Thread.CurrentThread.GetHashCode()}, имя потока: {Thread.CurrentThread.Name = "Второй"}");
                await Task.Delay(2000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"ID потока второй задачи: {Thread.CurrentThread.GetHashCode()}, имя потока: {Thread.CurrentThread.Name = "Второй"}");
                await Task.Delay(700);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"ID потока второй задачи: {Thread.CurrentThread.GetHashCode()}, имя потока: {Thread.CurrentThread.Name = "Второй"}");
                return;
            }

            static async Task FirdMetodAsync()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"ID потока третьей задачи: {Thread.CurrentThread.GetHashCode()}, имя потока: {Thread.CurrentThread.Name = "Третьий"}");
                await Task.Delay(1700);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"ID потока третьей задачи: {Thread.CurrentThread.GetHashCode()}, имя потока: {Thread.CurrentThread.Name = "Третьий"}");
                await Task.Delay(4000);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"ID потока третьей задачи: {Thread.CurrentThread.GetHashCode()}, имя потока: {Thread.CurrentThread.Name = "Третьий"}");
                return;
            }
        }
    }
}
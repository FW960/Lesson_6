using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
namespace Lesson_6
{
    internal class Program
    {
        static void Main()
        {
            Process[] procesesses = Process.GetProcesses();

            MainMenu(procesesses);
        }
        static void MainMenu(Process[] processes)
        {

            Console.WriteLine("Task Manager");
            Console.WriteLine();

            Console.WriteLine("Для выхода введите 0:");

            Console.WriteLine("Для очистки консоли введите 1:");

            Console.WriteLine("Для обновления количества активных процессов введите 2:");

            Console.WriteLine("Для приостановления процесса по имени введите 3:");

            Console.WriteLine("Для приостановления процесса по идентификатору введите 4:");

            String userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "0": int Exit = Convert.ToInt32(userChoice); Environment.Exit(Exit); break;

                case "1": Console.Clear(); MainMenu(processes); return;

                case "2": processes = ProcessesRecalculation(); MainMenu(processes); return;

                case "3": ProcesseDeletionKnowingTheName(processes); return;

                case "4": ProcessesDeletionKnowingTheId(processes); return;

                default: Console.WriteLine("Введите число из предложенного."); Console.ReadLine(); MainMenu(processes); return;

            }
        }

        static Process[] ProcessesRecalculation()
        {
            Process[] processes = Process.GetProcesses();

            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine($"{processes[i].Id}\t{processes[i].ProcessName}");
            }
            return processes;

        }
        static void ProcesseDeletionKnowingTheName(Process[] allOfProcesses)
        {
            Console.WriteLine("Введите название процесса:");

            string processName = Console.ReadLine();

            for (int i = 0; i < allOfProcesses.Length; i++)
            {

                if (processName == allOfProcesses[i].ProcessName)
                {
                    allOfProcesses[i].Kill();

                    Console.WriteLine($"Процесс {allOfProcesses[i].ProcessName} приостановлен.");
                    Console.WriteLine();

                    Console.WriteLine("Хотите продолжить?");
                    Console.WriteLine();

                    UserChoiceAfterNameDeletionProcesses(allOfProcesses);


                }
            }
            Console.WriteLine("Введите корректное название процесса.");
            Console.WriteLine();

            UserChoiceAfterNameDeletionProcesses(allOfProcesses);
        }

        static void UserChoiceAfterNameDeletionProcesses(Process[] allOfProcesses)
        {
            Console.WriteLine("Для возврата в главное меню нажмите 0.");

            Console.WriteLine("Для того, чтобы продолжить выбор названия процесса нажмите 1");


            string anotherUserChoide = Console.ReadLine();

            switch (anotherUserChoide)
            {
                case "0": MainMenu(allOfProcesses); return;

                case "1": ProcesseDeletionKnowingTheName(allOfProcesses); return;

                default: Console.WriteLine("Приложению не удалось определить введенное число. Идет перенаправление в меню."); MainMenu(allOfProcesses); return;

            }
        }
        static void ProcessesDeletionKnowingTheId(Process[] allOfProcesses)
        {
            Console.WriteLine("Введите ID процесса: ");

            try
            {
                int userIDChoice = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < allOfProcesses.Length; i++)
                {
                    if (allOfProcesses[i].Id == userIDChoice)
                    {
                        allOfProcesses[i].Kill();

                        Console.WriteLine($"Процесс {allOfProcesses[i].ProcessName} приостановлен");
                        Console.WriteLine();

                        Console.WriteLine("Хотите продолжить?");
                        Console.WriteLine();

                        UserChoiceAfterIdDeletionProcesses(allOfProcesses);

                    }
                }
                Console.WriteLine($"По указанному ID: {userIDChoice} не было найдено ни одного из процесса.");
                Console.WriteLine();

                UserChoiceAfterIdDeletionProcesses(allOfProcesses);

            }
            catch (Exception)
            {
                Console.WriteLine("Введите ID в корректном формате.");
                Console.WriteLine();

                UserChoiceAfterIdDeletionProcesses(allOfProcesses);
            }

        }
        static void UserChoiceAfterIdDeletionProcesses(Process[] allOfProcesses)
        {

            Console.WriteLine("Для возврата в главное меню нажмите 0.");

            Console.WriteLine("Для того, чтобы продолжить выбор ID процесса нажмите 1");

            string userFirstChoice = Console.ReadLine();

            switch (userFirstChoice)
            {
                case "0": MainMenu(allOfProcesses); return;

                case "1": ProcessesDeletionKnowingTheId(allOfProcesses); return;

                default: Console.WriteLine("Приложению не удалось определить введенное число. Идет перенаправление в меню."); MainMenu(allOfProcesses); return;
            }
        }
    }

}

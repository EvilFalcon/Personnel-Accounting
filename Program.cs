using System;
using System.Collections.Generic;

namespace Personnel_Accounting
{
    class Program
    {
        static void Main()
        {
            const string AddDossierCommand = "1";
            const string CommandToDisplayAllDossiers = "2";
            const string DeleteDossierCommand = "3";
            const string LastNameSearchCommand = "4";
            const string ExitCommand = "5";

            List<string> positions = new List<string>();
            List<string> fullNames = new List<string>();
            bool isExitProgram = true;

            while (isExitProgram)
            {
                Console.Clear();
                Console.WriteLine($"{AddDossierCommand}<---Добавить досье");
                Console.WriteLine($"{CommandToDisplayAllDossiers}<---Вывод всех досье на экран с их ID в программе ");
                Console.WriteLine($"{DeleteDossierCommand}<--- Удалить досье по индексу ");
                Console.WriteLine($"{LastNameSearchCommand}<--- Поиск досье по ФИО");
                Console.WriteLine($"{ExitCommand}<---Выход из программы");

                switch (Console.ReadLine())
                {
                    case AddDossierCommand:
                        AddDossier(fullNames, positions);
                        break;

                    case CommandToDisplayAllDossiers:
                        ShowAllDossiers(positions, fullNames);
                        break;

                    case DeleteDossierCommand:
                        DeleteDossier(fullNames, positions);
                        break;

                    case LastNameSearchCommand:
                        SearchDossier(fullNames, positions);
                        break;

                    case ExitCommand:
                        isExitProgram = false;
                        break;

                }

                Console.Write("Нажмите любую кнопку для того чтобы продолжить...");
                Console.ReadKey();
            }
        }

        private static void AddDossier(List<string> names, List<string> positions)
        {
            Console.WriteLine("Введите ФИО сотрудника");
            string name = Console.ReadLine();
            Console.WriteLine("Введите должность сотрудника");
            string position = Console.ReadLine();

            names.Add(name);
            positions.Add(position);
        }

        private static void ShowAllDossiers(List<string> positions, List<string> fullNames)
        {
            int index = 1;

            for (int i = 0; i < positions.Count; i++)
            {
                Console.WriteLine($" Индекс [ {index} ] | ФИО : {fullNames[i]} | должность : {positions[i]}");
                index++;
            }
        }

        private static void DeleteDossier(List<string> fullNames, List<string> positions)
        {
            Console.Write("Введите номер досье :");

            if (int.TryParse(Console.ReadLine(), out int number) && number <= positions.Count && number >= 0)
            {
                int index = number - 1;
                fullNames.RemoveAt(index);
                positions.RemoveAt(index);
                Console.WriteLine($"Досье с индексом [ {number} ] удалено!!!");
            }
            else
            {
                Console.WriteLine("Досье с таким номером не существует!!!");
            }
        }

        private static void SearchDossier(List<string> fullNames, List<string> positions)
        {
            Console.WriteLine("Введите фамилию для поиска досье");
            string surname = Console.ReadLine();
            bool isSuccessfulSearch = false;

            for (int i = 0; i < fullNames.Count; i++)
            {
                string[] split = fullNames[i].Split(' ');

                if (split[0].ToLower() == surname.ToLower())
                {
                    Console.WriteLine($"Индекс [ {i + 1} ] | ФИО : {fullNames[i]} | должность : {positions[i]}");
                    isSuccessfulSearch = true;
                }
            }

            if (isSuccessfulSearch == false)
            {
                Console.WriteLine($"Досье сотрудников с фамилией '{surname}' не найдено!!!");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
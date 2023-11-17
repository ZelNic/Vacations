using System;
using System.Collections.Generic;
using Vacations.Data;

namespace Vacations
{
    public class Program
    {
        public static void Main()
        {
            ApplicationData data = new ApplicationData();
            VacationGenerator vacationGenerator = new VacationGenerator(data);

            foreach (var vacationList in data.StaffVacationDiary)
            {
                vacationGenerator.GenerateVacations(vacationList.Value);
            }

            PrintResult(data.StaffVacationDiary);
        }

        public static void PrintResult(Dictionary<string, List<DateTime>> staffVacationDiary)
        {
            int tableLength = TableSettings.HORIZONTAL_DIVIDER_LENGTH;
            int countRow = TableSettings.COUNT_ROW;


            Console.ForegroundColor = TableSettings.COLOR_NAME_TABLE;
            Console.WriteLine(new string('-', tableLength));
            Console.WriteLine("ЖУРНАЛ ОТПУСКОВ СОТРУДНИКОВ");
            Console.WriteLine(new string('-', tableLength));


            foreach (var vacationList in staffVacationDiary)
            {
                Console.ForegroundColor = TableSettings.COLOR_HIGHLIGHT_STRING;
                Console.WriteLine($"{vacationList.Key}");
                Console.WriteLine(new string('-', tableLength));
                Console.WriteLine("Дни отпуска:");
                Console.WriteLine(new string('-', tableLength));
                Console.ForegroundColor = TableSettings.DATE_HIGH_COLOR;

                var dates = vacationList.Value;
                int rowCount = (int)Math.Ceiling(dates.Count / (float)countRow);

                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < countRow; j++)
                    {
                        int index = i + j * rowCount;
                        if (index < dates.Count)
                        {
                            Console.Write($"|{dates[index]:dd.MM.yyyy|} ");
                        }
                    }
                    Console.WriteLine();
                }

                Console.ForegroundColor = TableSettings.COLOR_HIGHLIGHT_STRING;
                Console.WriteLine(new string('-', tableLength));
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Для закрытия программы нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}

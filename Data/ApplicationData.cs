using System.Collections.Generic;
using System;

namespace Vacations.Data
{
    public class ApplicationData
    {
        public readonly Dictionary<string, List<DateTime>> StaffVacationDiary = new Dictionary<string, List<DateTime>>()
        {
            ["Иванов Иван Иванович"] = new List<DateTime>(),
            ["Петров Петр Петрович"] = new List<DateTime>(),
            ["Юлина Юлия Юлиановна"] = new List<DateTime>(),
            ["Сидоров Сидор Сидорович"] = new List<DateTime>(),
            ["Павлов Павел Павлович"] = new List<DateTime>(),
            ["Георгиев Георг Георгиевич"] = new List<DateTime>()
        };

        public readonly string[] WorkDays = new string[5] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

        public readonly int NumberVacationDays = 28;
    }
}

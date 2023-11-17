using System;
using System.Collections.Generic;
using System.Linq;
using Vacations.Data;

namespace Vacations
{
    public class VacationGenerator
    {
        private readonly List<DateTime> _vacationDates;
        private readonly string[] _workDaysForVacations;
        private readonly Random _randomGenerator;
        private readonly int _numberOfVacations;

        DateTime start = new DateTime(DateTime.Today.Year, 1, 1);
        DateTime end = new DateTime(DateTime.Today.Year, 12, 31);

        public VacationGenerator(ApplicationData workDaysForVacations)
        {
            _vacationDates = new List<DateTime>();
            _workDaysForVacations = workDaysForVacations.WorkDays;
            _randomGenerator = new Random();
            _numberOfVacations = workDaysForVacations.NumberVacationDays;
        }

        public void GenerateVacations(List<DateTime> dateList)
        {
            int vacationCount = _numberOfVacations;
            int range = (end - start).Days;

            while (vacationCount > 0)
            {
                DateTime startDate = start.AddDays(_randomGenerator.Next(range));

                if (_workDaysForVacations.Contains(startDate.DayOfWeek.ToString()))
                {
                    int vacIndex = _randomGenerator.Next(2);
                    DateTime endDate = new DateTime(DateTime.Today.Year, 12, 31);
                    int difference = 0;

                    if (vacIndex == 0)
                    {
                        endDate = startDate.AddDays(7);
                        difference = 7;
                    }
                    else if (vacIndex == 1)
                    {
                        endDate = startDate.AddDays(14);
                        difference = 14;
                    }

                    if (vacationCount <= 7)
                    {
                        endDate = startDate.AddDays(7);
                        difference = 7;
                    }

                    bool canCreateVacation = false;
                    bool existStart = false;
                    bool existEnd = false;

                    if (!_vacationDates.Any(element => element >= startDate && element <= endDate))
                    {
                        if (!_vacationDates.Any(element => element.AddDays(3) >= startDate && element.AddDays(3) <= endDate))
                        {
                            existStart = dateList.Any(element => element.AddMonths(1) >= startDate && element.AddMonths(1) >= endDate);
                            existEnd = dateList.Any(element => element.AddMonths(-1) <= startDate && element.AddMonths(-1) <= endDate);
                            if (!existStart || !existEnd)
                                canCreateVacation = true;
                        }
                    }

                    if (canCreateVacation)
                    {
                        for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1))
                        {
                            _vacationDates.Add(dt);
                            dateList.Add(dt);
                        }
                        vacationCount -= difference;
                    }
                }
            }
        }
    }
}

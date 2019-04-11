using System;
using System.Collections.Generic;
using System.Linq;
using HealthOS.Models;

namespace HealthOS.Services
{
    public class DrugsService
    {
        public static List<string> GetDrugsForToday(List<Drug> drugs)
        {
            var today = new List<Drug>();
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    today= drugs.Where(d => d.Day1).ToList();
                    break;
                case DayOfWeek.Tuesday:
                    today= drugs.Where(d => d.Day2).ToList();
                    break;
                case DayOfWeek.Wednesday:
                    today = drugs.Where(d => d.Day3).ToList();
                    break;
                case DayOfWeek.Thursday:
                    today= drugs.Where(d => d.Day4).ToList();
                    break;
                case DayOfWeek.Friday:
                    today= drugs.Where(d => d.Day5).ToList();
                    break;
                case DayOfWeek.Saturday:
                    today= drugs.Where(d => d.Day6).ToList();
                    break;
                case DayOfWeek.Sunday:
                    today= drugs.Where(d => d.Day7).ToList();
                    break;
            }

            return today.Select(d => d.Name).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using HealthOS.Models;
using HealthOS.Models.Statistics;
using Microsoft.AspNetCore.Mvc.Internal;

namespace HealthOS.Services
{
    public static class ChartDatapointsService
    {
        public static (List<BloodPressureStatistics>, string) PrepareBloodPressureStatistics(ApplicationUser user, int page)
        {
            var month = DateTime.Now.Month + page % 12 == 0 ? 12 : DateTime.Now.Month + page % 12;
            var monthStarts = new DateTime(DateTime.Now.Year + page / 12, month, 1);
            var year = 0;
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else month++;
            var monthEnds = new DateTime(monthStarts.Year + year, month, 1);
            List<BloodPressureStatistics> statistics;
            try
            {
                statistics = user.BloodPressureStatistics
                    .Where(d => d.MeasurementDate >= monthStarts && d.MeasurementDate <= monthEnds).OrderBy(t => t.MeasurementDate).ToList();
            }
            catch (ArgumentNullException)
            {
                return (null, string.Empty);
            }

            var result = string.Empty;
            foreach (var stat in statistics)
            {
                result += $"[new Date({stat.MeasurementDate.Year},{stat.MeasurementDate.Month},{stat.MeasurementDate.Day},{stat.MeasurementDate.Hour},{stat.MeasurementDate.Minute}), {stat.Systolic}, {stat.Diastolic}],";
            }

            return (statistics, result);
        }

        public static (List<GlucoseLevelStatistics>, string) PrepareGlucoseLevelStatistics(ApplicationUser user, int page)
        {
            var month = DateTime.Now.Month + page % 12 == 0 ? 12 : DateTime.Now.Month + page % 12;
            var monthStarts = new DateTime(DateTime.Now.Year + page / 12, month, 1);
            var year = 0;
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else month++;
            var monthEnds = new DateTime(monthStarts.Year + year, month, 1);
            List<GlucoseLevelStatistics> statistics;
            try
            {
                statistics = user.GlucoseStatistics
                    .Where(d => d.MeasurementDate >= monthStarts && d.MeasurementDate <= monthEnds).OrderBy(t => t.MeasurementDate).ToList();
            }
            catch (ArgumentNullException)
            {
                return (null, string.Empty);
            }

            var result = string.Empty;
            foreach (var stat in statistics)
            {
                result += $"[new Date({stat.MeasurementDate.Year},{stat.MeasurementDate.Month},{stat.MeasurementDate.Day},{stat.MeasurementDate.Hour},{stat.MeasurementDate.Minute}), {stat.Glucose}],";
            }

            return (statistics, result);
        }
        public static (List<WeightStatistics>, string) PrepareWeightStatistics(ApplicationUser user, int page)
        {
            var month = DateTime.Now.Month + page % 12 == 0 ? 12 : DateTime.Now.Month + page % 12;
            var monthStarts = new DateTime(DateTime.Now.Year + page / 12, month, 1);
            var year = 0;
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else month++;
            var monthEnds = new DateTime(monthStarts.Year + year, month, 1);
            List<WeightStatistics> statistics;
            try
            {
                statistics = user.WeightStatistics
                    .Where(d => d.MeasurementDate >= monthStarts && d.MeasurementDate <= monthEnds).OrderBy(t => t.MeasurementDate).ToList();
            }
            catch (ArgumentNullException)
            {
                return (null, string.Empty);
            }

            var result = string.Empty;
            foreach (var stat in statistics)
            {
                result += $"[new Date({stat.MeasurementDate.Year},{stat.MeasurementDate.Month},{stat.MeasurementDate.Day},{stat.MeasurementDate.Hour},{stat.MeasurementDate.Minute}), {stat.Weight}],";
            }

            return (statistics, result);
        }
        public static (List<HeightStatistics>, string) PrepareHeightStatistics(ApplicationUser user, int page)
        {
            var month = DateTime.Now.Month + page % 12 == 0 ? 12 : DateTime.Now.Month + page % 12;
            var monthStarts = new DateTime(DateTime.Now.Year + page / 12, month, 1);
            var year = 0;
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else month++;
            var monthEnds = new DateTime(monthStarts.Year + year, month, 1);
            List<HeightStatistics> statistics;
            try
            {
                statistics = user.HeightStatistics
                    .Where(d => d.MeasurementDate >= monthStarts && d.MeasurementDate <= monthEnds).OrderBy(t => t.MeasurementDate).ToList();
            }
            catch (ArgumentNullException)
            {
                return (null, string.Empty);
            }

            var result = string.Empty;
            foreach (var stat in statistics)
            {
                result += $"[new Date({stat.MeasurementDate.Year},{stat.MeasurementDate.Month},{stat.MeasurementDate.Day},{stat.MeasurementDate.Hour},{stat.MeasurementDate.Minute}), {stat.Height}],";
            }

            return (statistics, result);
        }

        public static List<CustomStatisticsViewDetails> PrepareCustomStatistics(ApplicationUser user, int page)
        {
            var month = DateTime.Now.Month + page % 12 == 0 ? 12 : DateTime.Now.Month + page % 12;
            var monthStarts = new DateTime(DateTime.Now.Year + page / 12, month, 1);
            var year = 0;
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else month++;
            var monthEnds = new DateTime(monthStarts.Year + year, month, 1);

            List<CustomStatisticsViewDetails> statistics = new List<CustomStatisticsViewDetails>();

            foreach (var stats in user.CustomStatistics)
            {
                var newStatistics = new CustomStatisticsViewDetails();
                try
                {
                    stats.CustomStatisticsDatas = stats.CustomStatisticsDatas.Where(d => d.MeasurementDate >= monthStarts && d.MeasurementDate <= monthEnds).OrderBy(t => t.MeasurementDate).ToList();
                    newStatistics.Statistics = stats;
                }
                catch (ArgumentNullException)
                {
                    continue;
                }

                var result = string.Empty;
                foreach (var stat in newStatistics.Statistics.CustomStatisticsDatas)
                {
                    if (!stat.IsSecondMeasurementUsed)
                    {
                        result += $"[new Date({stat.MeasurementDate.Year},{stat.MeasurementDate.Month},{stat.MeasurementDate.Day},{stat.MeasurementDate.Hour},{stat.MeasurementDate.Minute}), {stat.FirstMeasurement}],";
                    }
                    else
                    {
                        result += $"[new Date({stat.MeasurementDate.Year},{stat.MeasurementDate.Month},{stat.MeasurementDate.Day},{stat.MeasurementDate.Hour},{stat.MeasurementDate.Minute}), {stat.FirstMeasurement}, {stat.SecondMeasurement}],";
                    }
                }
                newStatistics.ChartData = result;
                statistics.Add(newStatistics);
            }
            return statistics;
        }
    }
}

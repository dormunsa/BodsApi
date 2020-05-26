using BodsEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsLogic
{
    public class TimeRangeLogic
    {
        public async Task<TimeRangeResponse> GetTimeRange(string timeRange)
        {
            TimeRangeResponse response = new TimeRangeResponse();
            DateTime timeNow = DateTime.UtcNow;

            switch (timeRange)
            {
                case TimeRangeDefinition.weekToDate:
                    DateTime start_of_week = timeNow.StartOfWeek(DayOfWeek.Monday);
                    response.FromDate = new DateTime(start_of_week.Year, start_of_week.Month, start_of_week.Day, 00, 00, 00);
                    response.ToDate = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, 23, 59, 59); ;
                    break;
                case TimeRangeDefinition.monthToDate:
                    response.FromDate = new DateTime(timeNow.Year, timeNow.Month, 1, 00, 00, 00);
                    response.ToDate = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, 23, 59, 59); ; ;
                    break;
                case TimeRangeDefinition.yearToDate:
                    response.FromDate = new DateTime(timeNow.Year, 1, 1, 00, 00, 00);
                    response.ToDate = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, 23, 59, 59);
                    break;
                case TimeRangeDefinition.lastWeek:
                    DateTime last_week = timeNow.AddDays(-7);
                    DateTime last_week_start_at = last_week.StartOfWeek(DayOfWeek.Monday);
                    DateTime last_week_ends_at = last_week_start_at.AddDays(6);

                    response.FromDate = new DateTime(last_week_start_at.Year, last_week_start_at.Month, last_week_start_at.Day, 00, 00, 00);
                    response.ToDate = new DateTime(last_week_ends_at.Year, last_week_ends_at.Month, last_week_ends_at.Day, 23, 59, 59);

                    break;
                case TimeRangeDefinition.lastMonth:
                    DateTime last_month = timeNow.AddMonths(-1);
                    response.FromDate = new DateTime(last_month.Year, last_month.Month, 1, 00, 00, 00);
                    response.ToDate = new DateTime(last_month.Year, last_month.Month, DateTime.DaysInMonth(last_month.Year, last_month.Month), 23, 59, 59);
                    break;
                case TimeRangeDefinition.yesterday:
                    DateTime yesterday = timeNow.AddDays(-1);
                    response.FromDate = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 00, 00, 00);

                    response.ToDate = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 23, 59, 59);
                    break;
                case TimeRangeDefinition.tomorrow:
                    DateTime tmrw = timeNow.AddDays(1);
                    response.FromDate = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, 00, 00, 00);
                    response.ToDate = new DateTime(tmrw.Year, tmrw.Month, tmrw.Day, 00, 00, 00);
                    break;
                default:

                    if (string.IsNullOrEmpty(timeRange) || timeRange == TimeRangeDefinition.today)
                    {
                        response.FromDate = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, 00, 00, 00);
                        response.ToDate = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, 23, 59, 59);
                    }

                    break;
            }

            return response;
        }
       
    }
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}

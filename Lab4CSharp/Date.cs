using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Date
    {
        protected int day;
        protected int month;
        protected int year;

        public Date(int day, int month, int year)
        {
            if (!IsValidDate(day, month, year))
            {
                throw new ArgumentException("Incorrect date.");
            }

            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int Day
        {
            get { return day; }
            set
            {
                if (IsValidDate(value, month, year))
                {
                    day = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect day.");
                }
            }
        }
        public int Month
        {
            get { return month; }
            set
            {
                if (IsValidDate(day, value, year))
                {
                    month = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect month.");
                }
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                if (IsValidDate(day, month, value))
                {
                    year = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect year.");
                }
            }
        }

        public Date this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return new Date(day, month, year); 
                }
                else
                {
                    int totalDays = day + (month - 1) * GetDaysInMonth(year, month);
                    totalDays += index; 

                    int newMonth = (totalDays - 1) / 30 + 1; 
                    int newDay = totalDays % GetDaysInMonth(year, newMonth); 

                    if (newDay == 0)
                    {
                        newDay = GetDaysInMonth(year, newMonth);
                    }

                    int newYear = year;

                    if (newMonth > 12)
                    {
                        newYear += (newMonth - 1) / 12; 
                        newMonth = (newMonth - 1) % 12 + 1; 
                    }

                    return new Date(newDay, newMonth, newYear);
                }
            }
        }

        public static bool operator !(Date date)
        {
            int maxDaysInMonth = GetDaysInMonth(date.Year, date.Month);
            return date.Day != maxDaysInMonth;
        }

        public static bool operator true(Date date)
        {
            return date.Day == 1 && date.Month == 1;
        }

        public static bool operator false(Date date)
        {
            return !(date.Day == 1 && date.Month == 1);
        }

        public static bool operator &(Date date1, Date date2)
        {
            return date1.Day == date2.Day && date1.Month == date2.Month && date1.Year == date2.Year;
        }

        public static bool IsValidDate(int day, int month, int year)
        {
            if (year < 1)
            {
                return false;
            }

            if (month < 1 || month > 12)
            {
                return false;
            }

            int maxDaysInMonth = GetDaysInMonth(year, month);

            if (day < 1 || day > maxDaysInMonth)
            {
                return false;
            }

            return true;
        }

        public static implicit operator string(Date date)
        {
            return $"{date.Day:D2}.{date.Month:D2}.{date.Year}";
        }

        public static implicit operator Date(string dateString)
        {
            string[] parts = dateString.Split('.');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid date string format.");
            }

            int day,
                month,
                year;
            if (
                !int.TryParse(parts[0], out day)
                || !int.TryParse(parts[1], out month)
                || !int.TryParse(parts[2], out year)
            )
            {
                throw new ArgumentException("Invalid date string format.");
            }

            return new Date(day, month, year);
        }

        public static string GetMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    throw new ArgumentException("Incorrect number of month.");
            }
        }

        public void PrintDateInMonthFormat()
        {
            Console.WriteLine($"{day} {GetMonthName(month)} {year} year");
        }

        public void PrintDateInDotFormat()
        {
            Console.WriteLine($"{day:D2}.{month:D2}.{year}");
        }

        public int GetCentury
        {
            get { return (year - 1) / 100 + 1; }
        }

        private static int GetDaysInMonth(int year, int month)
        {
            switch (month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return IsLeapYear(year) ? 29 : 28;
                default:
                    return 31;
            }
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        public static int DaysBetweenDates(Date date1, Date date2)
        {
            int daysInMonth1 = GetDaysInMonth(date1.Year, date1.Month);
            int daysInMonth2 = GetDaysInMonth(date2.Year, date2.Month);

            int totalDays1 = date1.Day + (date1.Month - 1) * daysInMonth1;
            int totalDays2 = date2.Day + (date2.Month - 1) * daysInMonth2;

            return Math.Abs(totalDays2 - totalDays1);
        }
    }
}

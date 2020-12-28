using System;
using System.Globalization;
using System.Linq;
using Facturacion.Entities.AttributesProperties;

namespace Facturacion.Utils
{
    public static class Helpers
    {
        public static string GetDBNamePropertyAttributeInSearch<T>(this T source, string propertyName)
            where T : class
        {
            var sourceType = source.GetType();
            var data = propertyName;

            foreach (var p in sourceType.GetProperties())
            {
                //foreach (Attribute a in p.GetCustomAttributes(false))
                foreach (Attribute a in p.GetCustomAttributes(typeof(OrderByDBAttributes), false).OfType<OrderByDBAttributes>())
                {
                    var CustomAttribute = (OrderByDBAttributes)a;

                    if (p.Name.ToUpper() == propertyName.ToUpper())
                    {
                        data = CustomAttribute.DBName ?? data;

                        return data;
                    }
                }
            }

            return data;
        }

        public static string toUpperCaseValue(this string valueStr)
        {
            if (valueStr == null)
            {
                valueStr = string.Empty;
            }
            return valueStr.ToUpper();
        }

        public static bool CaseInsensitiveContains(this string text, string value,
        StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

        public static bool CaseInsensitiveContains(this string text, string value)
        {
            return text.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        #region DATETIME

        public static string ToDateFormat(this DateTime date, bool displayTime = false)
        {
            if (displayTime)
            {
                return date.ToString("dd-MMM-yyyy hh:mm tt");
            }
            else
            {
                return date.ToString("dd-MMM-yyyy");
            }
        }

        public static string ToDateShortFormat(this DateTime date, bool displayTime = false)
        {
            if (displayTime)
            {
                return date.ToString("dd-MM-yyyy hh:mm tt");
            }
            else
            {
                return date.ToString("dd-MM-yyyy");
            }
        }

        /// <summary>
        /// Convierte un string a DateTime en el formato exacto dd-MM-yyyy hh:mm tt
        /// </summary>
        /// <param name="datetime">31-12-2020 10:25 am</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string datetime)
        {
            return DateTime.ParseExact(datetime, "dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Convierte un string a DateTime en el formato exacto dd-MM-yyyy
        /// </summary>
        /// <param name="date">31-12-2020</param>
        /// <returns></returns>
        public static DateTime ToDate(this string date)
        {

            return DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Convierte un string en formato hora de 12h a 24h
        /// </summary>
        /// <param name="time12Hr">1:00 pm</param>
        /// <returns></returns>
        public static string To24Hr(this string time12Hr)
        {
            return DateTime.Parse(time12Hr).ToString("HH:mm");
        }

        /// <summary>
        /// Da formato en string a una hora en formato de 24h
        /// </summary>
        /// <param name="time24Hr">1525</param>
        /// <returns></returns>
        public static string To24HrFormat(this string time24Hr)
        {
            if (string.IsNullOrEmpty(time24Hr)) return string.Empty;
            return DateTime.ParseExact(time24Hr, "HHmm", CultureInfo.InvariantCulture).ToString("HH:mm");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time24Hr"></param>
        /// <returns></returns>
        public static DateTime ToHour(this string time24Hr)
        {
            return DateTime.ParseExact(time24Hr, "HHmm", CultureInfo.InvariantCulture);
        }

        public static TimeSpan ToTimeSpan(this string time24Hr)
        {
            var time = DateTime.ParseExact(time24Hr, "HHmm", CultureInfo.InvariantCulture).ToString("HH:mm").Split(":");
            return new TimeSpan(int.Parse(time[0]), int.Parse(time[1]), 0);
        }

        public static DateTime? GetDateWithAddHour(this DateTime? date, string time24Hr)
        {
            if (date == null || string.IsNullOrEmpty(time24Hr))
            {
                return date;
            }

            return date.GetValueOrDefault().Add(time24Hr.ToTimeSpan());
        }

        #endregion

    }
}

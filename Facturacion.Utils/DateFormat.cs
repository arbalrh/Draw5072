using System;
using System.Globalization;
using NodaTime;

namespace Facturacion.Utils
{
    public static class DateFormat
    {
        public static string MonthName(int month)
        {
            var dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public static string MonthNameArray(int month)
        {
            string[] months = { "", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
            return months[month];
        }

        public static DateTime GetDateToPanamaTimeZone()
        {
            var panamaTimeZone = DateTimeZoneProviders.Tzdb["America/Panama"];

            return Instant.FromDateTimeUtc(DateTime.UtcNow)
                          .InZone(panamaTimeZone)
                          .ToDateTimeUnspecified();
        }

        public static DateTime ConvertDateToPanamaTimeZone(DateTime dateTime)
        {
            var panamaTimeZone = DateTimeZoneProviders.Tzdb["America/Panama"];

            return Instant.FromDateTimeUtc(dateTime)
                          .InZone(panamaTimeZone)
                          .ToDateTimeUnspecified();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DateTime = Lab1.DateTime;

namespace Lab5
{
    public class CalendarJsonParser
    {
        public static List<DateTime> GetHolidayDayFromJson()
        {
            var list = new List<DateTime>();
            var dir = TryGetSolutionDirectoryInfo();
            using (var r = new StreamReader($"{dir.FullName}\\Files\\workCalendar.json"))
            {
                var json = r.ReadToEnd();
                var data = JsonConvert.DeserializeObject(json) as JObject;
                var monthArray = data?["months"] as JArray; 
                foreach (var token in monthArray)
                {
                    int month = Convert.ToInt32(token["month"].ToString());
                    var days = token["days"].ToString();
                    foreach (var day in days.Split(","))
                    {
                        var match =  new String(day.Where(Char.IsDigit).ToArray());
                        var dayInt= Convert.ToInt32(match.ToString());
                        list.Add(new DateTime(dayInt, month, 2021));
                    }
                }
            }

            return list;
        }
        
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }

    }
}
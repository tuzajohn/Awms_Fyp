using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Dll;
using Customs;

namespace Awms_Fyp
{
    public class ScheduleClass
    {
        MyCustoms myCustoms = new MyCustoms();
        public ScheduleClass()
        {

        }//speciality, dataset for type
        public (DateTime time, string docName) SetAppointment(DateTime selectedDate, Dictionary<DateTime, Dictionary<string, List<string>>> appTable)
        {
            
            return (DateTime.Now, null);
        }
        private void Scan(string type, DateTime dayOfShift, List<Speciality_table> docTypeInDay)
        {
            //var DayOfShift = new Shift_table().Load_record_with(Shift_table_support.Column.Day_period, Shift_table_support.LogicalOperator.EQUAL_TO, dayOfShift.ToString("yyyy-MM-dd"));

        }
        private string CheckType(Dictionary<string, List<string>> dictionary, string text)
        {
            var type = string.Empty;
            type = myCustoms.GetKeyFromDictionary(dictionary, text);
            return type;
        }
        private void SlotChecker(List<Appointment> appOfTheDay)
        {

        }
    }
}
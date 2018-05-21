using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Dll;
using Customs;
using System.Data;

namespace Awms_Fyp
{
    public class ScheduleClass
    {
        MyCustoms myCustoms = new MyCustoms();
        public string DocTitle { get; set; }
        public ScheduleClass()
        {

        }
        public void GetDoctorsFromDb(Dictionary<string, List<string>> dictionary, string description, out List<string> doctorsList)
        {
            var list = new List<string>();
            DocTitle = new MyCustoms().GetKeyFromDictionary(dictionary, description);
            var temp = new Doctor_view().getAllRecords().Where(doc => doc.Speciality == DocTitle).ToList();
            foreach (var item in temp) { list.Add(item.Id); }
            doctorsList = list;
        }
        public int SetAppointment(string selectedDate, string docId, string patientId, string description)
        {
            var id = string.Empty;
            var time = new ShiftHandler().SetTimeAppointment(docId, DateTime.Parse(selectedDate));
            var app = new Appointment().insert(patientId, docId, DateTime.Parse(selectedDate).ToString("yyyy-MM-dd"), description, "pending", time.ToString());
            return time;
        }
        public void  SlotChecker(int weekInt, string doc_id, out string row)
        {
            var temp_id = string.Empty;
            var appTable =  new Appointment().getAllRecords().Where(a => GetIntWeek(a.Schedule_date) == weekInt && a.Doctor_id == doc_id).ToList();
            temp_id = new Appointment().getAllRecords().GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First().Id;
            

            row = temp_id;
        }
        private int GetIntWeek(string date)
        {
            return (int)DateTime.Parse(date).DayOfWeek;
        }
    }
}
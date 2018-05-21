using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customs;

namespace Project_Dll
{
    public class ShiftHandler
    {
        Random random;
        public ShiftHandler()
        {
            
        }
        public void SetDocShift(string docId)
        {
            random = new Random();
            int[] hours = { 0, 4, 8, 12, 16, 20 };
            var weekDays = new Days_of_week().getAllRecords();
            foreach (var day in weekDays)
            {
                var tu = random.Next(0, 5);
                int pos = hours[tu];
                var doc_in_day = new Shift_table().getAllRecords().Where(i => i.Day_week_id == day.Id).ToList();
                if (doc_in_day.Count == 0)
                {
                    new Shift_table().insert(docId, day.Id, (pos).ToString(), (pos + 4).ToString());
                }
                else
                {
                    foreach (var period in doc_in_day)
                    {
                        var doc = period.getAllRecords().Where(i => i.Day_week_id == day.Id && i.Start_time == pos.ToString()).FirstOrDefault();
                        if (doc == null)
                        {
                            new Shift_table().insert(docId, day.Id, (pos).ToString(), (pos + 4).ToString());
                            break;
                        }
                        else
                        {
                            var docDetails = new Doctor_view().Load_record_with(Doctor_view_support.Column.Id, Doctor_view_support.LogicalOperator.EQUAL_TO, doc.Doc_id);
                            var newDoctDetail = new Doctor_view().Load_record_with(Doctor_view_support.Column.Id, Doctor_view_support.LogicalOperator.EQUAL_TO, docId);
                            if (docDetails.Speciality != newDoctDetail.Speciality)
                            {
                                doc.insert(docId, day.Id, (pos).ToString(), (pos + 4).ToString());
                                break;
                            }
                            else
                            {
                                var availHours = hours.ToList().Where(o => !doc_in_day.Any(b => b.Id == o.ToString())).ToList();
                                pos = availHours[new Random().Next(0, availHours.Count)];
                                doc.insert(docId, day.Id, (pos).ToString(), (pos + 4).ToString());
                                break;
                            }
                        }
                    }
                }
            }
        }
        public DataTable GetTable(List<string> docOfTheDay, bool links)
        {
            var enc = new Encryption() { Key = "&*>w!@~g" };
            DataTable table = new DataTable("shift");
            List<Shift_table> shift_Tables = new Shift_table().getAllRecords();
            //table.Columns.Add("#");
            table.Columns.Add("Day");
            table.Columns.Add("PERIOD1");//0-4
            table.Columns.Add("PERIOD2");//4-8
            table.Columns.Add("PERIOD3");//8-12
            table.Columns.Add("PERIOD4");//12-16
            table.Columns.Add("PERIOD5");//16-20
            table.Columns.Add("PERIOD6");//20-24
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = table.Columns["Day"];
            table.PrimaryKey = keyColumns;
            var appCounter = 5;
            for (int i = 0; i < 7; i++)
            {
                DataRow row = table.NewRow();
                var daysInWeek = DateTime.Now.AddDays(i%7);
                var DayList = new Days_of_week().getAllRecords().Where(day => day.Day.ToLower() == daysInWeek.DayOfWeek.ToString().ToLower()).First();
                for (int j = 0, r = 1; j <= 20; j += 4, r++)
                {
                    var docId = string.Empty;
                    //row[0] = (i+1);
                    row[0] = DayList.Short_name.ToUpper();
                    var shift_Table = shift_Tables.Where(shift => shift.Day_week_id == DayList.Id && shift.Start_time == j.ToString()).ToList();
                    if (shift_Table == null) { row[r] = ""; }
                    else
                    {
                        foreach (var individual in shift_Table)
                        {
                            if (docOfTheDay.Contains(individual.Doc_id))
                            {
                                var apps = new Appointment().getAllRecords().Where(app => app.Doctor_id == individual.Doc_id && app.Schedule_date == daysInWeek.ToString("yyyy-MM-dd")).ToList();
                                var docDetails = new Doctor_view().getAllRecords().Where(doc => doc.Id == individual.Doc_id).First();
                                var linkString = string.Empty;
                                if (links) { linkString = $"<a href='../../home?id={enc.EncryptString(docDetails.Id, "&*>w!@~g")}&date={daysInWeek.ToLongDateString()}'>{docDetails.Name}</a>"; }
                                else { linkString = $"<h4>Shift</h4>"; }
                                row[r] = linkString;
                            }
                            else { row[r] = ""; }
                        }
                    }
                }
                table.Rows.Add(row);
                //var c = table.Rows[i][3].ToString();
            }
            return table;
        }
        public int SetTimeAppointment(string docId, DateTime date)
        {
            var shiftView = new Shift_table().getAllRecords().Where(s => s.Doc_id == docId && s.Day_week_id == (date.DayOfWeek == 0 ? 7 : (int)date.DayOfWeek).ToString()).FirstOrDefault();
            var appView = new Appointment().getAllRecords().Where(a => a.Doctor_id == docId && a.Schedule_date == date.ToString("yyyy-MM-dd")).FirstOrDefault();
            if (appView is null) { return int.Parse(shiftView.Start_time); }
            else if (int.Parse(appView.Set_time) < int.Parse(shiftView.End_time)) { return int.Parse(appView.Set_time) + 1; }
            else if (appView.Set_time == shiftView.End_time) { return 0; }
            return 1;
        }
    }
}

using System;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Final_Year_Project_Unit_Tests.Management
{
    [TestClass]
    public class SetingShift_Tests
    {
        [TestMethod]
        public void check_whether_it_works()
        {
            var Shift = new Awms_Fyp.Shift("C:\\Users\\Tuza John Sylver\\source\\fyp\\Awms_Fyp\\Awms_Fyp\\ShiftFile.txt", "2");
        }
        [TestMethod]
        public void Test_Shift_allocation()
        {
            int[] hours = { 0, 1, 2, 3, 4, 8, 9 }; string[] doc_in_day = { "0", "2", "3", "4"};
            var trustys = hours.ToList().Where(o => !doc_in_day.Any(b => b == o.ToString())).ToList();
            var u = trustys[new Random().Next(0, trustys.Count)];
            //new Project_Dll.ShiftHandler().SetDocShift("6");
        }
        [TestMethod]
        public void GetTableTest()
        {
            DataTable table = new Project_Dll.ShiftHandler().GetTable(new System.Collections.Generic.List<string>() { "2" }, true);
            var t = table;
        }
        [TestMethod]
        public void TestSlot()
        {
            new Awms_Fyp.ScheduleClass().SlotChecker(1, "3", out string row);
            var t = row;
        }
        [TestMethod]
        public void Test_Set_Time()
        {
            var id = new Project_Dll.ShiftHandler().SetTimeAppointment("2", DateTime.Parse("2018-05-18"));
            var g = new Project_Dll.ShiftHandler().SetTimeAppointment("5", DateTime.Parse("2018-05-18"));
        }
    }
}

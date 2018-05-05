using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;
using Customs;

namespace Awms_Fyp.Awms.Patient
{
    public partial class Default : System.Web.UI.Page
    {
        SessionVerification SV;
        Dictionary<string, List<string>> dictionary;
        NavClass nav = new NavClass();
        HtmlElements elements = new HtmlElements();
        Dictionary<string, int> pairs;
        MyCustoms customs = new MyCustoms();
        ScheduleClass schedule = new ScheduleClass();
        Shift s;
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            s = new Shift();
            dictionary = new Dictionary<string, List<string>>();
            if(Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            Check();
            Scedulle();
        }
        private void Check()
        {
            if (!SV.IsloggedIn)
            {
                Response.Redirect(nav.Logout);
            }
            else
            {
                if (SV.Status.ToLower() != "patient")
                {
                    Response.Redirect(nav.Logout);
                }
            }
        }
        void Scedulle()
        {
            saveBtn.ServerClick += delegate
            {
                if (DateTime.TryParse(appDate.Value, out DateTime date) && date > DateTime.Now)
                {
                    var appTable = new Appointment();
                    List<Symptom_dataset> keywords_Tables = new Symptom_dataset().getAllRecords();
                    pairs = new Dictionary<string, int>();
                    var txt = "";
                    foreach (var words in keywords_Tables)
                    {
                        List<string> MyDocList = new List<string>();
                        var txtArray = words.Symptom.Replace(",", "").Split();
                        for (int i = 0; i < txtArray.Length; i++) { MyDocList.Add(txtArray[i]); }
                        var docType = new Speciality_table().Load_record_with(Speciality_table_support.Column.Doctor_id, Speciality_table_support.LogicalOperator.EQUAL_TO, words.Doctor_id);
                        dictionary.Add(docType.Speciality, MyDocList);
                    }
                    var appointments = new Appointment().Search_For(Appointment_support.Column.Schedule_date, Appointment_support.LogicalOperator.GREATER_THAN_OR_EQUAL_TO, date.ToString("yyyy-MM-dd"));

                    var appDictionary = new Dictionary<DateTime, Dictionary<string, List<string>>>();
                    foreach (var app_ in appointments) { appDictionary.Add(DateTime.Parse(app_.Schedule_date), dictionary); }

                    s = new Shift(SV.ShiftFilePath);

                    schedule.SetAppointment(date, appDictionary);
                    //appTable.insert(SV.Uid, "doctor id", appDate.Value, messageBox.Value, SV.Status, DateTime.Now.ToString("yyyy-MM-dd"));
                    Session["message"] = elements.GetMesage("Appointment was successfully scheduled.", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.ALL);
                }
                else { Session["message"] = elements.GetMesage("The date selected is not a valide date. Please, select an appropriate date.", HtmlElements.MessageType.ERROR, HtmlElements.UserType.PATIENT); }
                Response.Redirect(nav.PatientHome);
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;
using Customs;
using System.Data;

namespace Awms_Fyp.Awms.Patient
{
    public partial class Default : System.Web.UI.Page
    {
        SessionVerification SV;
        Dictionary<string, List<string>> dictionary;
        NavClass nav = new NavClass();
        HtmlElements elements = new HtmlElements();
        Dictionary<string, int> pairs;
        ScheduleClass schedule = new ScheduleClass();
        ShiftHandler shiftHandler = new ShiftHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            dictionary = new Dictionary<string, List<string>>();
            if(Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            Check();

            try
            {
                var docId = Request.Params.Get("id");
                var date = Request.Params.Get("date");
                SettingAppointment(new Encryption().DecryptString(docId, SV.LoginKey), date);
            }
            catch (Exception) { }

            if(Session["table"] != null)
            {
                messageBox.Value = Session["description"].ToString();
                DataTable table = (DataTable)Session["table"];
                GridView1.Visible = true;
                GridView1.DataSource = table;
                GridView1.DataBind();
            }
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
                var appTable = new Appointment();
                List<Symptom_dataset> keywords_Tables = new Symptom_dataset().getAllRecords();
                pairs = new Dictionary<string, int>();
                
                foreach (var words in keywords_Tables)
                {
                    List<string> MyDocList = new List<string>();
                    var txtArray = words.Symptom.Replace(",", "").Split();
                    for (int i = 0; i < txtArray.Length; i++) { MyDocList.Add(txtArray[i]); }
                    var docType = new Speciality_table().Load_record_with(Speciality_table_support.Column.Speciality, Speciality_table_support.LogicalOperator.EQUAL_TO, words.Speciality);
                    dictionary.Add(docType.Speciality, MyDocList);
                }
                
                schedule.GetDoctorsFromDb(dictionary, messageBox.Value, out List<string> doc);

                DataTable table = shiftHandler.GetTable(doc, true);
                Session["description"] = messageBox.Value;
                Session["table"] = table;
                Response.Redirect(nav.PatientHome);
            };
        }
        private void SettingAppointment(string docId, string selectedDate)
        {
            var time = schedule.SetAppointment(selectedDate, docId, SV.Uid, Session["description"].ToString());
            var doc = new Doctor_view().getAllRecords().Where(d => d.Id == docId).FirstOrDefault();
            Session["message"] = elements.GetMesage($"Appointment with {doc.Name} at {time}:00 was successfully scheduled.", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.ALL);
            Response.Redirect(nav.PatientHome);
        }
    }
}
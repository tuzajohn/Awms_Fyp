using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;
using Customs;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Awms_Fyp.Awms.Management
{
    public partial class Doctor_Detail : System.Web.UI.Page
    {
        Shift Shift;
        SessionVerification SV;
        NavClass nav = new NavClass();
        Encryption enc;
        HtmlElements elements = new HtmlElements();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.LoginKey };
            if (Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            Check();
            SaveDoctor();
        }
        private void SaveDoctor()
        {
            SaveBtn.ServerClick += delegate
            {
                var redirect = string.Empty;
                var logins = new Login_table().Load_record_with(Login_table_support.Column.Username, Login_table_support.LogicalOperator.EQUAL_TO, userBox.Value);
                if (IsEmpty(logins.Id))
                {
                    var uDetails = new User_details();
                    var spTable = new Speciality_table();
                    if (passBox.Value == rePass.Value)
                    {
                        logins.insert(userBox.Value, enc.GetMD5(enc.StrongEncrypt(passBox.Value)), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "3");
                        uDetails.insert(logins.Id, Session["fname"].ToString(), Session["lname"].ToString(), Session["email"].ToString(), Session["address"].ToString(),
                            Session["contact"].ToString(), Session["gender"].ToString(), Session["date"].ToString(), "doctor");
                        ImagePofile();
                        spTable.insert(logins.Id, Session["profession"].ToString());

                        new ShiftHandler().SetDocShift(logins.Id);

                        Session["message"] = elements.GetMesage("New doctor has been added :-)", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.MANAGEMENT);
                        Shift = new Shift(SV.ShiftFilePath, logins.Id);
                        redirect = nav.Dashboard;
                    }
                    else { Session["message"] = elements.GetMesage("Passwords do not match!", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.MANAGEMENT); redirect = nav.ManNewDoctorDetails; }
                }
                else { Session["message"] = elements.GetMesage("Username already exist", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.MANAGEMENT); redirect = nav.ManNewDoctorDetails; }
                Response.Redirect(redirect);
            };
        }
        private void ImagePofile()
        {
            if (!string.IsNullOrEmpty(inputFile.Value))
            {
                var n = 0;
                var getImage = new Profile_image_table().getAllRecords();
                var positionString = getImage.Count == 0 ? 0 : int.Parse(getImage[getImage.Count - 1].Id);
                switch (positionString.ToString())
                {
                    case "": n = 1; break;
                    default: n = int.Parse(positionString.ToString()) + 1; break;
                }
                Stream stream = inputFile.PostedFile.InputStream;
                var filename = Path.GetFileName(inputFile.PostedFile.FileName);
                var imageName = enc.GetMD5(n.ToString()).ToLower() + ".jpg";
                var saveTo = Server.MapPath($"~/Images/{inputFile.PostedFile.FileName.Replace(filename, $"{imageName}")}");
                try
                {
                    var profImage = new Profile_image_table();
                    SaveImage(Ratio(inputFile.PostedFile.ContentLength), stream, saveTo);
                    profImage.insert(SV.Uid, imageName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    Session["image"] = imageName;
                    Session["message"] = " Profile image has been updated!";
                }
                catch (Exception) {}
            }
        }
        private double Ratio(int size)
        {
            if (size <= 131072) { return 1; }
            else if (size <= 524288) { return 0.6; }
            else if (size <= 1048576) { return 0.3; }
            else { return 0.22; }
        }
        private void SaveImage(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }
        private void Check()
        {
            if (!SV.IsloggedIn)
            {
                Response.Redirect(nav.Logout);
            }
            else
            {
                if (SV.Status.ToLower() != "management")
                {
                    Response.Redirect(nav.Logout);
                }
            }
        }
        bool IsEmpty(string txt)
        {
            var k = false;
            if (string.IsNullOrEmpty(txt)) { k = true; }
            return k;
        }
    }
}
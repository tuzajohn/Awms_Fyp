using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;
using Customs;

namespace Awms_Fyp.Awms.Patient
{
    public partial class Picture : System.Web.UI.Page
    {
        SessionVerification SV;
        NavClass nav = new NavClass();
        Encryption enc;
        HtmlElements elements = new HtmlElements();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption();
            Check();
            ImagePofile();
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
        private void ImagePofile()
        {
            saveBtn.ServerClick += delegate
            {
                if (!string.IsNullOrEmpty(inputFile.Value))
                {
                    var n = 0; var In = 0;
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
                        Session["message"] = elements.GetMesage(" Profile image has been updated!", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.MANAGEMENT);
                    }
                    catch (Exception) { }
                }
                else { Session["message"] = elements.GetMesage(" Profile image has been updated!", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.MANAGEMENT); }
                Response.Redirect(nav.PatientPicture);
            };
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
        bool IsEmpty(string txt)
        {
            var k = false;
            if (string.IsNullOrEmpty(txt)) { k = true; }
            return k;
        }
    }
}
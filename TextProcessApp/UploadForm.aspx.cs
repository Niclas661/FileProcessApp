using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextProcessApp
{
    public partial class TestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUploadClick(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["inputFile"];
            //Find better way to read file extension
            String[] fileNames = file.FileName.Split(Convert.ToChar("."));
            if (fileNames[1] == "rtf" || fileNames[1] == "docx" || fileNames[1] == "doc" || fileNames[1] == "txt" || fileNames[1] == "md")
            {
                //check file was submitted
                if (file != null && file.ContentLength > 0)
                {
<<<<<<< HEAD
=======
                    //nothing here checks if file is successfully saved, can cause problems
>>>>>>> origin/master
                    string fname = Path.GetFileName(file.FileName);
                    file.SaveAs(Server.MapPath(Path.Combine("~/Data/", fname)));
                    string redirectURL = "Result.aspx?filename=" + fileNames[0] + "&fileExtension=" + fileNames[1];
                    Response.Redirect(redirectURL);
                }
            }
        }
    }
}
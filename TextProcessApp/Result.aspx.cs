using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextProcessApp
{
    public partial class Result : System.Web.UI.Page
    {
        public string fileName;
        public string fileExtension;

        protected void Page_Load(object sender, EventArgs e)
        {
            fileName = Request.Params["fileName"];
            fileExtension = Request.Params["fileExtension"];

            
        }
    }
}
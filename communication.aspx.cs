using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RemaxWebsite
{
    public partial class communication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUserConnected();

            if (!Page.IsPostBack)
            {

            }
        }

        //Checks if user is connected in Session. if it is the case display the user's name
        protected void CheckUserConnected()
        {
            if (Session["connectedUser"] != null && !string.IsNullOrEmpty(Session["connectedUser"].ToString()))
            {
                string connectedUserName = Session["connectedUser"].ToString();

                // Create an anchor element with the onclick attribute set to call the confirmDisconnect function
                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", "#");
                anchor.Attributes.Add("onclick", "confirmDisconnect();");
                anchor.InnerText = connectedUserName;

                connectedUser.Controls.Add(anchor);
            }
            else
            {
                Response.Redirect("./index.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["connectedUser"] = null;
            Response.Redirect(Request.RawUrl); // Refresh the current page
        }
    }
}
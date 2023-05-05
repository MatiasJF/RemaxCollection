using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RemaxWebsite
{
    public partial class communication : System.Web.UI.Page
    {
        string messageID;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUserConnected();

            if (!Page.IsPostBack)
            {
                messageID = Request.QueryString["contact"];
                communicationIframe.Attributes["src"] = $"message.aspx?id={messageID}&contact={messageID}";
                AllUserMessages();
            }
        }

        //Checks if user is connected in Session. if it is the case display the user's name
        protected void CheckUserConnected()
        {
            if (Session["connectedUser"] != null && !string.IsNullOrEmpty(Session["connectedUser"].ToString()))
            {
                string connectedUserName = Session["connectedUserName"].ToString();

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

        protected void AllUserMessages()
        {
            DataRow connectedUser = (DataRow)Session["connectedUser"];
            int userID = Convert.ToInt32(connectedUser["_id"]); // Replace with the actual user ID
            bool isAgent = Datasource.AgentExists(connectedUser["Email"].ToString()) ? true : false;

            // Replace DataSource with your actual data source class name
            DataTable messages = Datasource.GetLatestMessages(userID, isAgent);

            foreach (DataRow row in messages.Rows)
            {
                string otherUserId = (row["isAgent"].ToString() == "True") ? row["AgentId"].ToString() : row["ClientId"].ToString();
                string truncatedContent = TruncateWithEllipsis(row["Content"].ToString(), 20);
                string cardHtml = $@"
            <div class='message-card' onclick='handleMessageClick({row["MessageID"]}, {otherUserId})'>
                <div class='message-body'>
                    <h4 class='message-sender'>{row["SenderName"]}</h4>
                    <p class='message-content'>{truncatedContent}</p>
                </div>
            </div>";

                Messages.Controls.Add(new LiteralControl(cardHtml));
            }
        }

        public static string TruncateWithEllipsis(string input, int maxLength)
        {
            return string.IsNullOrEmpty(input) ? input :
                   (input.Length <= maxLength) ? input :
                   input.Substring(0, maxLength) + "...";
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["connectedUser"] = null;
            Response.Redirect(Request.RawUrl); // Refresh the current page
        }
    }
}
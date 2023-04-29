using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemaxWebsite
{
    public partial class signUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CheckUserConnected();
            }
        }

        //Checks if user is connected in Session. if it is the case display the user's name
        protected void CheckUserConnected()
        {
            string connectedUserValid = (Session["connectedUser"] != null && !string.IsNullOrEmpty(Session["connectedUser"].ToString()))
                ? Session["connectedUser"].ToString()
                : "sign in";
            connectedUser.Controls.Add(new LiteralControl(connectedUserValid));
        }

        protected void BTN_SignUp_Click(object sender, EventArgs e)
        {
            string firstName = TXT_FirstName.Text;
            string lastName = TXT_LastName.Text;
            string email = TXT_Email.Text;
            string password = TXT_Password.Text;
            string phone = TXT_Phone.Text;

            Client user = new Client(firstName,lastName,email,password,phone);

            // Call the AddUser method from Datasource to add the user to the database
            Datasource.AddUser(user);

            // Optionally, you can perform additional actions or redirect to another page after successful user creation.
            // For example, redirecting to a success page:
            Response.Redirect("loginPage.aspx");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RemaxWebsite;


namespace RemaxWebsite
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUserConnected();

            if (!Page.IsPostBack)
            {
                ShowFilters();
                ProcessRequestQuery();
            }
        }

        //Checks if user is connected in Session. if it is the case display the user's name
        protected void CheckUserConnected()
        {
            if (Session["connectedUser"] != null && !string.IsNullOrEmpty(Session["connectedUser"].ToString()))
            {
                string connectedUserName = Session["connectedUserName"].ToString();

                // Create an anchor element with the onclick attribute set to call the confirmDisconnect function
                // <a href="#" onclick(confirmDisconnect())>CONNECTED_USER_NAME</a>
                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", "#");
                anchor.Attributes.Add("onclick", "confirmDisconnect();");
                anchor.InnerText = connectedUserName;

                connectedUser.Controls.Add(anchor);
            }
            else
            {
                // <a href="#" onclick(confirmDisconnect())>sign in</a>
                connectedUser.Controls.Add(new LiteralControl("sign in"));
            }
        }


        // Process the request query depending on the clicked filter or entered keyword
        // Shows the filtered results if any
        private void ProcessRequestQuery()
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["search"] != null)
                {
                    SearchByKeywords(Request.QueryString["search"].ToString());
                }
                else if (Request.QueryString["where"] != null && Request.QueryString["col"] != null && Request.QueryString["filter"] != null)
                {
                    if (Request.QueryString["where"] == "Houses")
                    {
                        ShowSpecificHouses(Request.QueryString["col"].ToString(), Request.QueryString["filter"].ToString());
                    }
                    else if (Request.QueryString["where"] == "Agents")
                    {
                        ShowSpecificAgents(Request.QueryString["col"].ToString(), Request.QueryString["filter"].ToString());
                    }
                }
                else
                {
                    ShowAllHouses(); // Default display
                }
            }
            else
            {
                ShowAllHouses(); // Default display
            }
        }

        // Show Popular Filter Buttons
        private void ShowFilters()
        {
            mainFilters.Controls.Clear();
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "Type", "Appartement", "Appartements")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "Type", "Bungalo", "Bungalos")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "City", "Montreal", "Montreal Listings")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "Model", "Commercial", "Commercial Houses")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "Model", "Residenciel", "Residencial Houses")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Agents", "City", "Montreal", "Montreal Agents")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Agents", "City", "Laval", "Laval Agents")));
        }


        // Generate The Filter Buttons
        private string GenerateFilterButton(string where, string col, string filter, string buttonText)
        {
            string html = $"<a href='?where={where}&col={col}&filter={filter}' class='btn'>{buttonText}</a>";
            return html.ToString();
        }

        // Shows all Remax Houses
        private void ShowAllHouses()
        {
            mainResults.Controls.Clear();
            // Get all the houses
            HousesList housesList = Datasource.GetAllHouses();
            var houses = housesList.Houses;
            HousesCard(houses);
        }

        // Shows all Remax Agents
        private void ShowAllAgents()
        {
            mainResults.Controls.Clear();
            // Get all the agents
            AgentsList agentsList = Datasource.GetAllAgents();
            var agents = agentsList.Agents;
            AgentCard(agents);
        }

        // Shows Filtered Remax Houses
        private void ShowSpecificHouses(string col, string filter)
        {
            // Gets Houses depending on the column and filter
            HousesList filteredHouses = Datasource.GetHousesByParam(col, filter);
            var houses = filteredHouses.Houses;
            HousesCard(houses);
        }

        // Shows Filtered Remax Agnets
        private void ShowSpecificAgents(string col, string filter)
        {
            // Gets Agents depending on the column and filter
            AgentsList filteredAgent = Datasource.GetAgentsByParam(col, filter);
            var agent = filteredAgent.Agents;
            AgentCard(agent);
        }

        // HTML House Card
        private void HousesCard(Dictionary<string, House>.ValueCollection houses)
        {
            mainResults.Controls.Clear();
            // Loop through the houses and generate HTML code for each card
            foreach (House house in houses)
            {
                string html = $@"
                    <div class='house-card'>
                        <img src='./Assets/images/houses/{house.Image}' alt='{house.CivicNumber}'>
                        <div class='container'>
                            <h4 class='price'>{house.Price:C}</h4>
                            <p class='address'>{house.CivicNumber}</p>
                        </div>
                    </div>
                ";

                // Add the HTML code to the section with ID 'main-results'
                mainResults.Controls.Add(new LiteralControl(html));
            }
        }

        // HTML Agent Card
        private void AgentCard(Dictionary<string, Agent>.ValueCollection agents)
        {
            // Loop through the agents and generate HTML code for each card
            foreach (Agent agent in agents)
            {
                string html = $@"
                    <div class='agent-card'>
                        <div class='container-alt'>
                            <img src='./Assets/images/agents/{agent.Image}' alt='{agent.AgentID}'>
                            <div class='agent-info'>
                                <h4 class='name'>{agent.FirstName} {agent.LastName}</h4>
                                <p class='address'>{agent.Address}</p>
                            </div>
                            <div class='agent-contact'>
                                <a href='./communication.aspx?contact={agent.AgentID}' class='btn' id='{agent.AgentID}_msg' class='agent-message'>Message</a>
                                <button class='btn' class='agent-phone' disabled>{agent.Phone}</button>
                            </div>
                        </div>
                    </div>
                ";

                // Add the HTML code to the section with ID 'main-results'
                mainResults.Controls.Add(new LiteralControl(html));
            }
        }

        protected void FilterProperties(object sender, EventArgs e)
        {
            ShowAllHouses();
            ShowFilters();
        }

        protected void FilterAgents(object sender, EventArgs e)
        {
            ShowAllAgents();
            ShowFilters();
        }

        // Search result and display by keyword 
        protected void SearchByKeywords(string keyword)
        {
            mainResults.Controls.Clear();

            var housesList = Datasource.GetAllHouses();
            var houses = housesList.Houses;
            var filteredHouses = houses.Where(h => h.CivicNumber.ToLower().Contains(keyword.ToLower()) || h.City.ToLower().Contains(keyword.ToLower()) || h.Type.ToLower().Contains(keyword.ToLower()) || h.Model.ToLower().Contains(keyword.ToLower())).ToDictionary(h => h.HouseID, h => h);
            HousesCard(filteredHouses.Values);

            var agentsList = Datasource.GetAllAgents();
            var agents = agentsList.Agents;
            var filteredAgents = agents.Where(a => a.FirstName.ToLower().Contains(keyword.ToLower()) || a.LastName.ToLower().Contains(keyword.ToLower()) || a.City.ToLower().Contains(keyword.ToLower())).ToDictionary(a => a.AgentID, a => a);
            AgentCard(filteredAgents.Values);
        }

        // Logout
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["connectedUser"] = null;
            Response.Redirect(Request.RawUrl); // Refresh the current page
        }

    }
}
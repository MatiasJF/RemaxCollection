using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using RemaxWebsite;


namespace RemaxWebsite
{
    public partial class index : System.Web.UI.Page
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Checks if the QueryString(URL) has any filtered requests
                if (Request.QueryString.Count > 0)
                {
                    filterResults();
                    showFilters();
                }
                else
                {
                    showAllHouses();
                    showFilters();
                }
            }
        }

        private void showFilters()
        {
            // Show Popular Filter Buttons
            mainFilters.Controls.Clear();
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "Type", "Appartement", "Appartements")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "Type", "Bungalo", "Bungalos")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "City", "Montreal", "Montreal Listings")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "Model", "Commercial", "Commercial Houses")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Houses", "Model", "Residenciel", "Residencial Houses")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Agents", "City", "Montreal", "Montreal Agents")));
            mainFilters.Controls.Add(new LiteralControl(GenerateFilterButton("Agents", "City", "Laval", "Laval Agents")));
        }

        private string GenerateFilterButton(string where, string col, string filter, string buttonText)
        {
            // Generate Filter Buttons
            string html = $"<a href='?where={where}&col={col}&filter={filter}' class='btn'>{buttonText}</a>";
            return html.ToString();
        }

        private void showAllHouses()
        {
            mainResults.Controls.Clear();
            // Get all the houses
            HousesList housesList = Datasource.GetAllHouses();
            var houses = housesList.Houses;
            housesCard(houses);
        }

        private void showAllAgents()
        {
            mainResults.Controls.Clear();
            // Get all the agents
            AgentsList agentsList = Datasource.GetAllAgents();
            var agents = agentsList.Agents;
            agentCard(agents);
        }

        private void showSpecificHouses(string col, string filter)
        {
            // Gets Houses depending on the column and filter
            HousesList filteredHouses = Datasource.GetHousesByParam(col, filter);
            var houses = filteredHouses.Houses;
            housesCard(houses);
        }
        private void showSpecificAgents(string col, string filter)
        {
            // Gets Agents depending on the column and filter
            AgentsList filteredAgent = Datasource.GetAgentsByParam(col, filter);
            var agent = filteredAgent.Agents;
            agentCard(agent);
        }

        private void housesCard(Dictionary<string,House>.ValueCollection houses)
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

        private void agentCard(Dictionary<string, Agent>.ValueCollection agents)
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
                                <button class='btn' id='{agent.AgentID}_msg' class='agent-message'>Message</button>
                                <button class='btn' class='agent-phone' disabled>{agent.Phone}</button>
                            </div>
                        </div>
                    </div>
                ";

                // Add the HTML code to the section with ID 'main-results'
                mainResults.Controls.Add(new LiteralControl(html));
            }
        }

      

        protected void filterProperties(object sender, EventArgs e)
        {
            showAllHouses();
            showFilters();
        }

        protected void filterAgents(object sender, EventArgs e)
        {
            showAllAgents();
            showFilters();
        }

        protected void filterResults()
        {
            if (Request.QueryString["where"] == "Houses")
            {
                showSpecificHouses(Request.QueryString["col"].ToString(), Request.QueryString["filter"].ToString());
            }
            if (Request.QueryString["where"] == "Agents")
            {
                showSpecificAgents(Request.QueryString["col"].ToString(), Request.QueryString["filter"].ToString());
            }
            else
            {
                showAllHouses();
                showFilters();
            }
        }
    }
}
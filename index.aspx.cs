using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using RemaxWebsite;


namespace RemaxWebsite
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    filterSpecificProperties();
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
            mainFilters.Controls.Clear();
            string html = $@"
                <p style='display: flex;align-items: center;gap: 4px;'>
                    Popular searches 
                    <span>
                        <svg width='20' height='20' fill='currentColor' viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'>
                            <path d='M15.755 14.255h-.79l-.28-.27a6.471 6.471 0 0 0 1.57-4.23 6.5 6.5 0 1 0-6.5 6.5c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99 1.49-1.49-4.99-5Zm-6 0c-2.49 0-4.5-2.01-4.5-4.5s2.01-4.5 4.5-4.5 4.5 2.01 4.5 4.5-2.01 4.5-4.5 4.5Z'></path>
                        </svg>
                    </span>
                </p>
                <br />
                <div class='filters'>
                    <a href='?where=Houses&col=Type&filter=Appartement' class='btn'>Appartements</a>
                    <a href='?where=Houses&col=Type&filter=Bungalo' class='btn'>Bungalo</a>
                    <a href='?where=Houses&col=City&filter=Montreal' class='btn'>Montreal</a>
                    <a href='?where=Houses&col=Model&filter=Residenciel' class='btn'>Residenciel</a>
                    <a href='?where=Houses&col=Model&filter=Commercial' class='btn'>Commercial</a>
                    <a href='?where=Agents&col=City&filter=Montreal' class='btn'>Montreal Agents</a>
                    <a href='?where=Agents&col=City&filter=Laval' class='btn'>Laval Agents</a>
                </div>
            ";
            mainFilters.Controls.Add(new LiteralControl(html));
        }


        protected void showAllHouses()
        {
            mainResults.Controls.Clear();
            // Get all the houses
            HousesList housesList = Datasource.GetAllHouses();
            var houses = housesList.Houses;
            housesCard(houses);
        }

        protected void showSpecificHouses(string col, string filter)
        {
            HousesList filteredHouses = Datasource.GetHousesByParam(col, filter);
            var houses = filteredHouses.Houses;
            housesCard(houses);
        }
        protected void showSpecificAgents(string col, string filter)
        {
            AgentsList filteredAgent = Datasource.GetAgentsByParam(col, filter);
            var agent = filteredAgent.Agents;
            agentCard(agent);
        }

        protected void housesCard(Dictionary<string,House>.ValueCollection houses)
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

                // Add the HTML code to the section with class 'main-results'
                mainResults.Controls.Add(new LiteralControl(html));
            }
        }

        protected void agentCard(Dictionary<string, Agent>.ValueCollection agents)
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
                                <button class='btn' class='agent-phone'>{agent.Phone}</button>
                            </div>
                        </div>
                    </div>
                ";

                // Add the HTML code to the section with class 'main-results'
                mainResults.Controls.Add(new LiteralControl(html));
            }
        }

        protected void ShowAgentsCards()
        {
            mainResults.Controls.Clear();
            // Get all the agents
            AgentsList agentsList = Datasource.GetAllAgents();
            var agents = agentsList.Agents;
            agentCard(agents);
        }

        protected void filterProperties(object sender, EventArgs e)
        {
            showAllHouses();
            showFilters();
        }

        protected void filterAgents(object sender, EventArgs e)
        {
            ShowAgentsCards();
            showFilters();
        }

        protected void filterSpecificProperties()
        {
            if (Request.QueryString["where"] == "Houses")
            {
                showSpecificHouses(Request.QueryString["col"].ToString(), Request.QueryString["filter"].ToString());
            }
            if (Request.QueryString["where"] == "Agents")
            {
                showSpecificAgents(Request.QueryString["col"].ToString(), Request.QueryString["filter"].ToString());
            } 
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxWebsite
{
    public class AgentsList
    {
        protected Dictionary<string, Agent> _AgentDicitonary;

        public AgentsList()
        {
            _AgentDicitonary = new Dictionary<string, Agent>();
        }

        public int NombreDeClients
        {
            get => this._AgentDicitonary.Count();
        }

        public Dictionary<string, Agent>.ValueCollection Agents
        {
            get => this._AgentDicitonary.Values;
        }

        public bool Add(Agent Agent)
        {
            if (this._AgentDicitonary.ContainsKey(Agent.AgentID) == false)
            {
                _AgentDicitonary.Add(Agent.AgentID, Agent);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Agent Find(string AgentID)
        {
            return _AgentDicitonary.ContainsKey(AgentID) ? _AgentDicitonary[AgentID] : null;
        }

        public string ShowClients()
        {
            string allClients = string.Empty;

            foreach (Agent Client in Agents)
            {
                allClients += Client.ShowInfo() + "</br>";
            }

            return allClients;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxWebsite
{
    public class Company
    {
        // Remax company menagement class
        //-------------------------------
        // Author        : Matan Dessaur
        // Date created  : 20/03/2023
        // Date modified : 01/04/2023
        //-------------------------------

        protected string _Name;
        protected string _Address;
        protected string _City;
        protected string _PostalCode;
        protected string _Province;
        protected string _Country;
        protected string _Phone;
        protected string _Fax;
        protected AgentsList _Agents;

        public Company()
        {
            this._Name =
            this._Address =
            this._City =
            this._PostalCode =
            this._Province =
            this._Country =
            this._Phone =
            this._Fax =
            "n/a";

            this._Agents = new AgentsList();
        }

        public Company
            (
            string Name,
            string Address,
            string City,
            string PostalCode,
            string Province,
            string Country,
            string Phone,
            string Fax
            )
        {
            this._Name = Name;
            this._Address = Address;
            this._City = City;
            this._PostalCode = PostalCode;
            this._Province = Province;
            this._Country = Country;
            this._Phone = Phone;
            this._Fax = Fax;

            this._Agents = new AgentsList();
        }

        public Company
           (
           string Name,
           string Address,
           string City,
           string PostalCode,
           string Province,
           string Country,
           string Phone,
           string Fax,
           AgentsList Agents
           )
        {
            this._Name = Name;
            this._Address = Address;
            this._City = City;
            this._PostalCode = PostalCode;
            this._Province = Province;
            this._Country = Country;
            this._Phone = Phone;
            this._Fax = Fax;

            this._Agents = Agents;
        }

        public String Name
        {
            get => this._Name;
            set => this._Name = value;
        }
        public String Address
        {
            get => this._Address;
            set => this._Address = value;
        }
        public String City
        {
            get => this._City;
            set => this._City = value;
        }
        public String PostalCode
        {
            get => this._PostalCode;
            set => this._PostalCode = value;
        }
        public String Province
        {
            get => this._Province;
            set => this._Province = value;
        }
        public String Country
        {
            get => this._Country;
            set => this._Country = value;
        }
        public String Phone
        {
            get => this._Phone;
            set => this._Phone = value;
        }
        public String Fax
        {
            get => this._Fax;
            set => this._Fax = value;
        }

        public AgentsList Agents
        {
            get => this._Agents;
        }

        public string ShowInfo()
        {
            string CompInfo = string.Empty;
            string nextLine = "<br />";

            CompInfo += $"Name         : {_Name}" + nextLine;
            CompInfo += $"Address      : {_Address}" + nextLine;
            CompInfo += $"City         : {_City}" + nextLine;
            CompInfo += $"PostalCode   : {_PostalCode}" + nextLine;
            CompInfo += $"Province     : {_Province}" + nextLine;
            CompInfo += $"Country      : {_Country}" + nextLine;
            CompInfo += $"Phone        : {_Phone}" + nextLine;
            CompInfo += $"Fax          : {_Fax}" + nextLine;
            CompInfo += $"Agents de la compagnie :  " + nextLine;
            CompInfo += $"------------------------------------" + nextLine;
            foreach (Agent agent in _Agents.Agents)
            {
                CompInfo += agent.ShowInfo() + "</br>";
            }

            return CompInfo;
        }

        public string ShowAllClients()
        {
            string allClients = string.Empty;

            foreach (Agent agents in _Agents.Agents)
            {
                allClients += agents.Clients.ShowClients() + "</br>";
            }

            return allClients;
        }

        public string ShowAllHouses()
        {
            string allHouses = string.Empty;

            foreach (Agent agents in _Agents.Agents)
            {
                foreach(Client client in agents.Clients.Clients)
                {
                    allHouses += client.Houses.ShowHouses() + "</br>";
                }
            }

            return allHouses;
        }

        public string AfficherTousAgents()
        {
            string AllAgents = string.Empty;
            foreach (Agent agent in _Agents.Agents)
            {
                AllAgents += agent.ShowInfo() + "</br>";
            }

            return AllAgents;
        }
    }
}
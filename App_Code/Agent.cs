using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxWebsite
{
    public class Agent
    {
        // Remax agents menagement class
        //-------------------------------
        // Author        : Matan Dessaur
        // Date created  : 20/03/2023
        // Date modified : 01/04/2023
        //-------------------------------

        protected string _id;
        protected string _FirstName;
        protected string _LastName;
        protected string _Email;
        protected string _Nip;
        protected string _Phone;
        protected string _Address;
        protected string _City;
        protected string _image;
        protected ClientsList _Clients;

        public Agent()
        {
            this._id =
            this._FirstName =
            this._LastName =
            this._Email =
            this._Nip =
            this._Phone =
            this._Address =
            this._City =
            this._image =
            "n/a";

            this._Clients = new ClientsList();
        }

        public Agent(string ClientID)
        {
            this._id = ClientID;
            this._FirstName =
            this._LastName =
            this._Email =
            this._Nip =
            this._Phone =
            this._Address =
             this._City =
            this._image =
            "n/a";

            this._Clients = new ClientsList();
        }

        public Agent(string AgentID, string FirstName, string LastName, string Email, string Nip, string Phone, string Address, string City, string image, ClientsList Clients)
        {
            this._id = AgentID;
            this._FirstName = FirstName;
            this._LastName = LastName;
            this._Email = Email;
            this._Nip = Nip;
            this._Phone = Phone;
            this._Address = Address;
            this._City = City;
            this._image = image;
            this._Clients = Clients;
        }

        public Agent(string AgentID, string FirstName, string LastName, string Email, string Nip, string Phone, string Address, string City, string image)
        {
            this._id = AgentID;
            this._FirstName = FirstName;
            this._LastName = LastName;
            this._Email = Email;
            this._Nip = Nip;
            this._Phone = Phone;
            this.Address = Address;
            this._City = City;
            this._image = image;
            this._Clients = new ClientsList();
        }

        public String AgentID
        {
            get =>  this._id;
            set => this._id = value;
        }
        public String FirstName
        {
            get => this._FirstName; 
            set => this._FirstName = value;
        }
        public String LastName
        {
            get => this._LastName;
            set => this._LastName = value;
        }
        public string Email
        {
            get => this._Email;
            set => this._Email = value;
        }
        public String Nip
        {
            get => this._Nip; 
            set => this._Nip = value;
        }
        public String Phone
        {
            get => this._Phone; 
            set => this._Phone = value;
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
        public String Image
        {
            get => this._image;
            set => this._image = value;
        }
        public ClientsList Clients
        {
            get => this._Clients;
        }


        public void Hire(string AgentID, string FirstName, string LastName, string Email, string Nip, string Phone)
        {
            this._id = AgentID;
            this._FirstName = FirstName;
            this._LastName = LastName;
            this._Email = Email;
            this._Nip = Nip;
            this._Phone = Phone;
            this._Clients = new ClientsList();
        }

        public string ShowAllHouses()
        {
            string allHouses = string.Empty;

            foreach (Client client in this._Clients.Clients)
            {
                allHouses += client.Houses.ShowHouses() + "</br>";
            }

            return allHouses;
        }

        public string ShowInfo()
        {
            string AgentInfo = string.Empty;
            string nextLine = "<br />";

            AgentInfo += $"AgentID         : {this._id}"+ nextLine;
            AgentInfo += $"FirstName        : {this._FirstName}" + nextLine;
            AgentInfo += $"LastName         : {this._LastName}" + nextLine;
            AgentInfo += $"Email            : {this._Email}" + nextLine;
            AgentInfo += $"Phone            : {this._Phone}" + nextLine;
            AgentInfo += $"Clients de Agent :  " + nextLine;
            AgentInfo += $"------------------------------------" + nextLine;
            AgentInfo += this._Clients.ShowClients();

            return AgentInfo;
        }


    }
}
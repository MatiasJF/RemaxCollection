using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxWebsite
{
    public class ClientsList
    {
        protected Dictionary<string, Client> _ClientsDictionary;

        public ClientsList()
        {
            _ClientsDictionary = new Dictionary<string, Client>();
        }

        public int NombreDeClients
        {
            get => this._ClientsDictionary.Count();
        }

        public Dictionary<string, Client>.ValueCollection Clients
        {
            get => this._ClientsDictionary.Values;
        }

        public bool Add(Client Client)
        {
            if (this._ClientsDictionary.ContainsKey(Client.ClientID) == false)
            {
                _ClientsDictionary.Add(Client.ClientID, Client);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Client Find(string ClientID)
        {
            return _ClientsDictionary.ContainsKey(ClientID) ? _ClientsDictionary[ClientID] : null;
        }

        public string ShowClients()
        {
            string allClients = string.Empty;

            foreach (Client Client in this.Clients)
            {
                allClients += Client.ShowInfo();
            }

            return allClients;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxWebsite
{
    public class Client
    {
        // Remax clients menagement class
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
        //--typeof CLient test
        protected bool _isSeller;
        protected bool _isBuyer;
        //--------------------
        protected HousesList _Houses;

        public Client()
        {
            this._id =
            this._FirstName =
            this._LastName =
            this._Email =
            this._Nip =
            this._Phone 
            = "n/a";

            this._Houses = new HousesList();
        }

        public Client(string ClientID)
        {
            this._id = ClientID;
            this._FirstName =
            this._LastName =
            this._Email =
            this._Nip =
            this._Phone
            = "n/a";

            this._Houses = new HousesList();
        }

        public Client
            (
            string ClientID,
            string FirstName,
            string LastName,
            string Email,
            string Nip,
            string Phone,
            HousesList Houses
            )
        {
            this._id = ClientID;
            this._FirstName = FirstName;
            this._LastName = LastName;
            this._Email = Email;
            this._Nip = Nip;
            this._Phone = Phone;
            this._Houses = Houses;
        }

        public Client
            (
            string ClientID,
            string FirstName,
            string LastName,
            string Email,
            string Nip,
            string Phone
            )
        {
            this._id = ClientID;
            this._FirstName = FirstName;
            this._LastName = LastName;
            this._Email = Email;
            this._Nip = Nip;
            this._Phone = Phone;
            this._Houses = new HousesList();
        }


        public String ClientID
        {
            get => this._id;
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

        public String Email
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

        public HousesList Houses 
        {
         get => this._Houses; 
         set => this._Houses = value;
        }

        public void Subscribe
            (
            string ClientID,
            string FirstName,
            string LastName,
            string Email,
            string Nip,
            string Phone
            )
        {
            this._id = ClientID;
            this._FirstName = FirstName;
            this._LastName = LastName;
            this._Email = Email;
            this._Nip = Nip;
            this._Phone = Phone;
            this._Houses = Houses;
        }

        public void MakeSeller()
        {
            this._isSeller = (!this._isSeller) ? true : false;
        }
        public void MakeBuyer()
        {
            this._isBuyer = (!this._isBuyer) ? true : false;
        }


        public string ShowInfo()
        {
            string ClientInfo = string.Empty;
            string nextLine = "<br />";

            ClientInfo += $"ClientID         : {this._id}" + nextLine;
            ClientInfo += $"FirstName        : {this._FirstName}" + nextLine;
            ClientInfo += $"LastName         : {this._LastName}" + nextLine;
            ClientInfo += $"Email            : {this._Email}" + nextLine;
            ClientInfo += $"Phone            : {this._Phone}"+ nextLine;
            ClientInfo += $"Buyer            : {this._isBuyer}" + nextLine;
            ClientInfo += $"Seller           : {this._isSeller}" + nextLine;
            ClientInfo += $"Maisons du client:  " + nextLine;
            ClientInfo += $"------------------------------------" + nextLine;
            ClientInfo += this._Houses.ShowHouses();

            return ClientInfo;
        }
    }
}
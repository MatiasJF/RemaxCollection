using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxWebsite
{
    public class House
    {
        // Remax houses menagement class
        //-------------------------------
        // Author        : Matan Dessaur
        // Date created  : 20/03/2023
        // Date modified : 20/03/2023
        //-------------------------------

        protected string  _id;       //House ID --autoincrements
        protected string _CivicNumber;   //House Number
        protected string _Type;          //Ex: Bungalo
        protected string _Model;         //Ex: Commercial
        protected string _Country;
        protected string _Province;
        protected string _City;
        protected string _PostalCode;
        protected Decimal _CurrentPrice;  //Ex: $573'000


        public House()
        {
            this._id =
            this._CivicNumber =
            this._Type =
            this._Model =
            this._Country =
            this._Province =
            this._City =
            this._PostalCode =
            "n/a";

            this._CurrentPrice = 0;
    }

        public House(string Number) 
        {
            this._id = Number;
            this._CivicNumber =
            this._Type =
            this._Model =
            this._Country =
            this._Province =
            this._City =
            this._PostalCode =
            "n/a";

            this._CurrentPrice = 0;
        }

        public House
            (
            string Number, 
            string CivicNumber, 
            string Type, 
            string Model, 
            string Country,
            string Province, 
            string City, 
            string PostalCode, 
            Decimal CurrentPrice
            )
        {
            this._id = Number;
            this._CivicNumber = CivicNumber;
            this._Type = Type;
            this._Model = Model;
            this._Country = Country;
            this._Province = Province;
            this._City = City;
            this._PostalCode = PostalCode;
            this._CurrentPrice = CurrentPrice;
        }

        public House
            (
            string Number,
            string CivicNumber,
            string Country,
            string Province,
            string City,
            string Street,
            string PostalCode
            )
        {
            this._id = Number;
            this._CivicNumber = CivicNumber;
            this._Country = Country;
            this._Province = Province;
            this._City = City;
            this._PostalCode = PostalCode;
        }

       public String HouseID
        {
            get => this._id;
        }

        public string CivicNumber
        {
            get => this._CivicNumber; 
            set 
            { 
                this._CivicNumber = value; 
            }
        }

        public String Type
        {
            get => this._Type;
            set
            {
                this._Type = value;
            }
        }

        public String Model
        {
            get => this._Model;
            set
            {
                this._Model = value;
            }
        }

        public String Country
        {
            get => this._Country; 
            set
            {
                this._Country = value;
            }
        }

        public String Province
        {
            get => this._Province; 
            set
            {
                this._Province = value;
            }
        }

        public String City
        {
            get => this._City;
            set
            {
                this._City = value;
            }
        }

        public String PostalCode
        {
            get => this._PostalCode;
            set
            {
                this.PostalCode = value;
            }
        }

        public Decimal Price
        {
            get => this._CurrentPrice; 
            set
            {
                this._CurrentPrice = value;
            }
        }

        public void Subscribe
             (
             string Number,
             string CivicNumber,
             string Type,
             string Model,
             string Country,
             string Province,
             string City,
             string Street,
             string PostalCode,
             Decimal CurrentPrice
             )
        {
            this._id = Number;
            this._CivicNumber = CivicNumber;
            this._Type = Type;
            this._Model = Model;
            this._Country = Country;
            this._Province = Province;
            this._City = City;
            this._PostalCode = PostalCode;
            this._CurrentPrice = CurrentPrice;
        }

        public string ShowInfo()
        {
            string houseInfo = string.Empty;
            string nextLine = "<br />";

            houseInfo += $"Numero           : {this._id}"+ nextLine;
            houseInfo += $"Numero Civique   : {this._CivicNumber}" + nextLine;
            houseInfo += $"Type             : {this._Type}" + nextLine;
            houseInfo += $"Modele           : {this._Model}" + nextLine;
            houseInfo += $"Pays             : {this._Country}" + nextLine;
            houseInfo += $"Province         : {this._Province}" + nextLine;
            houseInfo += $"Ville            : {this._City}" + nextLine;
            houseInfo += $"Code Postale     : {this._PostalCode.ToUpper()}" + nextLine;
            houseInfo += $"Prix             : {this._CurrentPrice}$" + nextLine;

            return houseInfo;
        }

    }
}
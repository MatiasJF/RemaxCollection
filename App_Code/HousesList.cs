using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemaxWebsite
{
    public class HousesList
    {
        protected Dictionary<string, House> _HousesDictionary;

        public HousesList()
        {
            _HousesDictionary = new Dictionary<string, House>();
        }

        public int NombreDeMaisons
        {
            get => this._HousesDictionary.Count();
        }

        public Dictionary<string, House>.ValueCollection Houses
        {
            get => this._HousesDictionary.Values;
        }

        public bool Add(House House) 
        {
            if (this._HousesDictionary.ContainsKey(House.HouseID) == false)
            {
                _HousesDictionary.Add(House.HouseID, House);
                return true;
            }
            else
            {
                return false;
            } 
        }

        public House Find(string HouseNumber)
        {
            return _HousesDictionary.ContainsKey(HouseNumber) ? _HousesDictionary[HouseNumber] : null;
        }

        public string ShowHouses()
        {
            string allHouses = string.Empty;

            foreach(House House in this.Houses)
            {
                allHouses += House.ShowInfo();
            }

            return allHouses;
        }
    }
}
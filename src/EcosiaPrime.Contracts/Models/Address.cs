using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosiaPrime.Contracts.Models
{
    public class Address
    {
        private string _country;
        private string _state;
        private string _postCode;
        private string _city;
        private string _streetNumber;
        private string _street;

        public string GetCountry()
        {
            return this._country;
        }
        public void SetCountry(string country)
        {
            this._country = country;
        }

        public string GetState()
        {
            return this._state;
        }

        public void SetState(string state)
        {
            this._state = state;
        }

        public string GetPostCode()
        {
            return this._postCode;
        }

        public void SetPostCode(string postCode)
        {
            this._postCode = postCode;
        }

        public string GetCity()
        {
            return this._city;
        }

        public void SetCity(string city)
        {
            this._city = city;
        }

        public string GetStreetNumber()
        {
            return this._streetNumber;
        }

        public void SetStreetNumber(string streetNumber)
        {
            this._streetNumber = streetNumber;
        }

        public string GetStreet()
        {
            return this._street;
        }

        public void SetStreet(string street)
        {
            this._street = street;
        }
    }
}

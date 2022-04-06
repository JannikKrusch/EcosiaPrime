using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosiaPrime.Contracts.Models
{
    public class Client
    {
        private string _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private Address _address;
        private Subscription _subscription;

        public string GetId()
        {
            return this._id;
        }

        public void SetId(string id)
        {
            this._id = id;
        }

        public string GetFirstname()
        {
            return this._firstName;
        }

        public void SetFirstName(string firstName)
        {
            this._firstName = firstName;
        }

        public string GetLastname()
        {
            return this._lastName;
        }

        public void SetLastName(string lastName)
        {
            this._lastName = lastName;
        }

        public string GetEmail()
        {
            return this._email;
        }

        public void SetEmail(string email)
        {
            this._email = email;
        }

        public string GetPassword()
        {
            return this._password;
        }

        public void SetPassword(string password)
        {
            this._password = password;
        }

        public Address GetAddress()
        {
            return this._address;
        }

        public void SetAddress(Address address)
        {
            this._address = address;
        }

        public Subscription GetSubscription()
        {
            return this._subscription;
        }

        public void SetSubscription(Subscription subscription)
        {
            this._subscription = subscription;
        }
    }
}

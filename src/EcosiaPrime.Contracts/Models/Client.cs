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
    }
}

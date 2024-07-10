using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectoryApp
{
    public class PhoneEntry
    {
        private string Name{get; set;}
        private string PhoneNumber{get; set;}

        public PhoneEntry(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetPhoneNumber()
        {
            return PhoneNumber;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
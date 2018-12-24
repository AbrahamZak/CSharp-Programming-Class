using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAddressBook
{
    public class PersonEntry
    {
        public String name;
        public String email;
        public String phone;

        public PersonEntry(String nameInput, String emailInput, String phoneInput)
        {
            name = nameInput;
            email = emailInput;
            phone = phoneInput;
        }
    }
}

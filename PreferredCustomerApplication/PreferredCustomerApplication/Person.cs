using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferredCustomerApplication
{
    //Person class that contains a name, email, and phone
    public class Person
    {
        public String name;
        public String address;
        public String phone;

        public Person(String nameInput, String addressInput, String phoneInput)
        {
            this.name = nameInput;
            this.address = addressInput;
            this.phone = phoneInput;
        }

    }
}

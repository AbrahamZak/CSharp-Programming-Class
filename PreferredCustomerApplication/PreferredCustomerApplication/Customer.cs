using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferredCustomerApplication
{
    //A customer class that derives from a person class that contains name, email, phone, mailing status, and an id
    public class Customer : Person
    {
        public Boolean mailing;
        public int id;
        public static int idNum = 0;

        public Customer(String nameInput, String addressInput, String phoneInput, Boolean isMailing) : base (nameInput, addressInput, phoneInput)
        {
            this.name = nameInput;
            this.address = addressInput;
            this.phone = phoneInput;
            this.mailing = isMailing;
            this.id = idNum++;
        }
    }
}

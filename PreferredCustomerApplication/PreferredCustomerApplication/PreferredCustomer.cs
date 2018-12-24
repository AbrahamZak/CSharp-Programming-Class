using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferredCustomerApplication
{
    //Prefered customer class that tracks a customer's purchase history and discount level
    class PreferredCustomer : Customer
    {
        public int level;
        public double total;

        public PreferredCustomer(String nameInput, String addressInput, String phoneInput, Boolean isMailing, double totalPurchase) : base(nameInput, addressInput, phoneInput, isMailing)
        {
            this.name = nameInput;
            this.address = addressInput;
            this.phone = phoneInput;
            this.mailing = isMailing;
            this.id = Customer.idNum++;
            this.level = 0;
            this.total = totalPurchase;
            if (this.total >= 500)
            {
                this.level = 1;
            }
            if (this.total >= 1000)
            {
                this.level = 2;
            }
            if (this.total >= 1500)
            {
                this.level = 3;
            }
            if (this.total >= 2000)
            {
                this.level = 4;
            }
        }

        //Calculate and return the discount
        public int discount()
        {
            if (this.level == 0)
            {
                return 0;
            }
            if (this.level == 1)
            {
                return 5;
            }
            if (this.level == 2)
            {
                return 6;
            }
            if (this.level == 3)
            {
                return 7;
            }
            if (this.level == 4)
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentShopLibrary
{
    public class Vendor
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Commission { get; set; }

        public decimal PaymentDue { get; set; }
        public Vendor()
        {
            this.Commission = 0.5;

        }

        public string Display
        {
            get
            {
                return string.Format("{0} {1} - {2:C2}", this.FirstName, this.LastName, this.PaymentDue);
            }
        }
    }
}

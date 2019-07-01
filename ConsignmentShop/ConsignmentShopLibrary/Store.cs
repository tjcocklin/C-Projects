using System;
using System.Collections.Generic;
using System.Text;

namespace ConsignmentShopLibrary
{
    public class Store
    {
        public string Name { get; set; }
        public List<Vendor> ListOfVendors { get; set; }
        public List<Item> ListOfItems { get; set; }

        public Store()
        {
            this.ListOfVendors = new List<Vendor>();
            this.ListOfItems = new List<Item>();   

        }
    }
}

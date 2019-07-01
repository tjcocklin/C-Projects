using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsignmentShopLibrary;

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private Store store1 = new Store();
        private List<Item> shoppingCart = new List<Item>();
        private decimal storeProfit = 0;

        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorsBinding = new BindingSource();

        

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();
            // interesting fact bool are initial as false by default.
            itemsBinding.DataSource = store1.ListOfItems.Where(item => item.Sold == false).ToList();
            itemsListBox.DataSource = itemsBinding;
                                   
            itemsListBox.DisplayMember = "Display";
            itemsListBox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCart;
            shoppingCartListBox.DataSource = cartBinding;

            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";

            vendorsBinding.DataSource = store1.ListOfVendors;
            vendorListBox.DataSource = vendorsBinding;

            vendorListBox.DisplayMember= "Display";
            vendorListBox.ValueMember = "Display";
        }
        private void SetupData()
        {
            store1.ListOfVendors.Add(new Vendor { FirstName = "Bill", LastName = "Williams"});
            store1.ListOfVendors.Add(new Vendor { FirstName = "Sue", LastName = "Jones" });


            store1.ListOfItems.Add(new Item
            {
                Title = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,
                Owner = store1.ListOfVendors[0]
            });
                        
            store1.ListOfItems.Add(new Item
            {
                Title = "A Tale of Two Cities",
                Description = "A book about a Revolution",
                Price = 3.80M,
                Owner = store1.ListOfVendors[1]
            });

            store1.ListOfItems.Add(new Item
            {
                Title = "Harry Potter",
                Description = "A book about a boy",
                Price = 5.20M,
                Owner = store1.ListOfVendors[1]
            });

            store1.ListOfItems.Add(new Item
            {
                Title = "Jane Eyre",
                Description = "A book about a girl",
                Price = 1.50M,
                Owner = store1.ListOfVendors[0]
            });

            store1.Name = "Seconds are Better";
        }

        private void AddToCart_Click(object sender, EventArgs e)
        {
          Item highLighted = (Item) itemsListBox.SelectedItem;
          shoppingCart.Add(highLighted);

          cartBinding.ResetBindings(false);
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            foreach(Item item in shoppingCart)
            {
                item.Sold = true;
                item.Owner.PaymentDue += item.Price * (decimal) item.Owner.Commission;
                storeProfit += item.Price * (1 - (decimal)item.Owner.Commission);

            }
                  
            

            shoppingCart.Clear();

            itemsBinding.DataSource = store1.ListOfItems.Where(item => item.Sold == false).ToList();
            storeProfitValue.Text = string.Format("{0:C2}", storeProfit);
            
            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorsBinding.ResetBindings(false);
        }
    }
}

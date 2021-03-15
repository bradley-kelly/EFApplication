using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Customers : Form
    {
        readonly CustomerDataContext customerDataContext = new CustomerDataContext();
        public Customers()
        {
            InitializeComponent();
            GetCustomers();
        }
        private void EditAddressButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataRow = customerDataGrid.CurrentRow;
            var editAddress = new Address(dataRow, customerDataContext);
            editAddress.ShowDialog();
        }
        private void EditCustomerButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataRow = customerDataGrid.CurrentRow;
            var editCustomer = new Customer(dataRow, customerDataContext);
            editCustomer.ShowDialog();
        }
        public void GetCustomers()
        {
            customerDataGrid.DataSource = (from Customer in customerDataContext.Customers join Address in customerDataContext.Addresses on Customer.CustomerId equals Address.CustomerId select new { CustomerID = Customer.CustomerId, Firstname = Customer.Firstname, Lastname = Customer.Lastname, AddressID = Address.AddressId, Street = Address.Street, City = Address.City, State = Address.State, Zip = Address.Zip }).ToList();
        }
    }
}
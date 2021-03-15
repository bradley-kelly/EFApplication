using Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Address : Form
    {
        readonly DataGridViewRow dataRow;
        readonly CustomerDataContext customerDataContext;
        public Address(DataGridViewRow DataRow, CustomerDataContext CustomerDataContext)
        {
            InitializeComponent();
            dataRow = DataRow;
            customerDataContext = CustomerDataContext;
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var updateAddress = customerDataContext.Addresses.Find(dataRow.Cells["AddressID"].Value);

            updateAddress.Street = streetBox.Text;
            updateAddress.City = cityBox.Text;
            updateAddress.State = stateBox.Text;
            updateAddress.Zip = zipBox.Text;
            customerDataContext.SaveChanges();
            Application.OpenForms.OfType<Customers>().FirstOrDefault().GetCustomers();
            this.Close();
        }
        private void Address_Load(object sender, EventArgs e)
        {
            streetBox.Text = dataRow.Cells["Street"].Value.ToString();
            cityBox.Text = dataRow.Cells["City"].Value.ToString();
            stateBox.Text = dataRow.Cells["State"].Value.ToString();
            zipBox.Text = dataRow.Cells["Zip"].Value.ToString();
        }
    }
}
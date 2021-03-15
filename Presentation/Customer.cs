using Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Customer : Form
    {
        readonly DataGridViewRow dataRow;
        readonly CustomerDataContext customerDataContext;
        public Customer(DataGridViewRow DataRow, CustomerDataContext CustomerDataContext)
        {
            InitializeComponent();
            customerDataContext = CustomerDataContext;
            dataRow = DataRow;
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var Parameters = new[]
            {
                new SqlParameter("Firstname", firstNameBox.Text),
                new SqlParameter("CustomerID", dataRow.Cells["CustomerID"].Value)
            };

            customerDataContext.Database.ExecuteSqlRaw("EXECUTE updateCustomers @Firstname, @CustomerID", Parameters);
            Application.OpenForms.OfType<Customers>().FirstOrDefault().GetCustomers();
            this.Close();
        }
        private void Customer_Load(object sender, EventArgs e)
        {
            firstNameBox.Text = dataRow.Cells["Firstname"].Value.ToString();
            lastNameBox.Text = dataRow.Cells["Lastname"].Value.ToString();
        }
    }
}
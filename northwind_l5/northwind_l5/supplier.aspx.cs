using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace northwind_l5
{
    public partial class supplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                getSupplier();
            }
        }

        protected void getSupplier()
        {
            //create an instance of our supplier class
            BusinessRules.CSupplier objSupplier = new BusinessRules.CSupplier();

            //pass the id from the url to the supplier class
            objSupplier.SupplierID = Convert.ToInt32(Request.QueryString["SupplierID"]);

            //call the getSupplier method of our class
            objSupplier.getSupplier();

            //populate the company name on our form
            txtCompanyName.Text = objSupplier.CompanyName;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //create an instance of our supplier class
            BusinessRules.CSupplier objSupplier = new BusinessRules.CSupplier();

            //populate the properties of the supplier object
            objSupplier.SupplierID = Convert.ToInt32(Request.QueryString["SupplierID"]);
            objSupplier.CompanyName = txtCompanyName.Text;

            //process the save operation
            objSupplier.saveSupplier();

            Response.Redirect("suppliers.aspx", false);
        }
    }
}
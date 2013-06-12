using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace northwind_l5
{
    public partial class suppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                getSuppliers();
            }
        }

        protected void getSuppliers()
        { 
            //instantiate an instance of the supplier class
           BusinessRules.CSupplier objSupplier = new BusinessRules.CSupplier();

        //call the get suppliers function and bind the datareader result to the grid
           gvSuppliers.DataSource = objSupplier.getSuppliers();
           gvSuppliers.DataBind();
        }

        protected void gvSuppliers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //call delete
            BusinessRules.CSupplier objSupplier = new BusinessRules.CSupplier();

            //Fill the supplier id of our object
            objSupplier.SupplierID = Convert.ToInt32(gvSuppliers.DataKeys[e.RowIndex].Values["SupplierID"]);

            // Call the delete function
            objSupplier.deleteSupplier();

            // Update the grid
            getSuppliers();
        }

        protected void gvSuppliers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // This event fires as each row is added  to the grip
            e.Row.Cells[3].Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }
}
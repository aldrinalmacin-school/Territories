using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace northwind_l5
{
    public partial class territories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                getTerritories();
            }

        }

        protected void getTerritories()
        {
            //instantiate an instance of the supplier class
            BusinessRules.CTerritory objTerritory = new BusinessRules.CTerritory();

            //call the get suppliers function and bind the datareader result to the grid
            gvTerritories.DataSource = objTerritory.getTerritories();
            gvTerritories.DataBind();
        }

        protected void gvTerritories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //call delete
            BusinessRules.CTerritory objTerritory = new BusinessRules.CTerritory();

            //Fill the Territory id of our object
            objTerritory.TerritoryID = Convert.ToInt32(gvTerritories.DataKeys[e.RowIndex].Values["TerritoryID"]);

            // Call the delete function
            objTerritory.deleteTerritory();

        }

        protected void gvTerritories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // This event fires as each row is added  to the grip
            e.Row.Cells[2].Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region Additional Namespaces
using eRestaurantSystem.BLL;
using eRestaurantSystem.DAL.Entities;
using EatIn.UI;

#endregion
public partial class Command_Pages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateHired.Text = DateTime.Today.ToShortDateString();

    }
    protected void FetchWaiter_Click(object sender, EventArgs e)
    {
        if(WaiterList.SelectedIndex == 0)
        {
            MessageUserControl.ShowInfo("Please select a Waiter before clicking fetch waiter");
        }

        else
        {
            //we will use a TryRun() from the MessageUser Control

            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo); //GetWaiterInfo is any method I named

        }
    }

        public void GetWaiterInfo()
        {
            //a standard lookup sequence 
            AdminController sysmgr = new AdminController();
            var waiter = sysmgr.GetWaiterByID(int.Parse(WaiterList.SelectedValue));
            WaiterID.Text = waiter.WaiterID.ToString();
            FirstName.Text = waiter.FirstName;
            LastName.Text = waiter.LastName;
           Phone.Text = waiter.Phone;
            Address.Text = waiter.Address;
            DateHired.Text = waiter.HireDate.ToShortDateString();

            if(waiter.ReleaseDate.HasValue)
            {
                DateReleased.Text = waiter.ReleaseDate.ToString();
            }


        }

    
}
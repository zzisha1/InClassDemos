﻿using System;
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
       
        if(!Page.IsPostBack)
        {
            RefreshWaiterList("0");
            DateHired.Text = DateTime.Today.ToShortDateString();
        }

    }

    protected void RefreshWaiterList(string selectedValue)
    {
        //force a requery of the drop down list
        WaiterList.DataBind();
        //insert of the prompt line
        WaiterList.Items.Insert(0, "Select a Waiter");
        //position on a waiter in the list
        WaiterList.SelectedValue = selectedValue;
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


        protected void Insert_Click(object sender, EventArgs e)
        {
           
            //this example is using the message the try run in - line
            MessageUserControl.TryRun(() =>
                {
                    Waiter item = new Waiter();
                    item.FirstName = FirstName.Text;
                    item.LastName = LastName.Text;
                    item.Address = Address.Text;
                    item.Phone = Phone.Text;
                    item.HireDate = DateTime.Parse(DateHired.Text);
                    item.ReleaseDate = null;

                    AdminController sysmgr = new AdminController();
                    WaiterID.Text = sysmgr.Waiters_Add(item).ToString();
                    MessageUserControl.ShowInfo("Waiter added");

                    RefreshWaiterList(WaiterID.Text);
                 }
              );
                    
        }
        protected void UpdateWaiter_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(WaiterID.Text))
            {
                MessageUserControl.ShowInfo("Please select a waiter to update");
            }

            else
            {
                MessageUserControl.TryRun(() =>
                {
                    Waiter item = new Waiter();
                    item.WaiterID = int.Parse(WaiterID.Text);
                    item.FirstName = FirstName.Text;
                    item.LastName = LastName.Text;
                    item.Address = Address.Text;
                    item.Phone = Phone.Text;
                    item.HireDate = DateTime.Parse(DateHired.Text);

                    if (string.IsNullOrEmpty(DateReleased.Text))
                    {
                        item.ReleaseDate = null;
                    }

                    else
                    {
                        item.ReleaseDate = DateTime.Parse(DateReleased.Text);
                    }
                    AdminController sysmgr = new AdminController();
                    sysmgr.Waiters_Update(item);
                    MessageUserControl.ShowInfo("Waiter is updated");
                    RefreshWaiterList(WaiterID.Text);
                }
                );
            }

        }
}
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CategoryMenuItems.aspx.cs" Inherits="Sample_pages_CategoryMenuItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Category Menu Items (Repeater)</h1>
       
       <div class="row col-md-12">
           <asp:Repeater ID="MenuCategories" runat="server" DataSourceID="CategoryMenuItems">
               <ItemTemplate>
                   <h3><img src='<%# "../images/"+ Eval("Description") +"-1.png" %>' width="80" height = "80"/>
                       
                       <%# Eval("Description") %></h3>
                   <asp:Repeater ID="MenuItems" runat="server"
                       DataSource='<%#Eval("MenuItems") %>'>

                       <ItemTemplate>
                           <h5><%# Eval("Description") %>
                           <%# ((decimal)Eval("Price")).ToString("C") %>
                           <span class="badge"><%# Eval("Calories") %>Calories</span>
                           <%#Eval("Comment") %>
                        </h5>
                       </ItemTemplate>

                   </asp:Repeater>
               </ItemTemplate>

           </asp:Repeater>

       </div>
    <asp:ObjectDataSource ID="CategoryMenuItems" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="CategoryMenuItems_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
</asp:Content>




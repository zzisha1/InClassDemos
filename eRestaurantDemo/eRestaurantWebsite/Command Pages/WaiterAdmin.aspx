<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterAdmin.aspx.cs" Inherits="Command_Pages_WaiterAdmin" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
   
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
    <h1>Waiter Admin</h1>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="Label1" runat="server" Text="Select Waiter for Update"></asp:Label>
    <asp:DropDownList ID="WaiterList" runat="server" DataSourceID="ODSWaiters" DataTextField="FullName" DataValueField="WaiterID" Height="16px" Width="196px">
   
    </asp:DropDownList>
    <asp:LinkButton ID="FetchWaiter" runat="server" OnClick="FetchWaiter_Click">Fetch Waiter</asp:LinkButton>
    
     <asp:ObjectDataSource ID="ODSWaiters" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Waiter_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
 <br />

    <table align="center" class="nav-justified">
        <tr>
            <td style="width: 327px">ID:</td>
            <td>
                <asp:Label ID="WaiterID" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 327px">First Name</td>
            <td>
                <asp:TextBox ID="FirstName" runat="server" Width="197px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 327px">Last Name</td>
            <td>
                <asp:TextBox ID="LastName" runat="server" Width="195px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 327px">Phone</td>
            <td>
                <asp:TextBox ID="Phone" runat="server" Width="198px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 327px">Address:</td>
            <td>
                <asp:TextBox ID="Address" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 327px">Date Hired(mm/dd/yyyy)</td>
            <td>
                <asp:TextBox ID="DateHired" runat="server" Width="197px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 327px">Date Released(mm/dd/yyyy)</td>
            <td>
                <asp:TextBox ID="DateReleased" runat="server" Width="195px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 327px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 327px">
                <asp:LinkButton ID="Insert" runat="server" OnClick="Insert_Click">Insert</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="UpdateWaiter" runat="server" OnClick="UpdateWaiter_Click">Update</asp:LinkButton>
            </td>
        </tr>
       
    </table>

</asp:Content>


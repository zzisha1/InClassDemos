<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventAdmin.aspx.cs" Inherits="Sample_pages_SpecialEventAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Special Events Administration</h1>
   

    <br />
    <table align="center" style="width: 80%">
        <tr>
            <td align="right" style="width:50%">Select an Event:&nbsp;&nbsp;</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" runat="server"
                   AppendDataBoundItems="True" DataSourceID="ODSSpecialEvents" DataTextField="Description" DataValueField="EventCode" >
                <asp:ListItem Value="z">Select Event</asp:ListItem>
                     </asp:DropDownList>

               
                <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;<asp:GridView ID="ReservationListGV" runat="server" DataSourceID="ODSReservation" AllowPaging="True" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="CustomerName" HeaderText="Name">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationDate" DataFormatString="{0:MMM dd,yyy}" HeaderText="Date">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NumberInParty" HeaderText="Size">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ContactPhone" HeaderText="Phone" SortExpression="ContactPhone"/>
                        <asp:BoundField DataField="ReservationStatus" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        No Data to display at this time
                    </EmptyDataTemplate>
                    <PagerSettings FirstPageText="start" LastPageText="last" Mode="NumericFirstLast" PageButtonCount="5" Position="TopAndBottom" />
                </asp:GridView>

            </td>
        </tr>
        <tr>
            <td align="center"><asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AllowPaging="True" DataSourceID="ODSReservation">
                <EmptyDataTemplate>
                    No data to display at this time
                </EmptyDataTemplate>
                
                </asp:DetailsView>
              </td>
            
            
        </tr>
        <tr>
            <td style="width: 269px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
   <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvent_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservation" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByEventCode" TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" Name="eventcode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>

    </asp:ObjectDataSource>
    
</asp:Content>




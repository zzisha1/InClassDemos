<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterBillingReport.aspx.cs" Inherits="Reports_WaiterBillingReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br /> <br /> 
    <br /> <br />    <br /> <br />  

    <h1>Waiter Billing SAMPLE</h1>


    <rsweb:ReportViewer ID="WaiterBillingReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Reports\WaiterBilling.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="WaiterBillingODS" Name="WaiterBillingDS" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    <asp:ObjectDataSource ID="WaiterBillingODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWaiterBillingReport" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>

</asp:Content>


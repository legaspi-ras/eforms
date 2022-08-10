<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="connection.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script language=javascript>

   function UcaseTxt(UpCstr) {
      var UCStr = UpCstr.value;
      UpCstr.value = UCStr.toUpperCase();
   }
    </script>

    <h2>Add New Document </h2>
   
    <div style="height: 891px; width: 1270px">
        <br />
        <br />
        <table style="width: 54%; height: 457px; margin-top: 0px; ">
            
            <tr><%--form title number field--%>
                <td style="width: 312px; height: 50px;">
                     <asp:Label ID="Label1" runat="server" Text="Department Area: "></asp:Label>
                </td>
                <td style="height: 50px; width: 422px;">
                     <%--<asp:TextBox ID="txtDeptarea" runat="server" Width="434px"></asp:TextBox>--%>
                     <asp:DropDownList ID="ddlDepartment" runat="server" DataSourceID="SqlDataSource1" DataTextField="departmentArea" DataValueField="departmentArea" Height="25px" ToolTip="Please select depeartment" Width="431px">
                     </asp:DropDownList>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eformsConnectionString %>" ProviderName="<%$ ConnectionStrings:eformsConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT departmentArea FROM tblmasterlist"></asp:SqlDataSource>
                </td>
            </tr>

            <tr><%--applicable specifications field--%>
                <td style="width: 312px; height: 50px;">
                     <asp:Label ID="Label8" runat="server" Text="Form Control Number : "></asp:Label>
                </td>
                <td style="height: 50px; width: 422px;">
                     <asp:TextBox ID="txtFormctrlnum" runat="server" onkeyup="UcaseTxt(this)" Width="431px"></asp:TextBox>
                </td>
            </tr>

            <tr><%--revision number/letter field--%>
                <td style="height: 50px; width: 312px;">
                     <asp:Label ID="Label2" runat="server" Text="Form Tiltle : "></asp:Label>
                </td>
                <td style="height: 50px; width: 422px;">
                    <asp:TextBox ID="txtFormtitle" runat="server" Width="431px"></asp:TextBox>
                </td>
            </tr>

            <tr><%--revision date picker field--%>
                <td style="width: 312px; height: 50px;">
                     <asp:Label ID="Label3" runat="server" Text="Applicable Specification : "></asp:Label>
                </td>
                <td style="height: 50px; width: 422px;">
                     <asp:TextBox ID="txtApplicablespecs" runat="server"  onkeyup="UcaseTxt(this)"  Width="435px"></asp:TextBox>
                </td>
            </tr>

             <tr><%--<td style="height: 200px">
                     <asp:Calendar ID="calDateupload" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" SelectionMode="None">
                         <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                         <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                         <OtherMonthDayStyle ForeColor="#999999" />
                         <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                         <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                         <TodayDayStyle BackColor="#CCCCCC" />
                     </asp:Calendar>
                </td>--%>
                <td style="width: 312px; height: 50px;">
                     <asp:Label ID="Label9" runat="server" Text="Revision number: "></asp:Label>
                </td>
                <td style="height: 50px; width: 422px;">
                     <asp:TextBox ID="txtRevisionnum" runat="server"  onkeyup="UcaseTxt(this)"  Width="437px" MaxLength="2"></asp:TextBox>
                </td>
            </tr>

            <tr><%--select pdf file field--%>
                <td style="height: 51px; width: 312px;">
                    <asp:Label ID="Label4" runat="server" Text="Date : "></asp:Label>
                </td>
                <%--upload button field--%>
                <td style="height: 51px; width: 422px;">
                     <asp:TextBox ID="txtRevdate" runat="server" Width="437px" MaxLength="10"></asp:TextBox>
                </td>
            </tr>

            <tr><%--for validation lang to--%>
                <td style="height: 54px; width: 312px;">
                    <asp:Label ID="Label5" runat="server" Text="Select file for upload : "></asp:Label>
                </td>
                <td style="height: 54px; width: 422px;">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="448px" />
                </td>
            </tr>

            <tr><%--for validation lang to--%>
                <td style="height: 66px; width: 312px;">

                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label> <%--for validation lang to--%>
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label> <%--for validation lang to--%>

                <td style="height: 66px; text-align: right; width: 422px;">
                     <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="127px" />
                </td>
            </tr>


        </table>
    </div>
</asp:Content>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm6.aspx.vb" Inherits="connection.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>




    <style type="text/css">
        .auto-style1 {
            width: 487px;
        }
    </style>




</head>
<body>
    <form id="form1" runat="server">
        <div>


           <%-- <table border="0" cellpadding="0" cellspacing="0">
                 <tr>
                      <td>To:</td>
                      <td><asp:TextBox ID="txtTo" runat="server" /></td>
                      <td>From:</td>
                      <td><asp:TextBox ID="txtFrom" runat="server" /></td>
                      <td>From:</td>
                      <td><asp:TextBox ID="TextBox1" runat="server" /></td>

                 </tr>
                 <tr>
                      <td>Subject:</td>
                      <td><asp:TextBox ID="txtSubject" runat="server" /></td>
                      <td>To:</td>
                      <td><asp:TextBox ID="txtTo1" runat="server" /></td>
                 </tr>
                 <tr>
                      <td valign = "top">Body:</td>
                      <td><asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Height="150" Width="200" /></td>
                     <td>Message:</td>
                      <td><asp:TextBox ID="txtMessage" runat="server" /></td>
                </tr>
                <tr>
                      <td></td>--%>                      <%--<td><asp:Button ID="btnSend" Text="Send" runat="server" OnClick = "SendEmail" /></td>--%>                      
                     <%-- <td></td>
                      <td><asp:Button ID="send" Text="Send" runat="server" OnClick = "SendEmail1" /></td>
                      <td></td>
                      <td></td>
                      <td></td>
                      <td><asp:Button ID="Button1" Text="concat" runat="server" OnClick = "SendEmail1" /></td>
                </tr>
            </table>--%>

            <table style="width: 100%;">
            <tr>
                <td>

                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 191px"> 

                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 191px"> 
                    <asp:Label ID="Label10" runat="server" Text="Search : "></asp:Label>
                </td>
                <td style="width: 555px"> 
                    <asp:TextBox ID="txtSearch" runat="server" Width="559px"></asp:TextBox>
                </td>
                <td class="modal-sm" style="width: 504px"> 
                    <asp:Button ID="btnsearch" runat="server" Text="Search" Width="117px" />

                </td>
            </tr>
             <tr>
                <td class="modal-sm" style="width: 191px"> 

                </td>              
            </tr>
        </table>

            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;<asp:Label ID="Label2" runat="server" Text="Department :"></asp:Label></td>
                    <td>&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    <td>&nbsp;<asp:Label ID="Label3" runat="server" Text="Form Control Number :"></asp:Label></td>
                    <td>&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                    <td>&nbsp;<asp:Label ID="Label4" runat="server" Text="Form Title :"></asp:Label></td>
                    <td>&nbsp;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                    <td>&nbsp;<asp:Label ID="Label5" runat="server" Text="Applicable Specifications :"></asp:Label></td>
                    <td>&nbsp;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;<asp:Label ID="Label6" runat="server" Text="Revision Number :"></asp:Label></td>
                    <td>&nbsp;<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                    <td>&nbsp;<asp:Label ID="Label7" runat="server" Text="Modification Date :"></asp:Label></td> <%--today date nalang to--%>
                    <td>&nbsp;<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
                     <td>&nbsp;<asp:Label ID="Label8" runat="server" Text="Select File for Upload : "></asp:Label></td>
                    <td>&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>


            <table style="width: 100%;">
                <tr>
                    <td>
                        &nbsp;<asp:Label ID="Label9" runat="server" Text="Enter email address :"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="459px"></asp:TextBox></td>
                    <td>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;<asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="469px"></asp:ListBox></td>
                    <td>
                        <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
                        <asp:Button ID="Button2" runat="server" Text="Add" /> <br />
                        <asp:Button ID="Button4" runat="server" Text="remove" /> <br />
                        <asp:Button ID="Button5" runat="server" Text="clear all" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblFilename" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="upload and send email" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>




        </div>
    </form>
</body>
</html>

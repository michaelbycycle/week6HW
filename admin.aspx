<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Sept9.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            All Users:
             <asp:DropDownList ID="ddlUsers" runat="server" AutoPostBack="true"></asp:DropDownList><br /><br />
            First Name:
            <asp:TextBox ID="txtFName" runat="server"></asp:TextBox><br /><br />
            Last Name:
            <asp:TextBox ID="txtLName" runat="server"></asp:TextBox><br /><br />
            Course Name:
            <asp:TextBox ID="txtcourseName" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />

           
        </div>
    </form>
</body>
</html>

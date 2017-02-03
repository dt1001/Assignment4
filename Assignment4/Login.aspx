<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment4.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 200px;
        }
    </style>
</head>
<body style="height: 500px">
    <form id="form1" runat="server">
        <div>
        User Name: <asp:TextBox ID="Username_txt" runat="server"></asp:TextBox>
        <br />
        <br />
        Password: <asp:TextBox ID="Password_txt" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Login_btn" runat="server" OnClick="Login_Click" Text="Login" />
        </div>
    </form>
    <asp:Label ID="Error_lbl" runat="server" Text=""></asp:Label>
</body>
</html>

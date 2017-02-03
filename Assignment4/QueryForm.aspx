<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryForm.aspx.cs" Inherits="Assignment4.QueryForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Listings</title>
    <style type="text/css">
        #Img {
            height: 200px;
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img ID="Img" runat="server" src="blank" />
        <br />
        <br />
        <asp:FileUpload ID="ImgUpload" runat="server" />
        <br />
        <br />
        Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Name_txt" runat="server"></asp:TextBox>
        <br />
        Title;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Title_txt" runat="server"></asp:TextBox>
        <br />
        Start Date:<asp:TextBox ID="Startdate_txt" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Submit_btn" runat="server" Text="Submit" OnClick="Submit_btn_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Cancel_btn" runat="server" Text="Cancel" OnClick="Cancel_btn_Click" />
    
    </div>
    </form>
</body>
</html>

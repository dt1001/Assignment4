<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryForm.aspx.cs" Inherits="Assignment4.QueryForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        

        <asp:Image ID="Image1" runat="server" Width="200px" />
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeTable.aspx.cs" Inherits="Assignment4.EmployeeTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Listings</title>
    <style type="text/css">
        #img_col {
            height: 100px;
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Employee List</h1>
        <asp:ListView ID="Emp_lst" runat="server" ItemPlaceholderID="itemPlaceHolder">
            <LayoutTemplate>
                <table border="1">
                    <thead>
                         <tr runat="server">
                            <th></th>
                            <th>Name</th>
                            <th>Title</th>
                            <th>Date Started</th>
                            <th>Image</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder id="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <table id="items" border="1">
                <tr>
                    <td id="radio_col"><input name="ID" value="<%#Eval("ID") %>" type="radio"/></td>
                    <td><%# Eval("Emp_name") %></td>
                    <td><%# Eval("Jobtitle") %></td>
                    <td><%# Eval("Startdate") %></td>
                    <td id="img_col"><img runat="server" src='<%# Eval("img_url") %>'/></td>
                </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>
        <asp:Button ID="Create_btn" runat="server" Text="Create" OnClick="Create_btn_Click" />
        <asp:Button ID="Edit_btn" runat="server" Text="Edit" OnClick="Edit_btn_Click" />
        <asp:Button ID="Delete_btn" runat="server" Text="Delete" OnClick="Delete_btn_Click" />
    </div>
    </form>
</body>
</html>

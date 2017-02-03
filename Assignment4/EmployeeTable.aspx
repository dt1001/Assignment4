<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeTable.aspx.cs" Inherits="Assignment4.EmployeeTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Employee List</h1>
        <asp:ListView ID="Emp_lst" runat="server" ItemPlaceholderID="itemPlaceHolder">
            <LayoutTemplate>
                <table>
                     <asp:PlaceHolder id="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <table id="Emp_data">
                    <td id="radio_col"><input name="Emp_id" value="<%#Eval("emp_id") %>" type="radio"/></td>
                </table>
                <td id="Data_col">
                    <table id="Emp_table">
                        <tr>
                            <td>Name: </td>
                            <td><%# Eval("emp_name") %></td>
                        </tr>
                        <tr>
                            <td>Title:</td>
                            <td><%# Eval("emp_title") %></td>
                        </tr>
                        <tr>
                            <td>Date Started:</td>
                            <td><%# Eval("emp_start") %></td>
                        </tr>
                        <tr>
                            <img runat="server" src='<%# Eval("emp_image_url") %>'/>
                        </tr>
                    </table>
                </td>
            </ItemTemplate>
        </asp:ListView>
        <asp:Button ID="Create_btn" runat="server" Text="Create" OnClick="Create_btn_Click" />
        <asp:Button ID="Edit_btn" runat="server" Text="Edit" OnClick="Edit_btn_Click" />
        <asp:Button ID="Delete_btn" runat="server" Text="Delete" OnClick="Delete_btn_Click" />
    </div>
    </form>
</body>
</html>

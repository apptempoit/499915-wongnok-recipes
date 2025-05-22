<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DevPool.edit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>จัดการเมนูของฉัน</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</head>
<body>
    <form id="form1" runat="server">
        <a href="menu.aspx" class="w3-button w3-gray w3-large">🔙 กลับไปหน้าหลัก</a>
       
        <div class="w3-container w3-padding-32">
            <h2 class="w3-center">🍴 เมนูอาหารของฉัน</h2>
            <asp:Literal ID="litMyMenus" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="DevPool.menu" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>รายการเมนูอาหารทั้งหมด</title>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <style>
        .menu-card {
            margin: 10px;
            width: 45%;
            display: inline-block;
            vertical-align: top;
        }
        @media screen and (max-width: 768px) {
            .menu-card {
                width: 100% !important;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="w3-container w3-padding-16">
            <a href="index.aspx" class="w3-button w3-gray w3-large">🔙 ออกจากระบบ</a>
        </div>
           <div class="w3-container w3-padding-16 w3-right">
                <a href="CreateRecipes.aspx" class="w3-button w3-blue w3-large">เพิ่มเมนูอาหาร</a>

       <a href="edit.aspx" class="w3-button w3-green w3-large">จัดการเมนูอาหารของตนเอง</a>
   </div>

        <!-- 🔍 แบบฟอร์มค้นหา -->
        <div class="w3-container w3-light-grey w3-padding">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="ค้นหาเมนู..." />

            <div class="w3-margin-bottom">
                <b>ค้นหาจาก:</b><br />
                <asp:RadioButtonList ID="rblField" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="ชื่อเรื่อง" Value="name" Selected="True" />
                    <asp:ListItem Text="เนื้อหา" Value="detail" />
                    <asp:ListItem Text="คำค้น" Value="keyword" />
                </asp:RadioButtonList>
            </div>

            <div class="w3-margin-bottom">
                <b>เรียงตาม:</b>
                <asp:DropDownList ID="ddlSort" runat="server" CssClass="w3-select">
                    <asp:ListItem Text="ชื่อเรื่อง A-Z" Value="name_az" />
                    <asp:ListItem Text="เวลา มาก → น้อย" Value="time_desc" />
                    <asp:ListItem Text="เวลา น้อย → มาก" Value="time_asc" />
                    <asp:ListItem Text="ผู้ใช้ A-Z" Value="user_az" />
                    <asp:ListItem Text="ระดับความยาก (ง่าย→ยาก)" Value="level" />
                    <asp:ListItem Text="คะแนนเฉลี่ย สูง → ต่ำ" Value="rating_desc" />
                    <asp:ListItem Text="คะแนนเฉลี่ย ต่ำ → สูง" Value="rating_asc" />
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnSearch" runat="server" Text="🔍 ค้นหาเมนู" CssClass="w3-button w3-teal" OnClick="btnSearch_Click" />
        </div>

        <!-- 🧾 รายการเมนู -->
        <div class="w3-container w3-padding-32">
            <h2 class="w3-center">📋 รายการเมนูทั้งหมด</h2>
            <asp:Literal ID="litMenu" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
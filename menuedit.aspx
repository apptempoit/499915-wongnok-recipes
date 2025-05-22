<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menuedit.aspx.cs" Inherits="DevPool.menuedit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>แก้ไขเมนูอาหาร</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="w3-container w3-padding-32 w3-white w3-card">
            <h2 class="w3-center">✏️ แก้ไขเมนูอาหาร</h2>

            <asp:Label ID="lblMessage" runat="server" CssClass="w3-text-red w3-large"></asp:Label>
            <br />

            <asp:TextBox ID="txtName" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="ชื่อเมนู" />
            <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Rows="4" CssClass="w3-input w3-margin-bottom" placeholder="รายละเอียดเมนู" />
            <asp:TextBox ID="txtTime" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Number" placeholder="เวลาทำ (นาที)" />
            <asp:TextBox ID="txtKeyword" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="คำค้น เช่น ต้มยำ, ซุป, เผ็ด" />

            <label>ระดับความยาก</label>
            <asp:DropDownList ID="ddlLevel" runat="server" CssClass="w3-select w3-margin-bottom">
                <asp:ListItem Text="ง่าย" Value="1" />
                <asp:ListItem Text="ปานกลาง" Value="2" />
                <asp:ListItem Text="ยาก" Value="3" />
            </asp:DropDownList>

            <asp:TextBox ID="txtOther" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="เจ้าของเมนู (UserAutoID)" ReadOnly="true" />
            <asp:TextBox ID="txtStatus" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="สถานะเมนู (1 = แสดง, 0 = ปิด)" />

            <label>อัปโหลดภาพใหม่ (ถ้าต้องการเปลี่ยน)</label><br />
            <asp:FileUpload ID="fuImage" runat="server" CssClass="w3-margin-bottom" />
            <br />

            <asp:Button ID="btnSave" runat="server" Text="💾 บันทึกการแก้ไข" CssClass="w3-button w3-teal w3-margin-top" OnClick="btnSave_Click" />

            <br /><br />
            <a href="menu.aspx" class="w3-button w3-gray w3-large">🔙 กลับไปหน้าหลัก</a>
        </div>
    </form>
</body>
</html>
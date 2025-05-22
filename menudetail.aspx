<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menudetail.aspx.cs" Inherits="DevPool.menudetail" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>รายละเอียดเมนูอาหาร</title>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</head>
<body>
    <form id="form1" runat="server">

        <a href="menu.aspx" class="w3-button w3-gray w3-large">🔙 กลับไปหน้าหลัก</a>
       
        <div class="w3-container w3-padding-32">

            <!-- ✅ แสดงรายละเอียดเมนู -->
            <div class="w3-card-4 w3-white w3-padding w3-margin-bottom">
                <asp:Label ID="lblDetail" runat="server" Text=""></asp:Label>
            </div>

            <!-- ✅ ส่วนให้คะแนน -->
            <asp:Panel ID="pnlVote" runat="server" CssClass="w3-card-4 w3-white w3-padding">
                <h3>⭐ ให้คะแนนเมนูนี้</h3>
                <asp:RadioButtonList ID="rblRating" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                    <asp:ListItem Text="4" Value="4" />
                    <asp:ListItem Text="5" Value="5" Selected="True" />
                </asp:RadioButtonList>
                <asp:Button ID="btnVote" runat="server" Text="ส่งคะแนน" CssClass="w3-button w3-teal w3-margin-top" OnClick="btnVote_Click" />
                <br />
                <asp:Label ID="lblVoteResult" runat="server" CssClass="w3-text-red" />
            </asp:Panel>

        </div>
    </form>
</body>
</html>

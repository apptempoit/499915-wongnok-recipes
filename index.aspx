<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DevPool.index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wongnok Recipes</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

                 <!-- Navbar -->
     <div class="w3-bar w3-light-grey w3-large">
         <a href="#home" class="w3-bar-item w3-button">เข้าสู่ระบบ</a>
         <a href="#register" class="w3-bar-item w3-button">สมัครสมาชิก</a>
     </div>

            <!-- Header -->
            <header class="w3-container w3-teal w3-center w3-padding-32">
                <h1 class="w3-xxlarge">Wongnok Recipes</h1>
                <p>เว็บแอปพลิเคชันรวบรวมสูตรอาหารเพื่อแบ่งปันและเรียนรู้</p>
            </header>

            <!-- Top 3 เมนู -->
            <section class="w3-container w3-light-grey w3-padding-32">
                <asp:Literal ID="litTop3" runat="server" />
            </section>

       

            <!-- หน้า 1: หน้าแรก -->
            <section id="home" class="w3-container w3-padding-32">
                <h2>เกี่ยวกับ Wongnok Recipes</h2>
                <p>
                    บริษัท วงนอก จำกัด (มหาชน) เชื่อว่าหากให้ความสำคัญกับอาหารซึ่งเป็นปัจจัยพื้นฐานในการดำรงชีวิต
                    จะช่วยให้มนุษย์มีความสุข ลดความเครียดจากชีวิตประจำวันได้
                    ไม่ว่าจะจากงาน สังคม หรือเศรษฐกิจ
                </p>
                <p>
                    เชฟโต้ต้ง CTO ของบริษัท มีแนวคิดในการสร้างแอปนี้เพื่อรวบรวมสูตรอาหารจากสมาชิกในสังคม
                    เพื่อแลกเปลี่ยน แบ่งปัน และเสริมสร้างความสัมพันธ์ในครอบครัว
                </p>
            </section>

            <!-- กล่อง Login -->
            <div class="w3-container login-box">
              <div class="w3-card-4 w3-white w3-padding-large">
                <h3 class="w3-center">เข้าสู่ระบบ</h3>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="w3-center"></asp:Label>
                <asp:TextBox ID="txtUserID" runat="server" CssClass="w3-input w3-margin-top" placeholder="ชื่อผู้ใช้"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="w3-input w3-margin-top" TextMode="Password" placeholder="รหัสผ่าน"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="เข้าสู่ระบบ" CssClass="w3-button w3-teal w3-margin-top w3-block" OnClick="btnLogin_Click" />
              </div>
            </div>

            <!-- หน้า 2: สมัครสมาชิก -->
            <section id="register" class="w3-container w3-padding-32 w3-light-grey">
                <h2>สมัครสมาชิก</h2>
                <div class="w3-card-4 w3-white w3-padding">
                    <asp:TextBox ID="txtRegUserID" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="ชื่อผู้ใช้งาน" />
                    <asp:TextBox ID="txtRegPassword" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Password" placeholder="รหัสผ่าน" />
                    <asp:TextBox ID="txtRegFullname" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="ชื่อ-นามสกุล" />
                    <asp:TextBox ID="txtRegEmail" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="Email" placeholder="อีเมล" />
                    <asp:TextBox ID="txtRegTel" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="เบอร์โทรศัพท์" />
                    <asp:TextBox ID="txtRegDetail" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="รายละเอียดเพิ่มเติม" />
                     <asp:TextBox ID="txtRegOther" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="ข้อมูลอื่น" />
                      <asp:Button ID="btnRegister" runat="server" Text="สมัครสมาชิก" CssClass="w3-button w3-green w3-block" OnClick="btnRegister_Click" />
                    <asp:Label ID="lblRegResult" runat="server" ForeColor="Green" />
                </div>
            </section>

            <!-- Footer -->
            <footer class="w3-container w3-teal w3-center w3-padding-32">
                <p>&copy; 2025 Wongnok Recipes</p>
            </footer>

        </div>
    </form>
</body>
</html>
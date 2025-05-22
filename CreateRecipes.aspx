<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateRecipes.aspx.cs" Inherits="DevPool.CreateRecipes" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wongnok Recipes</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        
           <a href="menu.aspx" class="w3-button w3-gray w3-large">🔙 กลับไปหน้าหลัก</a>
       

            <!-- หน้าเพิ่มเมนูอาหาร -->
            <section id="manage" class="w3-container w3-padding-32 w3-light-grey">
                <h2>เพิ่มเมนูอาหารใหม่</h2>
                <div class="w3-card-4 w3-white w3-padding">
                    <asp:Label ID="lblAddResult" runat="server" ForeColor="Green"></asp:Label>
                    <asp:TextBox ID="txtRecipeName" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="ชื่อเมนู" />
                    <asp:TextBox ID="txtRecipeDetail" runat="server" CssClass="w3-input w3-margin-bottom" TextMode="MultiLine" Rows="4" placeholder="รายละเอียดเมนู" />
                    <asp:TextBox ID="txtRecipeTime" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="ระยะเวลา (นาที) " TextMode="Number" min="0" />
                    <asp:TextBox ID="txtRecipeKeyword" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="คำค้น เช่น ผัด,ไข่,อีสาน" />

                    <div class="w3-margin-bottom">
                        <label class="w3-block">ระดับความยาก:</label>
                        <asp:RadioButtonList ID="rblLevel" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="ง่าย" Value="1" Selected="True" />
                            <asp:ListItem Text="ปานกลาง" Value="2" />
                            <asp:ListItem Text="ยาก" Value="3" />
                        </asp:RadioButtonList>
                    </div>

                       <asp:TextBox ID="txtRecipeStatus" runat="server" CssClass="w3-input w3-margin-bottom" placeholder="สถานะ (1=ใช้งาน, 0=ซ่อน)" />
                    <asp:FileUpload ID="fuRecipeImage" runat="server" CssClass="w3-margin-bottom" />
                    <asp:Button ID="btnAddRecipe" runat="server" Text="บันทึกเมนู" CssClass="w3-button w3-green w3-block" OnClick="btnAddRecipe_Click" />
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
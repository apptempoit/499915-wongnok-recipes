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

            <!-- Header -->
            <header class="w3-container w3-teal w3-center w3-padding-32">
                <h1 class="w3-xxlarge">Wongnok Recipes</h1>
                <p>เว็บแอปพลิเคชันรวบรวมสูตรอาหารเพื่อแบ่งปันและเรียนรู้</p>
            </header>

            <!-- Navbar -->
            <div class="w3-bar w3-light-grey">
                <a href="#home" class="w3-bar-item w3-button">หน้าแรก</a>
                <a href="#register" class="w3-bar-item w3-button">สมัครสมาชิก</a>
                <a href="#menu" class="w3-bar-item w3-button">รายการเมนู</a>
                <a href="#manage" class="w3-bar-item w3-button">จัดการเมนู</a>
                <a href="#members" class="w3-bar-item w3-button">สมาชิก</a>
            </div>

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

            <!-- หน้า 2: สมัครสมาชิก -->
            <section id="register" class="w3-container w3-padding-32 w3-light-grey">
                <h2>สมัครสมาชิก</h2>
                <div class="w3-card-4 w3-white w3-padding">
                    <p><input class="w3-input w3-border" type="text" placeholder="ชื่อผู้ใช้งาน" /></p>
                    <p><input class="w3-input w3-border" type="password" placeholder="รหัสผ่าน" /></p>
                    <p><input class="w3-input w3-border" type="email" placeholder="อีเมล" /></p>
                    <p><button class="w3-button w3-teal">สมัครสมาชิก</button></p>
                </div>
            </section>

            <!-- หน้า 3: รายการเมนู -->
            <section id="menu" class="w3-container w3-padding-32">
                <h2>รายการเมนูอาหาร</h2>
                <ul class="w3-ul w3-card-4">
                    <li class="w3-bar">
                        <div class="w3-bar-item">
                            <span class="w3-large">ต้มยำกุ้ง</span><br />
                            <span>ระยะเวลา: 30 นาที | ความยาก: ปานกลาง</span>
                        </div>
                    </li>
                    <li class="w3-bar">
                        <div class="w3-bar-item">
                            <span class="w3-large">ผัดไทย</span><br />
                            <span>ระยะเวลา: 20 นาที | ความยาก: ง่าย</span>
                        </div>
                    </li>
                </ul>
            </section>

            <!-- หน้า 4: จัดการเมนู -->
            <section id="manage" class="w3-container w3-padding-32 w3-light-grey">
                <h2>จัดการเมนูอาหารของคุณ</h2>
                <div class="w3-card-4 w3-white w3-padding">
                    <p><input class="w3-input w3-border" type="text" placeholder="ชื่อเมนู" /></p>
                    <p><textarea class="w3-input w3-border" placeholder="วัตถุดิบ"></textarea></p>
                    <p><textarea class="w3-input w3-border" placeholder="ขั้นตอนการปรุง"></textarea></p>
                    <p>
                        <label>ระยะเวลา:</label>
                        <select class="w3-select w3-border">
                            <option value="" disabled selected>เลือกระยะเวลา</option>
                            <option>5 - 10 mins</option>
                            <option>11 - 30 mins</option>
                            <option>31 - 60 mins</option>
                            <option>60+ mins</option>
                        </select>
                    </p>
                    <p>
                        <label>ระดับความยาก:</label>
                        <select class="w3-select w3-border">
                            <option value="" disabled selected>เลือกระดับ</option>
                            <option>Easy</option>
                            <option>Medium</option>
                            <option>Hard</option>
                            <option>Extreme Hard</option>
                        </select>
                    </p>
                    <p>
                        <button class="w3-button w3-green">เพิ่ม/แก้ไข</button>
                        <button class="w3-button w3-red">ลบ</button>
                    </p>
                </div>
            </section>

            <!-- หน้า 5: สมาชิก -->
            <section id="members" class="w3-container w3-padding-32">
                <h2>รายชื่อสมาชิก</h2>
                <ul class="w3-ul w3-card-4">
                    <li class="w3-bar">
                        <div class="w3-bar-item">
                            <span class="w3-large">สมาชิก A</span><br />
                            <span>ให้คะแนนสูตรผัดไทย 5 ดาว</span>
                        </div>
                    </li>
                    <li class="w3-bar">
                        <div class="w3-bar-item">
                            <span class="w3-large">สมาชิก B</span><br />
                            <span>โพสต์สูตรต้มยำกุ้ง</span>
                        </div>
                    </li>
                </ul>
            </section>

            <!-- Footer -->
            <footer class="w3-container w3-teal w3-center w3-padding-32">
                <p>&copy; 2025 Wongnok Recipes</p>
            </footer>

        </div>
    </form>
</body>
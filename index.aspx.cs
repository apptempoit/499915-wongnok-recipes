using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevPool
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                LoadTop3Menus();
            }
            else
            {
                lblMessage.Text = "";
                lblRegResult.Text = "";
            }
        }

        private void LoadTop3Menus()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            StringBuilder html = new StringBuilder();
            html.Append("<h3 class='w3-center w3-text-teal'>🍽 เมนูยอดนิยม Top 3</h3>");
            html.Append("<div class='w3-row-padding w3-margin-top'>");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 3 R.RecipesAutoID, R.RecipesName, R.RecipesDetail, R.RecipesTime, R.RecipesLevel, R.RecipesOther, R.RecipesPicturePath, AVG(CAST(RR.RecipesRating AS FLOAT)) AS AvgRating FROM Recipes R LEFT JOIN RecipesRating RR ON R.RecipesAutoID = RR.RecipesAutoID WHERE R.RecipesStatus = '1' GROUP BY R.RecipesAutoID, R.RecipesName, R.RecipesDetail, R.RecipesTime, R.RecipesLevel, R.RecipesOther, R.RecipesPicturePath ORDER BY AvgRating DESC", conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    html.Append("<div class='w3-third w3-margin-bottom'>");
                    html.Append("<div class='w3-card w3-white w3-padding'>");
                    string img = reader["RecipesPicturePath"].ToString();
                    if (!string.IsNullOrEmpty(img))
                        html.Append("<img src='" + img + "' class='w3-image' style='max-height:200px;width:100%' /><br />");
                    html.Append("<h4>🍲 " + reader["RecipesName"] + "</h4>");
                    html.Append("<p><b>รายละเอียด:</b> " + reader["RecipesDetail"] + "</p>");
                    html.Append("<p><b>เวลา:</b> " + reader["RecipesTime"] + " นาที | <b>ระดับ:</b> " + DifficultyText(reader["RecipesLevel"].ToString()) + "</p>");
                    html.Append("<p><b>โดย:</b> " + reader["RecipesOther"] + "</p>");
                    html.Append("</div>");
                    html.Append("</div>");
                }
            }

            html.Append("</div>");
            litTop3.Text = html.ToString();
        }

        private string DifficultyText(string level)
        {
            switch (level)
            {
                case "1": return "ง่าย";
                case "2": return "ปานกลาง";
                case "3": return "ยาก";
                default: return "-";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            string password = txtPassword.Text.Trim();
            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT UserAutoID FROM [User] WHERE UserID = @id AND Password = @pw", conn);
                cmd.Parameters.AddWithValue("@id", userID);
                cmd.Parameters.AddWithValue("@pw", password);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Session["userid"] = userID;
                    Response.Redirect("menu.aspx");
                }
                else
                {
                    lblMessage.Text = "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง";
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string userID = txtRegUserID.Text.Trim();
            string password = txtRegPassword.Text.Trim();
            string fullname = txtRegFullname.Text.Trim();
            string email = txtRegEmail.Text.Trim();
            string tel = txtRegTel.Text.Trim();
            string detail = txtRegDetail.Text.Trim();
            string role = "1";
            string other = txtRegOther.Text.Trim();
            string status = "1";
            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("UserCreate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add input parameters
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@UserFullname", fullname);
                cmd.Parameters.AddWithValue("@UserEmail", email);
                cmd.Parameters.AddWithValue("@UserTel", tel);
                cmd.Parameters.AddWithValue("@UserDetail", detail);
                cmd.Parameters.AddWithValue("@UserRole", role);
                cmd.Parameters.AddWithValue("@UserOther", other);
                cmd.Parameters.AddWithValue("@UserStatus", status);

                // Add output parameter BEFORE ExecuteNonQuery
                SqlParameter resultParam = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 50);
                resultParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(resultParam);

                conn.Open();
                cmd.ExecuteNonQuery(); // ต้องเรียกหลังเพิ่มพารามิเตอร์ทั้งหมด

              

                try
                {
                 
                    string result = resultParam.Value.ToString();

                    if (result == "success")
                    {

                        Session["userid"] = userID;
                        Response.Redirect("menu.aspx");
                    }
                    else if (result == "duplicate")
                    {
                        lblRegResult.ForeColor = System.Drawing.Color.OrangeRed;
                        lblRegResult.Text = "ชื่อผู้ใช้นี้ถูกใช้แล้ว กรุณาเลือกชื่อใหม่";
                    }
                    else
                    {
                        lblRegResult.ForeColor = System.Drawing.Color.Red;
                        lblRegResult.Text = "เกิดข้อผิดพลาด: " + result;
                    }
                }
                catch (Exception ex)
                {
                    lblRegResult.ForeColor = System.Drawing.Color.Red;
                    lblRegResult.Text = "Exception: " + ex.Message;
                }
            }
        }
    }
}
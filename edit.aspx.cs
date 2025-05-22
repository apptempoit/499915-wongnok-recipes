using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace DevPool
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("index.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadMyMenus();
            }
        }

        private void LoadMyMenus()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            StringBuilder html = new StringBuilder();
            string userId = Session["userid"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("RecipesMyself", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecipesAutoID", 0); // 0 = all
                cmd.Parameters.AddWithValue("@UserAutoID",userId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        html.Append("<div class='w3-card w3-padding w3-margin-bottom'>");

                        string img = reader["RecipesPicturePath"].ToString();
                        if (!string.IsNullOrEmpty(img))
                        {
                            html.Append("<img src='" + img + "' style='max-height:200px;width:auto' class='w3-image w3-margin-bottom' />");
                        }

                        html.Append("<h3>🍽 " + reader["RecipesName"] + "</h3>");
                        html.Append("<p><b>รายละเอียด:</b> " + reader["RecipesDetail"] + "</p>");
                        html.Append("<p><b>เวลา:</b> " + reader["RecipesTime"] + " นาที</p>");
                        html.Append("<p><b>ระดับ:</b> " + reader["RecipesLevel"] + "</p>");
                        html.Append("<p><b>เพิ่มเมื่อ:</b> " + Convert.ToDateTime(reader["DatetimeUpdate"]).ToString("dd MMM yyyy HH:mm") + "</p>");
                        html.Append("<a href='menuedit.aspx?recipesid=" + reader["RecipesAutoID"] + "' class='w3-button w3-blue'>✏️ แก้ไขเมนูนี้</a>");

                        html.Append("</div>");
                    }
                }
                catch (Exception ex)
                {
                    html.Append("<div class='w3-red w3-padding'>เกิดข้อผิดพลาด: " + ex.Message + "</div>");
                }
            }

            litMyMenus.Text = html.ToString();
        }
    }
}
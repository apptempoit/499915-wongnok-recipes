// ✅ menudetail.aspx.cs (CodeBehind)
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevPool
{
    public partial class menudetail : System.Web.UI.Page
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
                LoadDetail();
            }
        }

        private void LoadDetail()
        {
            string id = Request.QueryString["Recipes_id"];
            if (string.IsNullOrEmpty(id)) return;

            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            StringBuilder html = new StringBuilder();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("RecipesShowDetail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecipesAutoID", id);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string img = reader["RecipesPicturePath"].ToString();
                        if (!string.IsNullOrEmpty(img))
                            html.Append("<img src='" + img + "' class='w3-image' style='max-height:300px;' /><br /><br />");

                        html.Append("<h2>🍽 " + reader["RecipesName"] + "</h2>");
                        html.Append("<p><b>รายละเอียด:</b> " + reader["RecipesDetail"] + "</p>");
                        html.Append("<p><b>เวลา:</b> " + reader["RecipesTime"] + " นาที</p>");
                        html.Append("<p><b>ระดับ:</b> " + reader["RecipesLevel"] + "</p>");
                        html.Append("<p><b>โดย:</b> " + reader["RecipesOther"] + "</p>");
                        html.Append("<p><b>คะแนนเฉลี่ย:</b> ⭐ " + Convert.ToDecimal(reader["AverageRating"]).ToString("0.0") + "/5</p>");
                    }
                }
                catch (Exception ex)
                {
                    html.Append("<div class='w3-red w3-padding'>Error: " + ex.Message + "</div>");
                }
            }
            lblDetail.Text = html.ToString();
        }

        protected void btnVote_Click(object sender, EventArgs e)
        {
           String userId = Session["userid"].ToString();



            int recipeId = Convert.ToInt32(Request.QueryString["Recipes_id"]);
            int rating = Convert.ToInt32(rblRating.SelectedValue);

            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("RecipesGiveRating", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecipesAutoID", recipeId);
                cmd.Parameters.AddWithValue("@UserAutoID", userId);
                cmd.Parameters.AddWithValue("@RecipesRating", rating);

                SqlParameter result = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 50);
                result.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(result);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    string msg = result.Value.ToString();
                    if (msg == "success")
                        lblVoteResult.Text = "✅ ขอบคุณสำหรับการให้คะแนน!";
                    else if (msg == "duplicate")
                        lblVoteResult.Text = "⚠️ คุณให้คะแนนเมนูนี้แล้ว";
                    else
                        lblVoteResult.Text = "❌ " + msg;
                }
                catch (Exception ex)
                {
                    lblVoteResult.Text = "❌ Error: " + ex.Message;
                }
            }
        }
    }
}

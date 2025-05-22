using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevPool
{
	public partial class CreateRecipes : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // เข้าครั้งแรก
             
            }

           if (Session["userid"] == null)
            {
               // Response.Redirect("index.html");
            }
           else
            {

            }

        }

        protected void btnAddRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

                string name = txtRecipeName.Text.Trim();
                string detail = txtRecipeDetail.Text.Trim();
                string timeText = txtRecipeTime.Text.Trim();
                string keyword = txtRecipeKeyword.Text.Trim();
                string level = rblLevel.SelectedValue;
                string other = Session["userid"].ToString();
              
                string status = txtRecipeStatus.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(detail) || string.IsNullOrEmpty(timeText) ||
                    string.IsNullOrEmpty(keyword) || string.IsNullOrEmpty(level) ||
                    string.IsNullOrEmpty(other) || string.IsNullOrEmpty(status))
                {
                    lblAddResult.ForeColor = System.Drawing.Color.Red;
                    lblAddResult.Text = "❌ กรุณากรอกข้อมูลให้ครบถ้วนทุกช่อง";
                    return;
                }

                if (!int.TryParse(timeText, out int time) || time < 5)
                {
                    lblAddResult.ForeColor = System.Drawing.Color.Red;
                    lblAddResult.Text = "❌ โปรดกรอกเวลาที่ถูกต้อง (ตัวเลขเท่านั้น และต้องมากกว่า 5 นาที)";
                    return;
                }

                string userId = Session["userid"] != null ? Session["userid"].ToString() : "guest";
                string pictureFileName = "";

                if (fuRecipeImage.HasFile)
                {
                    string folderPath = Server.MapPath("~/images/");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string ext = Path.GetExtension(fuRecipeImage.FileName);
                    pictureFileName = userId + "_" + datetime + ext;

                    string savePath = Path.Combine(folderPath, pictureFileName);
                    fuRecipeImage.SaveAs(savePath);
                }

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("RecipesCreate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RecipesName", name);
                    cmd.Parameters.AddWithValue("@RecipesDetail", detail);
                    cmd.Parameters.AddWithValue("@RecipesTime", time);
                    cmd.Parameters.AddWithValue("@RecipesKeyword", keyword);
                    cmd.Parameters.AddWithValue("@RecipesLevel", level);
                    cmd.Parameters.AddWithValue("@RecipesOther", other);
                    cmd.Parameters.AddWithValue("@RecipesStatus", status);
                    cmd.Parameters.AddWithValue("@RecipesPicturePath", "images/" + pictureFileName);

                    SqlParameter result = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 50);
                    result.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(result);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    string msg = result.Value.ToString();

                    if (msg == "success")
                    {
                        lblAddResult.ForeColor = System.Drawing.Color.Green;
                        lblAddResult.Text = "✅ เพิ่มเมนูอาหารเรียบร้อยแล้ว!";
                    }
                    else
                    {
                        lblAddResult.ForeColor = System.Drawing.Color.Red;
                        lblAddResult.Text = "❌ ไม่สามารถเพิ่มเมนูได้: " + msg;
                    }
                }
            }
            catch (Exception ex)
            {
                lblAddResult.ForeColor = System.Drawing.Color.Red;
                lblAddResult.Text = "❌ เกิดข้อผิดพลาด: " + ex.Message;
            }
        }
    
    }
}
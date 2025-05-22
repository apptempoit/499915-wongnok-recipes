using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;

namespace DevPool
{
    public partial class menuedit : System.Web.UI.Page
    {
        private int recipeId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("index.aspx");
                return;
            }

            if (!int.TryParse(Request.QueryString["recipesid"], out recipeId))
            {
                lblMessage.Text = "❌ ไม่พบเมนูที่ต้องการแก้ไข";
                btnSave.Enabled = false;
                return;
            }

            if (!IsPostBack)
            {
                LoadRecipe();
            }
        }

        private void LoadRecipe()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("RecipesShowDetail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RecipesAutoID", recipeId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string owner = reader["RecipesOther"].ToString();
                    string sessionUser = Session["userid"].ToString();
                    if (owner != sessionUser)
                    {
                        lblMessage.Text = "❌ คุณไม่มีสิทธิ์แก้ไขเมนูนี้";
                        btnSave.Enabled = false;
                        return;
                    }

                    txtName.Text = reader["RecipesName"].ToString();
                    txtDetail.Text = reader["RecipesDetail"].ToString();
                    txtTime.Text = reader["RecipesTime"].ToString();
                    txtKeyword.Text = reader["RecipesKeyword"].ToString();
                    ddlLevel.SelectedValue = reader["RecipesLevel"].ToString();
                    txtOther.Text = owner;
                    txtStatus.Text = reader["RecipesStatus"].ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            string picturePath = "";

            if (fuImage.HasFile)
            {
                string folder = Server.MapPath("~/images/");
                string ext = Path.GetExtension(fuImage.FileName);
                string filename = Session["userid"] + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                string savePath = Path.Combine(folder, filename);
                fuImage.SaveAs(savePath);
                picturePath = "images/" + filename;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("RecipesEdit", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RecipesAutoID", recipeId);
                cmd.Parameters.AddWithValue("@RecipesName", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@RecipesDetail", txtDetail.Text.Trim());
                cmd.Parameters.AddWithValue("@RecipesTime", Convert.ToInt32(txtTime.Text.Trim()));
                cmd.Parameters.AddWithValue("@RecipesKeyword", txtKeyword.Text.Trim());
                cmd.Parameters.AddWithValue("@RecipesLevel", ddlLevel.SelectedValue);
                cmd.Parameters.AddWithValue("@RecipesOther", txtOther.Text.Trim());
                cmd.Parameters.AddWithValue("@RecipesStatus", txtStatus.Text.Trim());
                cmd.Parameters.AddWithValue("@RecipesPicturePath", picturePath);

                SqlParameter output = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(output);

                conn.Open();
                cmd.ExecuteNonQuery();

                string result = output.Value.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = (result == "success") ? "✅ บันทึกการแก้ไขเรียบร้อย" : "❌ " + result;
            }
        }
    }
}
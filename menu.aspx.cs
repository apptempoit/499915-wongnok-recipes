using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace DevPool
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMenus();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMenus();
        }

        private void LoadMenus()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            StringBuilder html = new StringBuilder();

            string keyword = txtSearch.Text.Trim();
            string searchField = rblField.SelectedValue;
            string sortOrder = ddlSort.SelectedValue;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("RecipesShowAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@start", "all");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);

                // Filter
                if (!string.IsNullOrEmpty(keyword))
                {
                    string field = "RecipesName";
                    if (searchField == "detail") field = "RecipesDetail";
                    else if (searchField == "keyword") field = "RecipesKeyword";

                    string expr = string.Format("{0} LIKE '%{1}%'", field.Replace("'", "''"), keyword.Replace("'", "''"));
                    DataRow[] filtered = table.Select(expr);
                    table = filtered.Length > 0 ? filtered.CopyToDataTable() : table.Clone();
                }

                // Sort
                string sortExpr = "RecipesName ASC";
                switch (sortOrder)
                {
                    case "time_desc": sortExpr = "RecipesTime DESC"; break;
                    case "time_asc": sortExpr = "RecipesTime ASC"; break;
                    case "name_az": sortExpr = "RecipesName ASC"; break;
                    case "user_az": sortExpr = "RecipesOther ASC"; break;
                    case "level": sortExpr = "RecipesLevel ASC"; break;
                    case "rating_desc": sortExpr = "AverageRating DESC"; break;
                    case "rating_asc": sortExpr = "AverageRating ASC"; break;
                }
                table.DefaultView.Sort = sortExpr;
                table = table.DefaultView.ToTable();

                // Render
                int colCount = 0;
                foreach (DataRow row in table.Rows)
                {
                    if (colCount % 2 == 0) html.Append("<div class='w3-row'>");

                    html.Append("<div class='menu-card w3-card w3-padding w3-white w3-margin-right'>");

                    string imgPath = row["RecipesPicturePath"].ToString();
                    if (!string.IsNullOrEmpty(imgPath))
                        html.Append("<img src='" + imgPath + "' class='w3-image' style='max-height:200px;width:auto;margin-bottom:10px;' />");

                    html.Append("<h3>🍽 " + row["RecipesName"] + "</h3>");
                    html.Append("<p><b>ระดับความยาก:</b> " + DifficultyText(row["RecipesLevel"].ToString()) + "</p>");
                    html.Append("<p><b>เวลา:</b> " + row["RecipesTime"] + " นาที</p>");
                    html.Append("<p><b>โดย:</b> " + row["RecipesOther"] + "</p>");
                    html.Append("<p><b>รายละเอียด:</b> " + row["RecipesDetail"] + "</p>");
                    html.Append("<p><b>คะแนนเฉลี่ย:</b> ⭐ " + Convert.ToDecimal(row["AverageRating"]).ToString("0.0") + "/5</p>");
                    html.Append("<p><b>เพิ่มเมื่อ:</b> " + Convert.ToDateTime(row["DatetimeUpdate"]).ToString("dd MMM yyyy HH:mm") + "</p>");
                    html.Append("<a class='w3-button w3-teal' href='menudetail.aspx?Recipes_id=" + row["RecipesAutoID"] + "'>ดูรายละเอียด</a>");

                    html.Append("</div>");
                    colCount++;
                    if (colCount % 2 == 0) html.Append("</div>");
                }
                if (colCount % 2 != 0) html.Append("</div>");
            }

            litMenu.Text = html.ToString();
        }

        private string DifficultyText(string code)
        {
            if (code == "1") return "ง่าย";
            if (code == "2") return "ปานกลาง";
            if (code == "3") return "ยาก";
            return "ไม่ระบุ";
        }
    }
}

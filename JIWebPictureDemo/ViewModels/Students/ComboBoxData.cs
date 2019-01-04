using JIWebPictureDemo.Models.General;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace JIWebPictureDemo.ViewModels.Students
{
    public class ComboBoxData
    {
        public static SelectList GetListData(ListType listType)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListTypesDataGetDataByListType", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.AddWithValue("@ListTypeId", listType);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SelectListItem sli = new SelectListItem
                        {
                            Text = reader["Description"].ToString(),
                            Value = reader["Id"].ToString(),
                        };

                        list.Add(sli);
                    }
                }
            }

            SelectList selectList = new SelectList(list.AsEnumerable(), "Value", "Text");

            return selectList;

        }
    }
}
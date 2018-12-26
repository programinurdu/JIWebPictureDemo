﻿using JIWebPictureDemo.Models.General;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace JIWebPictureDemo.ViewModels.Students
{
    public class ComboBoxData
    {
        public static List<SelectListItem> GetListData(ListType listType)
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
                        SelectListItem sli = new SelectListItem();
                        sli.Text = reader["Text"].ToString();
                        sli.Value = reader["Value"].ToString();

                        list.Add(sli);
                    }
                }
            }

            return list;

        }
    }
}
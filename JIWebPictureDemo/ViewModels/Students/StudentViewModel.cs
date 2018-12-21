using JIWebPictureDemo.Models;
using JIWebPictureDemo.Models.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace JIWebPictureDemo.ViewModels.Students
{
    public class StudentViewModel
    {
        public int GenerateStudentId()
        {
            int studentId = 0;

            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsGenerateStudentId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    studentId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return studentId;
        }

        public void InsertStudentInfo(Student student)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsAddNewStudent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    cmd.Parameters.AddWithValue("@FullName", student.FullName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                    cmd.Parameters.AddWithValue("@Telephone", student.Telephone);
                    cmd.Parameters.AddWithValue("@Address1", student.Address1);
                    cmd.Parameters.AddWithValue("@Address2", student.Address2);
                    cmd.Parameters.AddWithValue("@City", student.City);
                    cmd.Parameters.AddWithValue("@County", student.County);
                    cmd.Parameters.AddWithValue("@PostCode", student.PostCode);
                    cmd.Parameters.AddWithValue("@Photo", student.Photo);
                    cmd.Parameters.AddWithValue("@Notes", student.Notes);
                    

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> StudentList()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsGetAllStudent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Student std = new Student();
                        std.StudentId = Convert.ToInt32(reader["StudentId"]);
                        std.FullName = reader["FullName"].ToString();
                        std.Email = reader["Email"].ToString();
                        std.Mobile = reader["Mobile"].ToString();

                        students.Add(std);
                    }
                }
            }

            return students;
        }
    }
}
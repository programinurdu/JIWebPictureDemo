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

        public Student GetStudentDetailsByStudentId(int studentId)
        {
            Student student = new Student();

            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsGetStudentDetailsById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();

                    student.StudentId = Convert.ToInt32(reader["StudentId"]);
                    student.FullName = reader["FullName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Telephone = reader["Telephone"].ToString();
                    //student.Photo = reader["Photo"];
                    student.Address1 = reader["Address1"].ToString();
                    student.Address2 = reader["Address2"].ToString();
                    student.City = Convert.ToInt32(reader["City"]);
                    student.County = Convert.ToInt32(reader["County"]);
                    student.PostCode = reader["PostCode"].ToString();
                    student.Notes = reader["Notes"].ToString();
                }
            }

            return student;
        }

        public void UpdateStudentInfo(Student student)
        {
            using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsUpdateStudentDetails", conn))
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
                        Student std = new Student
                        {
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Mobile = reader["Mobile"].ToString()
                        };

                        students.Add(std);
                    }
                }
            }

            return students;
        }
    }
}
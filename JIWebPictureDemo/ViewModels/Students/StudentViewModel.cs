﻿using JIWebPictureDemo.Models;
using JIWebPictureDemo.Models.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

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
                    cmd.Parameters.AddWithValue("@Mobile", student.Mobile ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Telephone", student.Telephone ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Address1", student.Address1 ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Address2", student.Address2 ?? string.Empty);
                    cmd.Parameters.AddWithValue("@City", student.City ?? string.Empty);
                    cmd.Parameters.AddWithValue("@County", student.County ?? string.Empty);
                    cmd.Parameters.AddWithValue("@PostCode", student.PostCode ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Photo", student.Photo);
                    cmd.Parameters.AddWithValue("@Notes", student.Notes ?? string.Empty);
                    

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
                    student.Mobile = (reader["Mobile"] is DBNull) ? string.Empty :reader["Mobile"].ToString();
                    student.Telephone = (reader["Telephone"] is DBNull) ? string.Empty : reader["Telephone"].ToString();
                    //student.Photo = reader["Photo"];
                    student.Address1 = (reader["Address1"] is DBNull) ? string.Empty : reader["Address1"].ToString();
                    student.Address2 = (reader["Address2"] is DBNull) ? string.Empty : reader["Address2"].ToString();
                    student.City = (reader["City"] is DBNull) ? string.Empty : reader["City"].ToString();
                    student.County = (reader["County"] is DBNull) ? string.Empty : reader["County"].ToString();
                    student.PostCode = (reader["PostCode"] is DBNull) ? string.Empty : reader["PostCode"].ToString();
                    student.Notes = (reader["Notes"] is DBNull) ? string.Empty : reader["Notes"].ToString();
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
                    cmd.Parameters.AddWithValue("@Mobile", student.Mobile ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Telephone", student.Telephone ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Address1", student.Address1 ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Address2", student.Address2 ?? string.Empty);
                    cmd.Parameters.AddWithValue("@City", student.City ?? string.Empty);
                    cmd.Parameters.AddWithValue("@County", student.County ?? string.Empty);
                    cmd.Parameters.AddWithValue("@PostCode", student.PostCode ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Photo", student.Photo);
                    cmd.Parameters.AddWithValue("@Notes", student.Notes ?? string.Empty);


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
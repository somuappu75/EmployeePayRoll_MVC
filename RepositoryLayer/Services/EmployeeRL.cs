using CommonLayer;
using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly IConfiguration Configuration;
        public EmployeeRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        //To Add new employee record      
        public void AddEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRollMVC")))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee  ", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                cmd.Parameters.AddWithValue("@Profileimage", employeeModel.Profileimage);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                cmd.Parameters.AddWithValue("@notes", employeeModel.notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRollMVC")))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    employee.EmployeeName = rdr["EmployeeName"].ToString();
                    employee.Profileimage = rdr["Profileimage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.notes = rdr["notes"].ToString();


                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }
        //To Update a Employee Or Edit the Employee Method Api
        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRollMVC")))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employeeModel.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                cmd.Parameters.AddWithValue("@Profileimage", employeeModel.Profileimage);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                cmd.Parameters.AddWithValue("@notes", employeeModel.notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Get the details of a particular employee  Method Api  
        public EmployeeModel GetEmployeeData(int? id)
        {
            EmployeeModel employeeModel = new EmployeeModel();

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRollMVC")))
            {
                string sqlQuery = "SELECT * FROM Employee WHERE EmployeeID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employeeModel.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    employeeModel.EmployeeName = rdr["EmployeeName"].ToString();
                    employeeModel.Profileimage = rdr["Profileimage"].ToString();
                    employeeModel.Gender = rdr["Gender"].ToString();
                    employeeModel.Department = rdr["Department"].ToString();
                    employeeModel.Salary = Convert.ToInt32(rdr["Salary"]);
                    employeeModel.StartDate= Convert.ToDateTime(rdr["StartDate"]);
                    employeeModel.notes = rdr["notes"].ToString();
                }
            }
            return employeeModel;
        }
        //Delete Employee
        //To Delete the record on a particular employee    
        public void DeleteEmployee(int? id)
        {

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRollMVC")))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}

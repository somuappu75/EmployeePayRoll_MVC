using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }
        //Adding Employee TO DB Method Reference
        public void AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.employeeRL.AddEmployee(employeeModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get All EMployees Model Method Reference
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
               return this.employeeRL.GetAllEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Upadete A Particular Employee Method Reference
        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.employeeRL.UpdateEmployee(employeeModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        // Employee To egt EMployee Data Reference method
        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
               return this.employeeRL.GetEmployeeData(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Delete Employee Method refernce
        public void DeleteEmployee(int? id)
        {
            try
            {
                this.employeeRL.DeleteEmployee(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}


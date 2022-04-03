using CommonLayer;
using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public void AddEmployee(EmployeeModel employeeModel);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public void UpdateEmployee(EmployeeModel employeeModel);
        public EmployeeModel GetEmployeeData(int? id);
        public void DeleteEmployee(int? id);
    }
}

using Business.Services.Interfaces;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> DepartmentsList = TestData.DepartmentsList;

        public void CreateDepartment(Department department)
        {
            DepartmentsList.Add(department);
        }

        public bool DeleteDepartment(Department department)
        {
            return DepartmentsList.Remove(department);
        }

        public Department GetDepartmentByID(int DepartmentID)
        {
            return DepartmentsList
                .FirstOrDefault(d => d.ID.Equals(DepartmentID));
        }

        public List<Department> GetDepartments()
        {
            return DepartmentsList;
        }

        public void UpdateDepartment(Department department)
        {
            if (DepartmentsList.Remove(department))
                CreateDepartment(department);

            else
                throw new ApplicationException("Department not found");
        }
    }
}

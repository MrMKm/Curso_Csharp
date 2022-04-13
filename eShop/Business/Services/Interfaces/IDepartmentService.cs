using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartments();
        public Department GetDepartmentByID(int DepartmentID);
        public void CreateDepartment(Department department);
        public void UpdateDepartment(Department department);
        public bool DeleteDepartment(Department department);

    }
}

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
        public static List<Department> DepartmentsList = new List<Department>()
        {
            new Department(1, "Alimentos", SubDepartmentService.foodSubDepartments, ProductService.ProductsList),
            new Department(2, "Muebles", SubDepartmentService.mueblesSubDepartments, null),
            new Department(3, "Electrónica", SubDepartmentService.electronicSubDepartments, null)
        };

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

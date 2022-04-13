using Business.Services.Interfaces;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class SubDepartmentService : ISubDepartmentService
    {
        public static List<SubDepartment> subDepartmentsList = new List<SubDepartment>();

        public static List<SubDepartment> foodSubDepartments = new List<SubDepartment>()
        {
            new SubDepartment(1, "Juices", 1),
            new SubDepartment(2, "Frutas", 1),
            new SubDepartment(3, "Verduras", 1)
        };
        public static List<SubDepartment> mueblesSubDepartments = new List<SubDepartment>()
        {
            new SubDepartment(4, "Salas", 2)
        };
        public static List<SubDepartment> electronicSubDepartments = new List<SubDepartment>()
        {
            new SubDepartment(5, "TVs", 3),
            new SubDepartment(6, "Audio", 3),
            new SubDepartment(7, "Videojuegos", 3)
        };

        public SubDepartmentService()
        {
            subDepartmentsList.AddRange(foodSubDepartments);
            subDepartmentsList.AddRange(mueblesSubDepartments);
            subDepartmentsList.AddRange(electronicSubDepartments);
        }

        public void CreateSubDepartment(SubDepartment subDepartment)
        {
            subDepartmentsList.Add(subDepartment);
        }

        public bool DeleteSubDepartment(SubDepartment subDepartment)
        {
            return subDepartmentsList.Remove(subDepartment);
        }

        public SubDepartment GetSubDepartmentByID(int subID)
        {
            return subDepartmentsList
                .FirstOrDefault(s => s.ID.Equals(subID));
        }

        public List<SubDepartment> GetSubDepartments()
        {
            return subDepartmentsList;
        }

        public void UpdateSubDepartment(SubDepartment subDepartment)
        {
            if (subDepartmentsList.Remove(subDepartment))
                CreateSubDepartment(subDepartment);

            else
                throw new ApplicationException("Sub department not found");
        }
    }
}

using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ISubDepartmentService
    {
        public List<SubDepartment> GetSubDepartments();
        public SubDepartment GetSubDepartmentByID(int subID);
        public void CreateSubDepartment(SubDepartment subDepartment);
        public void UpdateSubDepartment(SubDepartment subDepartment);
        public bool DeleteSubDepartment(SubDepartment subDepartment);
    }
}

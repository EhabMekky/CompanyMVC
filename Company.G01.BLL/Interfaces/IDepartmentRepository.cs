using Company.G01.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G01.BLL.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<DepartmentRepo> GetAll();
        DepartmentRepo Get(int? id);
        int Add(DepartmentRepo entity);
        int Update(DepartmentRepo entity);
        int Delete(DepartmentRepo entity);
    }

}

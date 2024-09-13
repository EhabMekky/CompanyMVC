using Company.G01.BLL.Interfaces;
using Company.G01.DAL.Data.Context;
using Company.G01.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G01.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        // Constructor
        public DepartmentRepository(AppDbContext context) // Create an object of AppDbContext
        {
            _context = context;
        }
        public int Add(DAL.Models.DepartmentRepo entity)
        {
            _context.Departments.Add(entity);
             return _context.SaveChanges();

        }
        public int Update(DAL.Models.DepartmentRepo entity)
        {
            _context.Departments.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(DAL.Models.DepartmentRepo entity)
        {
            _context.Departments.Remove(entity);
            return _context.SaveChanges();
        }

        public DAL.Models.DepartmentRepo? Get(int? id)
        {
            return _context.Departments.Find(id);
        }

        public IEnumerable<DAL.Models.DepartmentRepo> GetAll()
        {
            return _context.Departments.ToList();
        }
    }
}

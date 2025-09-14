using Learn.DAL.DataBase;
using Learn.DAL.Entities;
using Learn.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.DAL.Repo.Implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext db;
        public DepartmentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<Department> GetAll()
        {
            try
            {
                var result = db.departments.ToList();   
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

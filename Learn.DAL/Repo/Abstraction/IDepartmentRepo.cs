using Learn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.DAL.Repo.Abstraction
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
    }
}

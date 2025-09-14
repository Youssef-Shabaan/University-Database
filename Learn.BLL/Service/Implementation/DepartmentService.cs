using Learn.BLL.ModelVM.Department;
using Learn.BLL.Service.Abstraction;
using Learn.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BLL.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo dbRepo;
        public DepartmentService(IDepartmentRepo dbRepo)
        {
            this.dbRepo = dbRepo;
        }

        public (bool,string, List<GetAllDepartmentVM>) GetAll()
        {
            try
            {
                var result = dbRepo.GetAll();
                if(result.Count == 0)
                {
                    return(true,"There is no data in Department", null);
                }
                var AllDept = new List<GetAllDepartmentVM>();
                foreach (var department in result)
                {
                    AllDept.Add(new GetAllDepartmentVM { Id = department.Id , Name = department.Name});
                }
                return(false,null,AllDept);  
            }
            catch(Exception ex)
            {
                return (true,ex.Message,null);
            }
        }
    }
}

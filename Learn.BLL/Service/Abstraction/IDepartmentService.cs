using Learn.BLL.ModelVM.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BLL.Service.Abstraction
{
    public interface IDepartmentService
    {
        (bool,string, List<GetAllDepartmentVM>) GetAll();
    }
}

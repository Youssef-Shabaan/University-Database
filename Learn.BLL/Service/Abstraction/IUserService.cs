using Learn.BLL.ModelVM.User;
using Learn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BLL.Service.Abstraction
{
    public interface IUserService
    {
        (bool,string) Create(CreateUserVM user);
        (bool, string, List<GetAllUserVM>) GetAll();
    }
}

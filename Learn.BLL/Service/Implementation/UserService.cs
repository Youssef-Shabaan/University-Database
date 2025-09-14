using AutoMapper;
using Learn.BLL.Helper;
using Learn.BLL.ModelVM.User;
using Learn.BLL.Service.Abstraction;
using Learn.DAL.Entities;
using Learn.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BLL.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;

        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this.mapper = mapper;
        }
        public (bool, string) Create(CreateUserVM user)
        {
            try
            {
                var imagPath = Upload.UploadFile("Files", user.image);
                var newuser = new User(user.Name,user.Age,imagPath,user.DeptId);
                var result = userRepo.Create(newuser);
                if (result) return (false, null);
                return (true, "Ther is a problem in Data");
            }
            catch (Exception ex)
            {
                return(false, ex.Message);
            }
        }

        public (bool, string, List<GetAllUserVM>) GetAll()
        {
            try
            {
                var result = userRepo.GetAll();
                if (result.Count == 0) return (true, "There is no data", null);
                //var AllUsers = new List<GetAllUserVM>();
                //foreach (var item in result)
                //{
                //    AllUsers.Add(new GetAllUserVM { Id = item.Id, Name = item.Name, ImagePath = item.ImagePath, DeptName = item.Dept.Name });
                //}
                var AllUsers = mapper.Map<List<GetAllUserVM>>(result);
                return (false, null, AllUsers);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }
    }
}

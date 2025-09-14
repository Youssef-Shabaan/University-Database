using AutoMapper;
using Learn.BLL.ModelVM.User;
using Learn.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile() 
        {
            CreateMap<User, GetAllUserVM>().
                ForMember(a => a.DeptName, opt => opt.MapFrom(u => u.Dept.Name));
        }
    }
}

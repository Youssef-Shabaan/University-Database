using Learn.DAL.DataBase;
using Learn.DAL.Entities;
using Learn.DAL.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.DAL.Repo.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext Db;
        public UserRepo(ApplicationDbContext db)
        {
            Db = db;
        }
        bool IUserRepo.Create(User user)
        {
            try
            {
                var result = Db.users.Add(user);
                if(user.Age <= 0 || string.IsNullOrEmpty(user.Name))
                {
                    return false;
                }
                Db.SaveChanges();
                if(result.Entity.Id > 0) return true;
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        bool IUserRepo.Delete(int id)
        {
            try
            {
                var result = Db.users.Where(a => a.Id == id).FirstOrDefault();
                if(result == null) return false;
                Db.users.Remove(result);
                Db.SaveChanges() ;
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        List<User> IUserRepo.GetAll()
        {
            try
            {
                var result = Db.users.ToList();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        User IUserRepo.GetById(int id)
        {
            try
            {
                var result = Db.users.Where(a => a.Id == id).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool IUserRepo.Update(User user)
        {
            try
            {
                var OldUser = Db.users.Where(a => a.Id == user.Id).FirstOrDefault();
                if (OldUser == null) return false;
                OldUser.Update("DeskTop-You", user.Name, user.Age);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

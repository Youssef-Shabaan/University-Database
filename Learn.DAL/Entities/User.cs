using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.DAL.Entities
{
    public class User
    {
        public User() { }
        public User(string name, int age,string imagePath, int deptId)
        {
            Name = name;
            Age = age;
            ImagePath = imagePath;
            DeptId = deptId;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string? CreaterUser { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? UserModifier { get; private set; }
        public string? ImagePath { get; private set; }
        public bool Update(string userModifier,string name, int age)
        {
            if(string.IsNullOrEmpty(userModifier) || string.IsNullOrEmpty(name) || age <= 0)
            {
                return false;
            }
            Name = name;
            Age = age;
            ModifiedOn = DateTime.Now;
            UserModifier = userModifier;
            return true;
        }

        // relation ship
        [ForeignKey("Dept")]
        public int DeptId { get; private set; }
        public virtual Department Dept { get; private set; }    
    }
}

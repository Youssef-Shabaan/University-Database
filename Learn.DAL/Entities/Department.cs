using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.DAL.Entities
{
    public class Department
    {
        public Department() { }
        public Department(string name)
        {
            Name = name;
            CreatedOn = DateTime.Now;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public virtual List<User>? users { get; private set; }
    }
}

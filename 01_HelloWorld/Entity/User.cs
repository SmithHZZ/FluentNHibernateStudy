using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld.Entity
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int Age { set; get; }

        public virtual string Address { set; get; }

        public virtual ISet<Role> Roles { set; get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this.Name);
        }

    }
}

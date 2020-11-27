using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld.Entity
{
    public class Role
    {

        public virtual int Id { get; set; }
        
        public virtual string Name { set; get; }

        public virtual string Remark { set; get; }

        public virtual ISet<User> Users { set; get; } = new HashSet<User>();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this.Name);
        }
    }
}

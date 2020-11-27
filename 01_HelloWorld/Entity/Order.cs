using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld.Entity
{
    public class Order
    {
        public virtual int Id { set; get; }

        public virtual int UserId { set; get; }

        public virtual decimal Total { set; get; }

        public virtual float Discount { set; get; }

        public virtual string Remark { set; get; }

        public virtual User Owner { set; get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(Owner.Name);
        }
    }
}

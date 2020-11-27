using _01_HelloWorld.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld.Mapping
{
    class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(o => o.Id);
            Map(o => o.UserId);
            Map(o => o.Total);
            Map(o => o.Discount);
            Map(o => o.Remark);

            References<User>(r => r.Owner).Column("UserId").ForeignKey("Id").Cascade.All();
        }

    }
}

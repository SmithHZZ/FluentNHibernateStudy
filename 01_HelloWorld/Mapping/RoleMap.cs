using _01_HelloWorld.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld.Mapping
{
    public class RoleMap : ClassMap<Role>
    {

        public RoleMap()
        {
            Id(r => r.Id);
            Map(r => r.Name);
            Map(r => r.Remark);

            HasManyToMany<User>(r => r.Users)
            .AsSet()
            .Not.LazyLoad()
            .Cascade.All()
            .ParentKeyColumn("RoleId")
            .ChildKeyColumn("UserId")
            .Table("UserRole");
        }

    }
}

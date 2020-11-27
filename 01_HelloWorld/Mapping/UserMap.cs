using _01_HelloWorld.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Age);
            Map(x => x.Address);
            HasManyToMany<Role>(u => u.Roles)
                .AsSet()
                .Not.LazyLoad()
                .Cascade.All()
                .ParentKeyColumn("UserId")
                .ChildKeyColumn("RoleId")
                .Table("UserRole");
        }
    }
}

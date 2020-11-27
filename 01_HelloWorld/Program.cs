using _01_HelloWorld.Entity;
using _01_HelloWorld.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    transaction.Begin();

                    //添加
                    //{
                    //    User user = new User() { Name = "Hello", Age = 18, Address = "北京东城区中南海" };

                    //    session.SaveOrUpdate(user);
                    //}
                    ////更新
                    //{
                    //    User user = new User() { Id = 6, Name = "Hello", Age = 18, Address = "北京东城区中南海"+DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") };

                    //    session.SaveOrUpdate(user);
                    //}

                    ////根据id查
                    //{
                    //    User user = session.Get<User>(5);

                    //    Console.WriteLine(user);
                    //}

                    ////hql查询
                    //{
                    //    var hql = session.CreateQuery("from User u where u.Id = ?").SetInt32(0, 6);

                    //    List<User> u = hql.List<User>().ToList();

                    //    Console.WriteLine(u[0]);
                    //}
                    ////criteria查询
                    //{
                    //    var criteria = session.CreateCriteria<User>();
                    //    criteria.Add(Restrictions.Eq("Id", 6));
                    //    criteria.AddOrder(Order.Asc("Id"));

                    //    Console.WriteLine(criteria.UniqueResult<User>());
                    //}
                    ////SQL查询
                    //{
                    //    var sql = session.CreateSQLQuery("SELECT * FROM [User]").AddEntity(typeof(User));
                    //    foreach (var user in sql.List<User>())
                    //    {
                    //        Console.WriteLine(user);
                    //    }
                    //}
                    //存储过程，fn中不直接支持，自己实现
                    //{
                    //    IDbConnection connection = session.Connection;
                    //    IDbTransaction tran = connection.BeginTransaction();
                    //    IDbCommand command = connection.CreateCommand();

                    //    command.CommandText = "proc_Test";
                    //    command.CommandType = CommandType.StoredProcedure;

                    //    //无返回值
                    //    command.ExecuteNonQuery();
                    //}

                    //测试多对多
                    //{
                    //    User u1 = session.Get<User>(5);
                    //    User u2 = session.Get<User>(6);
                    //    User u3 = session.Get<User>(8);

                    //    Console.WriteLine(u1);
                    //    Console.WriteLine(u2);
                    //    Console.WriteLine(u3);

                    //    Role r1 = session.Get<Role>(1);
                    //    Role r2 = session.Get<Role>(2);
                    //    Console.WriteLine(r1.Users);
                    //    Console.WriteLine(r2.Users);
                    //}

                    //测试一对多
                    {
                        Entity.Order order = session.Get<Entity.Order>(1);
                        Console.WriteLine(order);
                    }
                    

                    transaction.Commit();
                }
            }

            Console.ReadKey();
        }


        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2008.ConnectionString(s => s.Server(".").Database("Test").Username("sa").Password("123@abcd")).ShowSql())
              .Mappings(m => {
                  m.FluentMappings.AddFromAssemblyOf<Program>();
              })
              .BuildSessionFactory();
        }


    }
}

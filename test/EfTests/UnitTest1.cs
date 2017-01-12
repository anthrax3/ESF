using System;
using System.Collections.Generic;
using System.Linq;
using Intime.Framework.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intime.Framework.Repository.EF.UnitTest.Models;

namespace Intime.Framework.Repository.EF.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        const string  DbName = "Intime.Framework.Repository.EF.UnitTest.DemoDbContext";
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            
        }

        [TestMethod]
        public void GetEFRepository()
        {
        
        }


        [TestMethod]
        public void EFUnitOfWorkTest() 
        {
        
            var userName = Guid.NewGuid().ToString("N");

            var dbContext = new DemoDbContext(DbName);
            var context = new EfContext(dbContext);

            using (var uow = new EfUnitOfWork(context))
            {
                try
                {
                    var userRepo = uow.GetRepository<User>();
                    var user = new User
                    {
                        UserName = userName
                    };
                    user.Logs = new List<Log>()
                    {
                        new Log
                        {
                            //User = user,
                            ActionName = "too",
                            ActionTime = DateTime.Now
                        }
                    };
                    //userRepo.Add(user);
                    userRepo.AddGraph(user,m => m.Logs);

                    //var logRepo = uow.GetRepository<Log>();
                    //logRepo.Add(new Log
                    //{
                    //    User = user,
                    //    ActionName = "too long",
                    //    ActionTime = DateTime.Now
                    //});

                    uow.Commit();
                }
                catch (Exception ex)
                {
                    Output(ex);
                }
            }

            var repo = new EF.Repository<User>(context);
            var any = repo.Query(m => m.UserName == userName).Any();
            Assert.IsFalse(any);
        }

        [TestMethod]
        public void TestMultiTenant()
        {
            var userName = Guid.NewGuid().ToString("N");

            var dbContext = new DemoDbContext(DbName);
            var tp = new MockTenantProvider();
            var context = new EfContext(dbContext) {TenantContext = tp};
            var userRepo = new Repository<User>(context);

            userRepo.Add(new User
            {
                UserName = userName
            });

           var user = userRepo.Query(m => m.UserName == userName).Select().FirstOrDefault();
            Assert.IsNotNull(user);
            Assert.AreEqual(tp.TenantId,user.TenantId);
        }

        static void Output(Exception e)
        {
            var ex = e;
            if (ex == null)
                return;
            Console.WriteLine(ex.Message);
            ex = ex.InnerException;
            Output(ex);
        }

    }

    public class MockTenantProvider : ITenantContext
    {
        #region Implementation of ITenantContext<out int>

        public int TenantId => 1;

        #endregion
    }
}

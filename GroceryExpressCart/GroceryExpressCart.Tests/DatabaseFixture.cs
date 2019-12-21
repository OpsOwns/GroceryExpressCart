using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Security;
using GroceryExpressCart.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryExpressCart.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public GroceryContext Context { get; set; }
        public PasswordHasher bCryptPasswordHasher { get; set; }
        public DatabaseFixture()
        {
            bCryptPasswordHasher = new PasswordHasher(new PasswordSettings { SecretKey = "$2y$12$1YIOnDli2aDPGVSrpCBEt.tjEgcK1tX6.a/6yVp9l4h6Crc9UHeHW" });
            var dbContextOptions = new DbContextOptionsBuilder<GroceryContext>().UseInMemoryDatabase("TestDB");
            Context = new GroceryContext(dbContextOptions.Options, new Common.SeedWork.DatabaseSettings { InMemory = true });
            Context.Database.EnsureCreated();
            Setup();
        }

        private void Setup()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

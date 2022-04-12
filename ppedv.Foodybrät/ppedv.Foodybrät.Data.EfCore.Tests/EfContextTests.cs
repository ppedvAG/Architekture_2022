using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.Foodybrät.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace ppedv.Foodybrät.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_Db()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_CRUD_Food()
        {
            var f = new Food() { Description = $"Pizza_{Guid.NewGuid()}", Kcal = 345, Price = 9.8m };
            var newDesc = $"Döner_{Guid.NewGuid()}";

            using (var con = new EfContext()) //CREATE
            {
                con.Food.Add(f);
                Assert.Equal(1, con.SaveChanges());
            }

            using (var con = new EfContext()) //READ
            {
                var loaded = con.Food.Find(f.Id);
                Assert.Equal(f.Description, loaded.Description);

                loaded.Description = newDesc; //UPDATE
                con.SaveChanges();
            }

            using (var con = new EfContext()) //check UPDATE
            {
                var loaded = con.Food.Find(f.Id);
                Assert.Equal(newDesc, loaded.Description);

                con.Food.Remove(loaded); //DELETE
                con.SaveChanges();
            }

            using (var con = new EfContext()) //check DELETE
            {
                var loaded = con.Food.Find(f.Id);
                Assert.Null(loaded);
            }
        }


        [Fact]
        public void Can_add_Customer()
        {

            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));

            var cust = fix.Build<Customer>().Create();

            using (var con = new EfContext())
            {
                con.Customers.Add(cust);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Customers.Find(cust.Id);
                loaded.Should().BeEquivalentTo(cust, c => c.IgnoringCyclicReferences());
            }

        }
    }
    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}
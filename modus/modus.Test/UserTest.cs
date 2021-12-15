using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using modus.api.Controllers;
using modus.Core.Repositories;
using modus.Data.Repositories;
using modus.Model.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace modus.Test
{
    public class UserTest
    {
        UserRepository ur;
        UserController uc;
        User testSubject;

        [Fact]
        public void Init()
        {
            testSubject = new User()
            {
                Address = new Address()
                {
                    City = "kaka",
                    Country = "kuku",
                    Postcode = "1230",
                    Street = "kiki"
                },
                Email = "kika",
                FirstName = "pipi",
                LastName = "popo"
            };
            this.ur = new UserRepository();
            this.uc = new UserController(ur);
        }
        [Fact]
        public async Task AddUserTest()
        {
            Init();

            var x = await uc.CreateUser(testSubject);

            x.Value.Should().BeEquivalentTo(testSubject);
        }

        [Fact]
        public async Task GetByIdTest()
        {
            Init();

            await uc.CreateUser(testSubject);

            var x = await uc.GetById(testSubject.Id);

            x.Should().BeEquivalentTo(testSubject);
        }

        [Fact]
        public async Task GetAllTest()
        {
            Init();

            await uc.CreateUser(testSubject);

            var x = await uc.Get();

            Assert.NotNull(x);
            Assert.NotEmpty(x);
        }

        [Fact]
        public async Task DeleteUserTest()
        {
            Init();

            await uc.CreateUser(testSubject);

            await uc.DeleteUser(testSubject.Id);

            var z = await uc.GetById(testSubject.Id);

            Assert.Null(z);
        }

        [Fact]
        public async Task UpdateUserTest()
        {
            Init();

            await uc.CreateUser(testSubject);

            User testSubjectUpdate = new User()
            {
                Address = new Address()
                {
                    City = "kaka",
                    Country = "kuku",
                    Postcode = "1230",
                    Street = "kiki"
                },
                Email = "kika",
                FirstName = "Maxim",
                LastName = "popo"
            };

            await uc.UpdateUser(testSubjectUpdate, testSubject.Id);

            var z = await uc.GetById(testSubject.Id);

            testSubjectUpdate.Id = z.Id;

            z.Should().BeEquivalentTo(testSubjectUpdate);
        }
    }
}

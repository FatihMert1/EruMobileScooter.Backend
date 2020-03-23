using System;
using System.Collections.Generic;
using System.Linq;
using EruMobileScooter.Data;
using EruMobileScooter.Service.Repositories.Abstract;
using EruMobileScooter.Service.Repositories.Concreate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EruMobileScooter.Test.UserTest
{
    public class UserUnitTest
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationContext _context;

        public UserUnitTest()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationContext>()
                            .UseInMemoryDatabase("in_memory_user_database")
                            .Options;
            _context = new ApplicationContext(dbOptions);
            _userRepository = new UserRepository(_context);
        }


        [Fact(DisplayName="User Only Marks To Added. No Adding To Database")]
        public void Gıven_User_Should_State_Added()
        {
        //Given
        var user = getSingleUser();
        var expectedState = EntityState.Added;
        var users = _userRepository.GetAll().ToList();
        //When
        var actual = _userRepository.Insert(user);
        var actualState = _context.Entry<User>(actual).State;
        //Then
        Assert.NotNull(actual);
        Assert.True( 0 == users.Count);
        Assert.Equal<EntityState>(expectedState, actualState);
        }

        [Fact(DisplayName = "Given Null User Object No Deleting And Throws Argument Exception")]
        public void Given_Null_User_Throws_Null_Reference_Exception()
        {
            User user = null;
            Assert.Throws<ArgumentException>(() => _userRepository.Delete(user));
        }

        [Fact(DisplayName="Given Empty String Id Should Return Argument Exception")]
        public void Given_Null_Or_Empty_Id_Should_Throws_Argument_Exception()
        {
        //Given
        string emptyId = "";
        //When
        //Then
        Assert.Throws<ArgumentException>(()=> _userRepository.Delete(emptyId));
        }

        private User getSingleUser(){
            return new User{
            CreatedAt = DateTime.Now, Department = "Renewable Energy System Engineer", Email="1031320314@erciyes.edu.tr", Faculty="Engineerign Faculty", Gender=Gender.MALE,
            Identity = "20001234365", Name = "Fatih Rahman", Surname ="Mert", Password = "Secret_Password", Phone="5372141071", Role = Role.STUDENT
            };
        }
    }
}
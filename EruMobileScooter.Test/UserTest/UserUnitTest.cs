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


        [Fact(DisplayName="GetGender Method Should Return Gender MALE")]
        public void GetGender_Should_Return_MALE_Type()
        {
        //Given
        var user = getSingleUser();
        _userRepository.Insert(user);
        _context.SaveChanges();
        //When
        var gender = _userRepository.GetGender(user.Id);
        Assert.Equal<Gender>(Gender.MALE,gender);
        //Then
        _userRepository.Delete(user);
        _context.SaveChanges();
        }
        
        [Fact(DisplayName="GetGender Method Should Return NONE Type Of Gender")]
        public void GetGender_Should_Return_NONE_Type()
        {
        //Given
        var actualGender = _userRepository.GetGender("for example");
        var expectedGender = Gender.NONE;
        //When
        Assert.Equal<Gender>(expectedGender,actualGender);
        //Then
        }
        
        [Fact(DisplayName="GetGender Method Should Throw ArgumentException Given Empty User Id")]
        public void GetGender_Should_Throw_ArgumentException_For_Empty_User_Id()
        {
        //Given
        var userId = "";
        //When
        Assert.Throws<ArgumentException>(() => _userRepository.GetGender(userId));
        //Then
        }

        [Fact(DisplayName="GetRole Method Should Return Correct User Id and Role Type Is Must Be STUDENT")]
        public void GetRole_Should_Return_STUDENT_Type()
        {
        //Given
        var user = getSingleUser();
        var expectedRole = Role.STUDENT;
        _userRepository.Insert(user);
        _context.SaveChanges();
        //When
        var actualRole = _userRepository.GetRole(user.Id);
        //Then
        Assert.Equal<Role>(expectedRole,actualRole);
        _userRepository.Delete(user);
        _context.SaveChanges();
        }

        [Fact(DisplayName="GetRole Method Should Return NONE Type Of Role")]
        public void GetRole_Should_Return_NONE_Type()
        {
        //Given
        var actualRole = _userRepository.GetRole("asdasd");
        var expectedRole = Role.NONE;
        //When
        Assert.Equal<Role>(expectedRole,actualRole);
        //Then
        }

        [Fact(DisplayName="GetRole Method Should Throw ArgumentException Via Empty User Id Parameter")]
        public void GetRole_Should_Throw_ArgumentException_Empty_User_Id_Parameter()
        {
        //Given
        var userId = "";
        //When
        Assert.Throws<ArgumentException>(() => _userRepository.GetRole(userId));
        //Then
        }

        [Fact(DisplayName="Verify Method Should Throw ArgumentException Cause That Empty Id Or Null User")]
        public void Verify_Should_Throw_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _userRepository.Verify("",new User()));
            Assert.Throws<ArgumentNullException>(() => _userRepository.Verify("qwe",null));
        }

        [Fact(DisplayName="Verify Method Should Return True, Given Correct User Id And User Object")]
        public void Verify_Should_Return_True()
        {
        //Given
        var user = getSingleUser();
        _userRepository.Insert(user);
        _context.SaveChanges();
        //When
        var actual = _userRepository.Verify(user.Id,user);
        var expected = true;
        //Then
        Assert.Equal<bool>(expected,actual);

        _userRepository.Delete(user);
        _context.SaveChanges();
        }

        [Fact(DisplayName="Verify Method Should Return False, Given Incorrect User Id")]
        public void Verify_Should_Return_False()
        {
        //Given
        var user = getSingleUser();
        //When
        var actual = _userRepository.Verify(user.Id,user);
        var expected = false;
        //Then
        Assert.Equal<bool>(expected,actual);
        }
        private User getSingleUser()
        {
            return new User
            {
                CreatedAt = DateTime.Now,
                Department = "Renewable Energy System Engineer",
                Email = "1031320314@erciyes.edu.tr",
                Faculty = "Engineerign Faculty",
                Gender = Gender.MALE,
                Identity = "20001234365",
                Name = "Fatih Rahman",
                Surname = "Mert",
                Password = "Secret_Password",
                Phone = "5372141071",
                Role = Role.STUDENT
            };
        }

    }
}
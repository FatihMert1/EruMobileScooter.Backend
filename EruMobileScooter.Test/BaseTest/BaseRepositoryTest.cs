using System;
using System.Collections.Generic;
using System.Linq;
using EruMobileScooter.Data;
using EruMobileScooter.Service.Repositories.Abstract;
using EruMobileScooter.Service.Repositories.Concreate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EruMobileScooter.Test.BaseTest
{
    /**
    *  This Test Class Testing BaseRepository uses User Entity. 
    */
    public class BaseRepositoryTest
    {
        
        private readonly IBaseRepository<User> _userRepository;
        private readonly ApplicationContext _context;

        public BaseRepositoryTest()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationContext>()
                            .UseInMemoryDatabase("in_memory_base_repository")
                            .Options;
            _context = new ApplicationContext(dbOptions);
            _userRepository = new BaseRepository<User>(_context);
        }


        [Fact(DisplayName = "Insert Method Only Marks Added. No Add To Database")]
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
            Assert.True(0 == users.Count);
            Assert.Equal<EntityState>(expectedState, actualState);
        }

        [Fact(DisplayName = "Delete Method Only Marks Deleted To Given User Object. No Add To Database")]
        public void Delete_Should_Marks_Deleted_State_To_Given_User()
        {
            User user = new User();
            _userRepository.Delete(user);
            var markedUser = _context.Entry<User>(user).State;
            Assert.True(EntityState.Deleted == markedUser);
        }

        [Fact(DisplayName = "Delete Method Given Empty String Id Should Return Argument Exception")]
        public void Given_Empty_Id_Should_Throws_Argument_Exception()
        {
            //Given
            string emptyId = "";
            //When
            //Then
            Assert.Throws<ArgumentException>(() => _userRepository.Delete(emptyId));
        }

        [Fact(DisplayName="Get Method Should Return Null For Empty Id")]
        public void Get_Should_Return_Null_Given_Empty_Id()
        {
        //Given
        var emptyId = "";
        //When
        var actualResult = _userRepository.Get(emptyId);
        //Then
        Assert.Null(actualResult);
        }

        [Fact(DisplayName="Get Method Should Return Correct User With Valid Id")]
        public void Get_Should_Return_Correct_User_With_Valid_Id()
        {
        //Given
        var user = getSingleUser();
        _userRepository.Insert(user);
        _context.SaveChanges();
        //When
        var actualUser = _userRepository.Get(user.Id);
        //Then
        Assert.NotNull(actualUser);
        Assert.True(user.Equals(actualUser));

        _userRepository.Delete(user);
        _context.SaveChanges();
        }
        
        [Fact(DisplayName="GetAll Method Should Return User List that Count One")]
        public void GetAll_Should_Return_IEnumerable_With_User_Objects()
        {
        //Given
        var user = getSingleUser();
        _userRepository.Insert(user);
        _context.SaveChanges();
        //When
        var actualUserList = _userRepository.GetAll();
        Assert.True( 1 == actualUserList.Count() );
        //Then
        _userRepository.Delete(user);
        _context.SaveChanges();
        }

        [Fact(DisplayName="Update Method Should Return Given User")]
        public void Update_Should_Return_Given_User()
        {
        //Given
        var user = getSingleUser();
        _userRepository.Insert(user);
        _context.SaveChanges();
        user.Name = "Train Name";
        var actualUser = _userRepository.Update(user);
        //When
        Assert.NotNull(actualUser);
        Assert.NotEqual(getSingleUser().Name, actualUser.Name);
        //Then
        _userRepository.Delete(actualUser);
        _context.SaveChanges();
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
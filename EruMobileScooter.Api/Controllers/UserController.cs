using System;
using System.Collections.Generic;
using System.Linq;
using EruMobileScooter.Api.Helpers;
using EruMobileScooter.Api.Models;
using EruMobileScooter.Data;
using EruMobileScooter.Localization.Models;
using EruMobileScooter.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EruMobileScooter.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILanguage language;

        public UserController(IUnitOfWork unitOfWork, ILanguage language){
            _unitOfWork = unitOfWork;
            this.language = language;
        }

        /**
        *   Returns User List
        */
        [HttpGet("all")]
        public ApiResponse<List<User>> GetUsers(){
            var users = _unitOfWork.UserRepository.GetAll().ToList();
            if(users != null){
                return ResponseHelper.CreateResponse(users, language.Success , 1, false);
            } else {
                return ResponseHelper.CreateResponse<List<User>>(null, language.WrongInput, 2, true);
            }
        }

        [HttpGet("{id}")]
        public ApiResponse<User> GetUser(string id){
            if (id.Equals("") || id == null)
                return ResponseHelper.CreateResponse<User>(null, language.SetArguments("ID").WrongInput, 2, true);
            var user = _unitOfWork.UserRepository.Get(id);
            if(user != null){
                return ResponseHelper.CreateResponse(user,language.Success,1,false);
            }else {
                return ResponseHelper.CreateResponse<User>(null,language.Failled,2,true);
            }
        }

        [HttpPost("insert")]
        public ApiResponse<User> Insert([FromBody] User user){
            var isValidUser = UserHelper.IsUserValid(user,language);
            if(isValidUser == false)
                return ResponseHelper.CreateResponse<User>(null,language.WrongInput,2,true);
            var result = _unitOfWork.UserRepository.Insert(user);
            var commitResult = _unitOfWork.Commit();
            language.SetArguments("User Inserted");
            if (result != null && commitResult)
                return ResponseHelper.CreateResponse(result, language.Success, 1, false);
            else
                return ResponseHelper.CreateResponse<User>(null, language.Failled, 2, true);
        }

        [HttpPut("update/{id}")]
        public ApiResponse<User> Update([FromBody] User user,string id){
            var isValidUser = UserHelper.IsUserValid(user,language);
            if(isValidUser == false) 
                ResponseHelper.CreateResponse<User>(user,language.WrongInput,2,true);
            var result = _unitOfWork.UserRepository.Update(user);
            var commitResult = _unitOfWork.Commit();
            if(result != null && commitResult)
            {
                language.SetArguments("Update User");
                return ResponseHelper.CreateResponse<User>(result, language.Success, 1, false);
            }
            else
            {
                language.SetArguments("Update User");
                return ResponseHelper.CreateResponse<User>(null, language.Failled, 2, true);
            }
        }
    }
}
﻿using DiscountTracker.Business.Abstraction;
using DiscountTracker.Entities.Dto;
using DiscountTracker.Utilities.EncryptionHelpers;
using DiscountTracker.Common.Constants;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiscountTracker.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public ApiResponse<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            var response = new ApiResponse<CreateUserResponse>();
            var createdUser= _userService.CreateUser(request);

            if (createdUser==null)
            {
                response.IsSuccess = false;
                response.ErrorList.Add(new ApiError() { ErrorMessage="An error occured while creating user" });
                return response;
            }

            response.Data.User = createdUser.Data;
            
            return response;
        }

        [HttpPost("Login")]
        public ApiResponse<LoginResponse> Login(LoginRequest request)
        {

            var response = new ApiResponse<LoginResponse>();
            var user= _userService.Login(request);
            if (user==null)
            {
                response.IsSuccess = false;
                return response;
            }

            response.Data.User = user.Data;
            
            return response;
        }
    }
}

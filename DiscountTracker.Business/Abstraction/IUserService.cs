using System;
using System.Threading.Tasks;
using DiscountTracker.Entities.Dto;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.Business.Abstraction
{
    public interface IUserService
    {
        Task<DtUser> Login(LoginRequest request);
        Task<DtUser> CreateUser(CreateUserRequest request);
    }
}

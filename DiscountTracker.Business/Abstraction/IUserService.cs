using System;
using System.Threading.Tasks;
using DiscountTracker.Entities.Core;
using DiscountTracker.Entities.Dto;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.Business.Abstraction
{
    public interface IUserService
    {
        IDataResult<DtUser> Login(LoginRequest request);
        IDataResult<DtUser> CreateUser(CreateUserRequest request);
    }
}

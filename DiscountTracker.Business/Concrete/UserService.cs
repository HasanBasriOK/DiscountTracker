using System;
using System.IO;
using System.Threading.Tasks;
using DiscountTracker.Business.Abstraction;
using DiscountTracker.Business.Aspects;
using DiscountTracker.DataAccess.MongoDB.Abstraction;
using DiscountTracker.Entities.Core;
using DiscountTracker.Entities.Dto;
using DiscountTracker.Entities.MongoDB;
using DiscountTracker.Utilities;
using DiscountTracker.Utilities.EncryptionHelpers;

namespace DiscountTracker.Business.Concrete
{
    public class UserService : IUserService
    {
        IDtUserDal _userDal;

        public UserService(IDtUserDal userdal)
        {
            _userDal = userdal;
        }


        [HandleExceptionAspect]
        public IDataResult<DtUser> Login(LoginRequest request)
        {
            var password = Encryption.Encrypt(Encryption.Decrypt(request.Password, Constants.ClientEncryptionKey),Constants.ServerEncryptionKey);
            return new SuccessDataResult<DtUser>(_userDal.GetAsync(x => x.Email == request.Email && x.Password == password).Result);
        }

        [HandleExceptionAspect]
        public IDataResult<DtUser> CreateUser(CreateUserRequest request)
        {

            if (_userDal.Get(x=> x.Email==request.Email) != null)
            {
                return new ErrorDataResult<DtUser>(Constants.ThisEmailIsUsingAlready);
            }

            var user = new DtUser();
            user.BirthDate = request.BirthDate;
            user.DeviceId = request.DeviceId;
            user.Email = request.Email;
            user.Firstname = request.Firstname;
            user.IsActive = false;
            user.IsApproved = false;
            user.IsTransferred = false;
            user.Lastname = request.Lastname;
            user.RegisterDate = DateTime.Now;
            user.Password = Encryption.Encrypt(Encryption.Decrypt(request.Password, Constants.ClientEncryptionKey), Constants.ServerEncryptionKey);

            return new SuccessDataResult<DtUser>(_userDal.AddAsync(user).Result);
        }

    }
}

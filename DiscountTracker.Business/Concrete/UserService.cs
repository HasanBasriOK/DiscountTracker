using System;
using System.Threading.Tasks;
using DiscountTracker.Business.Abstraction;
using DiscountTracker.Business.Aspects;
using DiscountTracker.DataAccess.MongoDB.Abstraction;
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


        [HandleException]
        public Task<DtUser> Login(LoginRequest request)
        {
            var password = Encryption.Encrypt(Encryption.Decrypt(request.Password, Constants.ClientEncryptionKey),Constants.ServerEncryptionKey);
            return _userDal.GetAsync(x => x.Email == request.Email && x.Password == password);
        }

        [HandleException]
        public Task<DtUser> CreateUser(CreateUserRequest request)
        {
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

            return _userDal.AddAsync(user);
        }

    }
}

using System;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.DataAccess.MongoDB.Abstraction
{
    public interface IDtUserDal : IRepository<DtUser, string>
    {
       
    }
}

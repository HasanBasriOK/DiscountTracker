using DiscountTracker.DataAccess.MongoDB;
using DiscountTracker.Entities;
using DiscountTracker.Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementController : BaseController
    {
        private readonly IDtAnnouncementDal _announcementDal;
        public AnnouncementController(IDtAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        [HttpGet("GetAnnouncements")]
        public ApiResponse<GetAnnouncementsResponse> GetAnnouncements()
        {
            var response = new ApiResponse<GetAnnouncementsResponse>();
            var result = _announcementDal.Get();

            if (result==null)
            {
                response.ErrorList.Add(new ApiError() { ErrorCode="1",ErrorMessage="An error occured while getting announcement list",ErrorType=ErrorType.Temporary.ToString() });
                response.IsSuccess = false;
                return response;
            }

            response.Data.Announcements = result.ToList();
            response.IsSuccess = true;
            return response;
        }
    }
}

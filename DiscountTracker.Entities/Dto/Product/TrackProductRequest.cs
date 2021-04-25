using System;
namespace DiscountTracker.Entities.Dto
{
    public class TrackProductRequest:IRequest
    {
        public string WebSite { get; set; }
        public string UserId { get; set; }
        public string Url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.Dto
{
    public class ApiResponse<T> where T : class, IResponse,new()
    {
        public List<ApiError> ErrorList { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }

        public ApiResponse()
        {
            this.ErrorList = new List<ApiError>();
            this.Data = new T();
        }
    }
}

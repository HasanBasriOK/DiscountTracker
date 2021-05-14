using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountTracker.Business.Abstraction;
using DiscountTracker.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiscountTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("TrackProduct")]
        public ApiResponse<TrackProductResponse> TrackProduct(TrackProductRequest request)
        {
            var response = new ApiResponse<TrackProductResponse>();
            var result= _productService.TrackProduct(request);

            if (!result.Success)
            {
                response.IsSuccess = false;
                response.ErrorList.Add(new ApiError() { ErrorMessage = result.Message });
            }

            return response;
        }

        [HttpPost("GetMyProducts")]
        public ApiResponse<GetMyProductsResponse> GetMyProducts(GetMyProductsRequest request)
        {
            var response = new ApiResponse<GetMyProductsResponse>();

            var result = _productService.GetProductListByFollowingUser(request.UserId);

            if (result.Success)
            {
                response.Data.Products = result.Data;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorList.Add(new ApiError() { ErrorMessage=result.Message });
            }

            return response;
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreBE.Dtos;
using StoreBE.Entities;

namespace StoreBE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StoreBeDbContext _context;

        public ProductController(StoreBeDbContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// گرفتن تمامی محصولات
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetAllProductsAsync()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return new ApiResult
                {
                    IsSuccess = true,
                    RsCode = Ok().StatusCode,
                    Message = "The products info",
                    ResultData = products 
                };
            }
            catch (Exception)
            {
                return new ApiResult
                {
                    IsSuccess = false,
                    RsCode = NoContent().StatusCode,
                    Message = "Failed to fetch the products..."
                };
            }

        }
        /// <summary>
        /// یافتن یک محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ApiResult>> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                return new ApiResult
                {
                    IsSuccess = true,
                    RsCode = Ok().StatusCode,
                    Message = "The product info",
                    ResultData = product
                };
            }
            catch (Exception)
            {
                return new ApiResult
                {
                    IsSuccess = false,
                    RsCode = BadRequest().StatusCode,
                    Message = "Failed to fetch the products..."
                };
            }
        }
        /// <summary>
        /// ایجاد یک محصول جدید
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ApiResult>> AddProduct(AddProductRequest request)
        {
            try
            {
                var product = new Product
                {
                    Name = request.Name,
                    Price = request.Price,
                    Description = request.Description,
                };
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return new ApiResult
                {
                    IsSuccess = true,
                    RsCode = Ok().StatusCode,
                    Message = "The new product created",
                    ResultData = product.Id
                };
            }
            catch (Exception)
            {
                return new ApiResult
                {
                    IsSuccess = false,
                    RsCode = BadRequest().StatusCode,
                    Message = "Failed to create the new product...",
                };
            }
        }
        /// <summary>
        /// حذف یک محصول
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<ApiResult>> RemoveProductById(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                await Task.Run(() =>
                {
                    _context.Products.Remove(product);
                });
                await _context.SaveChangesAsync();
                return new ApiResult
                {
                    IsSuccess = true,
                    RsCode = Ok().StatusCode,
                    Message = "The product info",
                    ResultData = product
                };
            }
            catch (Exception)
            {
                return new ApiResult
                {
                    IsSuccess = false,
                    RsCode = BadRequest().StatusCode,
                    Message = "Failed to remove the products..."
                };
            }
        }
        /// <summary>
        /// ویرایش یک محصول
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ApiResult>> EditProduct(EditProductRequest request)
        {
            try
            {
                var product = new Product
                {
                    Id = request.Id,
                    Name = request.Name,
                    Price = request.Price,
                    Description = request.Description,
                };
                await Task.Run(() =>
                {
                    _context.Products.Update(product);
                });
                await _context.SaveChangesAsync();
                return new ApiResult
                {
                    IsSuccess = true,
                    RsCode = Ok().StatusCode,
                    Message = "The product edited",
                    ResultData = product
                };
            }
            catch (Exception)
            {
                return new ApiResult
                {
                    IsSuccess = false,
                    RsCode = BadRequest().StatusCode,
                    Message = "Failed to edit the products..."
                };
            }
        }
    }
}

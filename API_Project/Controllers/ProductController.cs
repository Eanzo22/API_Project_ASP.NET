using ECommerce.BL.DTOS.Products;
using ECommerce.BL.Managers.Products;
using ECommerce.DAL.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly EcommerceContext ecommerceContext;

        public ProductController(IProductManager productManager, EcommerceContext ecommerceContext)
        {
            this.productManager = productManager;
            this.ecommerceContext = ecommerceContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ReadProductDto>> GetAll([FromQuery] ProductFilterDto productFilterDto)
        {
            var products = productManager.GetAll(productFilterDto);
            if (products is null)
                return NotFound();
            return Ok(products.ToList());
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReadProductDto> GetById(int id) {
            var product = productManager.GetById(id);
            if (product is null) return NotFound();
            return Ok(product);
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public ActionResult Add(AddProductDto addProductDto) {
            productManager.AddProduct(addProductDto);
            return Ok(StatusCodes.Status201Created);
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPut]
        public ActionResult Edit(EditProductDto editProductDto ) {
            bool result = productManager.Edit(editProductDto);
            if (result) 
                return Ok("Edited Sucessfully");
            return StatusCode(StatusCodes.Status400BadRequest, "Faild To edit");

        }
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id) {
            if(productManager.DeleteById(id))
                return Ok("Deleted Sucessfully");
            return StatusCode(StatusCodes.Status400BadRequest, "Faild To Delete");
        }
    }

}

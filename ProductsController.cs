using Furniture_Shop.Data;
using Furniture_ShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furniture_ShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly Furniture_ShopAPIDbContext dbContext;

        public ProductsController(Furniture_ShopAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await dbContext.Products.ToListAsync());
            
        }
        

        public async Task<IActionResult> GetProduct([FromRoute] Guid Product_ID) 
        {
            var product = await dbContext.Products.FindAsync(Product_ID);

            if(product == null) 
            {
                return NotFound();
            }

            return Ok(product);


        }

        [HttpPost]

        public async Task<IActionResult> AddProduct(AddProductRequest addProductRequest) 
        {
            var product = new Product()
            {
                Product_ID = Guid.NewGuid(),
                Catogary_Id = addProductRequest.Catogary_Id,
                Product_Name = addProductRequest.Product_Name,
                Product_Price = addProductRequest.Product_Price
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();  

            return Ok(product);
        }

        [HttpPut]
       
        public async Task<IActionResult> Updateproduct([FromRoute] Guid Product_ID, Updateproductrequest updateproductrequest) 
        {
            var product = await dbContext.Products.FindAsync(Product_ID);

            if(product != null) 
            {

                product.Catogary_Id = updateproductrequest.Catogary_Id;
                product.Product_Name = updateproductrequest.Product_Name;
                product.Product_Price = updateproductrequest.Product_Price;

                await dbContext.SaveChangesAsync();

                return Ok(product);
            }
            
            return NotFound();
        
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteProduct([FromRoute] Guid Product_ID)
        {
            var product = await dbContext.Products.FindAsync(Product_ID);

            if (product != null)
            {
                dbContext.Remove(product);
                await dbContext.SaveChangesAsync();
                return Ok(product);
            }

            return NotFound();

            


        }




    }
}
 
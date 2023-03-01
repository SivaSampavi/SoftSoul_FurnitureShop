using Furniture_Shop.Data;
using Furniture_ShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furniture_ShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminsController : Controller
    {
        private readonly Furniture_ShopAPIDbContext dbContext;

        public AdminsController(Furniture_ShopAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            return Ok(await dbContext.Admins.ToListAsync());

        }


        public async Task<IActionResult> GetAdmin([FromRoute] Guid A_ID)
        {
            var admin = await dbContext.Admins.FindAsync(A_ID);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);


        }

        [HttpPost]

        public async Task<IActionResult> AddAdmin(AddAdminRequest addAdminRequest)
        {
            var admin = new Admins()
            {

                A_Id = addAdminRequest.A_Id,
                A_email = addAdminRequest.A_email,
                A_Password = addAdminRequest.A_Password
            };

            await dbContext.Admins.AddAsync(admin);
            await dbContext.SaveChangesAsync();

            return Ok(admin);
        }

        [HttpPut]

        public async Task<IActionResult> Updateadmin([FromRoute] string A_ID, Updateadminrequest updateadminrequest)
        {
            var admin = await dbContext.Admins.FindAsync(A_ID);

            if (admin != null)
            {

                admin.A_email = updateadminrequest.A_email;
                admin.A_Password = updateadminrequest.A_Password;

                await dbContext.SaveChangesAsync();

                return Ok(admin);
            }

            return NotFound();

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteAdmin([FromRoute] string A_ID)
        {
            var admin = await dbContext.Admins.FindAsync(A_ID);

            if (admin != null)
            {
                dbContext.Remove(admin);
                await dbContext.SaveChangesAsync();
                return Ok(admin);
            }

            return NotFound();




        }




    }
}


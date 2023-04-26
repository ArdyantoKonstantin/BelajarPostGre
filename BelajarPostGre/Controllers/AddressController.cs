using BelajarPostGre.Entity;
using BelajarPostGre.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelajarPostGre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        UserDbContext db;

        public AddressController(UserDbContext _db)
        {
            this.db = _db;
        }
        [HttpPost("/registerAddress")]
        public async Task<bool> RegisterAddress([FromBody] RegisterAddressModel model)
        {
            var user = await db.Users.FirstOrDefaultAsync(s => s.Id == model.UserId);
            if (user == null)
            {
                return false;
            }
            if (model.Address == null)
            {
                return false;
            }

            var newAddress = new Address()
            {
                AddressName = model.Address,
                UserId = model.UserId
            };
            db.Address.Add(newAddress);
            await db.SaveChangesAsync();
            return true;
        }

        [HttpGet]
        public async Task<List<GetAddressModel>> GetAddress()
        {
            var addresses = await (from a in db.Address
                                   join u in db.Users
                                   on a.UserId equals u.Id
                                   select new GetAddressModel()
                                   {
                                       Address = a.AddressName,
                                       Username = u.Name
                                   }).AsNoTracking().ToListAsync();
            var test = (from a in db.Address
                                                            join u in db.Users
                                                            on a.UserId equals u.Id
                                                            select new GetAddressModel()
                                                            {
                                                                Address = a.AddressName,
                                                                Username = u.Name
                                                            }).AsQueryable();
            return addresses;
        }
    }
}

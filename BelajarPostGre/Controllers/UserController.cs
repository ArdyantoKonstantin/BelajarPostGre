using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BelajarPostGre.Model;
using BelajarPostGre.Entity;
using Microsoft.EntityFrameworkCore;

namespace BelajarPostGre.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDbContext db;

        public UserController(UserDbContext _db)
        {
            this.db = _db;
        }

        [HttpPost("/register")]
        public async Task<int> RegisterUser([FromBody] RegisterUserModel model)
        {
            if(model.Username == null || model.Email == null || model.Password == null)
            {
                return 1;
            }

            var newUser = new User()
            {
                Name = model.Username,
                Email = model.Email,
                Password = model.Password
            };
            db.Users.Add(newUser);
            await db.SaveChangesAsync();
            return 0;
       }

        [HttpGet("/getUser")]
        public async Task<List<GetUserModel>> GetUser()
        {
            var userList = await db.Users.Select(s => new GetUserModel()
            {
                Username = s.Name,
                Email = s.Email
            }).ToListAsync();

            return userList;
        }

        [HttpPut("/updateUser")]
        public async Task<bool> UpdateUser([FromBody] UpdateUserModel model)
        {
            if (model.Username == null || model.Password == null)
            {
                return false;
            }
            var userToUpdate = await db.Users.Where(w => w.Id == model.Id).FirstOrDefaultAsync();
            if (userToUpdate == null)
            {
                return false;
            }
            userToUpdate.Name = model.Username;
            userToUpdate.Password = model.Password;

            await db.SaveChangesAsync();
            return true;
        }

        [HttpPut("/deleteUser")]
        public async Task<bool> DeleteUser(int id)
        {
            var userToDelete = await db.Users.FirstOrDefaultAsync(w => w.Id == id);
            if(userToDelete == null)
            {
                return false;
            }
            db.Users.Remove(userToDelete);
            await db.SaveChangesAsync();
            return true;
        }

            
    }
}

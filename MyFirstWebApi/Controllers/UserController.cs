using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEFLibrary.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
       // public UserController(IUserManager manager) { }

        [HttpGet]
        [Route("Users")]
        [SwaggerResponse(200, "", typeof(IEnumerable<User>))]
        [SwaggerResponse(204, "")]
        [SwaggerResponse(500, "")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                using (var ctx = new EftestDbContext())
                {
                    var users = ctx.Users.ToArray();
                    if (users.Length == 0)
                    {
                        NoContent();
                    }
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpGet]
        [Route("Users/{id}")]
        [SwaggerResponse(200, "", typeof(User))]
        [SwaggerResponse(404, "")]
        [SwaggerResponse(500, "")]
        public ActionResult<User> GetUsers(int id)
        {
            try
            {
                using (var ctx = new EftestDbContext())
                {
                    var user = ctx.Users.FirstOrDefault(u => u.Id == id);

                    if (user == null)
                    {
                        return NotFound();
                    }
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }

        [HttpPost]
        [Route("Users/AddUser")]
        [SwaggerResponse(201, "")]
        [SwaggerResponse(400, "")]
        [SwaggerResponse(500, "")]
        public ActionResult AddUser(User user)
        {
            try
            {
                using (var ctx = new EftestDbContext())
                {
                    if (user != null)
                    {
                        ctx.Users.Add(user);
                        ctx.SaveChanges();

                        return Created();
                    }
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //
                return StatusCode(500, ""); 
            }
        }


        [HttpDelete]
        [Route("Users/DeleteUser/{id}")]
        [SwaggerResponse(200, "")]
        [SwaggerResponse(404, "")]
        [SwaggerResponse(500, "")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                using (var ctx = new EftestDbContext())
                {
                    var user = ctx.Users.FirstOrDefault(u => u.Id == id);

                    if (user != null)
                    {
                        ctx.Users.Remove(user);
                        ctx.SaveChanges();

                        return Ok(user);
                    }
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "");
            }
        }
    }
}

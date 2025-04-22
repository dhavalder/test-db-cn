using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace test_db_cn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContex _contex;
        public UserController(AppDbContex contex)
        {
            _contex = contex;
        }

        [HttpGet("GetUsers", Name = "GetUsers")]
        public async Task<IActionResult> GetUsers(int pageNumber = 1, int pageSize = 20)
        {
            var totalUsers = await _contex.Users.LongCountAsync();

            var users = _contex.Users.OfType<Users>()
                .OrderBy(u => u.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var responce = new
            {
                TotalCount = totalUsers,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalUsers / (double)pageSize),
                Data = users
            };
            
            return Ok(responce);
        }
    }
}

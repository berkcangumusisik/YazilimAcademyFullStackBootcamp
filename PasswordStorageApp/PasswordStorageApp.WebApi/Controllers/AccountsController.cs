using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordStorageApp.WebApi.Persistence;

namespace PasswordStorageApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        [HttpGet] 
        public IActionResult GetAll()
        {
            var accounts = FakdeDbContext.Accounts.ToList();
            return Ok(accounts);
        }

        [HttpGet("{id:guid}")] 
        public IActionResult GetById(Guid id)
        {
            var account = FakdeDbContext.Accounts.FirstOrDefault(ac => ac.Id == id);
            if (account is null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("id is not valid. Please do not send empty guids for god sake!");
            }

            var account = FakdeDbContext.Accounts.FirstOrDefault(ac => ac.Id == id);
            if (account is null)
            {
                return NotFound();
            }
            FakdeDbContext.Accounts.Remove(account);
            return NoContent();
        }
    }
}

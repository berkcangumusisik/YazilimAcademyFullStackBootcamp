using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordStorageApp.Domain.Dtos;
using PasswordStorageApp.WebApi.Persistence;
using PasswordStorageApp.WebApi.Persistence.Contexts;

namespace PasswordStorageApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AccountsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var accounts = await _dbContext
                .Accounts
                .AsNoTracking()
                .Select(ac => AccountGetAllDto.MapFromAccount(ac))
                .ToListAsync(cancellationToken);
            // AsNoTracking() metodu veritabanından veri çekerken veriyi takip etmemizi sağlar.
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AccountCreateDto newAccount, CancellationToken cancellationToken)
        {
           var account = newAccount.ToAccount();

           _dbContext.Accounts.Add(account);

           await _dbContext.SaveChangesAsync(cancellationToken);

           return Ok(new { data = account.Id, message = "The account was added successfully" });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, AccountUpdateDto updateDto, CancellationToken cancellationToken)
        {
            if(id != updateDto.Id)
            {
                return BadRequest("The id in the url does not match the id in the body");
            }
            var account = _dbContext.Accounts.FirstOrDefault(ac => ac.Id == id);
            var updatedAccount = updateDto.ToAccount(account);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Ok(new { data = updatedAccount, message = "The account was uptaded successfully" });
        }

        [HttpGet("{id:guid}")] 
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var account = await _dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(ac => ac.Id == id, cancellationToken);
            if (account is null)
            {
                return NotFound();
            }
            return Ok(AccountGetByIdDto.MapFromAccount(account));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("id is not valid. Please do not send empty guids for god sake!");
            }

            var account = _dbContext.Accounts.FirstOrDefault(ac => ac.Id == id);
            if (account is null)
            {
                return NotFound();
            }
            _dbContext.Accounts.Remove(account);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}

/*
 * ORM : Object Relational Mapping (Yazılım nesneleri ile veritabanı arasında bir eşleme yapar)
 * ORM bulunduğu dildeki veriyi bir veri tabanı ile ilişkilendirir.
 * 
 */
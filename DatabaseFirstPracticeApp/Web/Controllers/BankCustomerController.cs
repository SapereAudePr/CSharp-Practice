using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankCustomerController : ControllerBase
    {
        private readonly BankDbContext dbContext;

        public BankCustomerController(BankDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? filterOn, string? filterBy, string? sortOn, bool isAscending = false, int pageNumber = 1, int pageSize = 10)
        {
            var db = dbContext.BankChurn.AsQueryable();

            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
            {
                db = filterOn switch
                {
                    "Surname" => db.Where(x => x.Surname.Contains(filterBy)),
                    "Geography" => db.Where(x => x.Geography.Contains(filterBy)),
                    _ => db
                };
            }

            if (!string.IsNullOrEmpty(sortOn))
            {
                db = sortOn switch
                {
                    "CustomerId" => isAscending ? db.OrderBy(c => c.CustomerId) : db.OrderByDescending(c => c.CustomerId),
                    "CreditScore" => isAscending ? db.OrderBy(c => c.CreditScore) : db.OrderByDescending(c => c.CreditScore),
                    "NumOfProducts" => isAscending ? db.OrderBy(c => c.NumOfProducts) : db.OrderByDescending(c => c.NumOfProducts),
                    "Balance" => isAscending ? db.OrderBy(c => c.Balance) : db.OrderByDescending(c => c.Balance),
                    "Age" => isAscending ? db.OrderBy(c => c.Age) : db.OrderByDescending(c => c.Age),
                    "EstimatedSalary" => isAscending ? db.OrderBy(c => c.EstimatedSalary) : db.OrderByDescending(c => c.EstimatedSalary),
                    "Tenure" => isAscending ? db.OrderBy(c => c.Tenure) : db.OrderByDescending(c => c.Tenure),

                    _ => db.OrderBy(x => x.CustomerId)
                };
            }
            else
            {
                db.OrderBy(x => x.CustomerId);
            }

            var skipped = (pageNumber - 1) * pageSize;

            var result = await db.Skip(skipped).Take(pageSize).ToListAsync();

            return Ok(db);
        }
    }
}

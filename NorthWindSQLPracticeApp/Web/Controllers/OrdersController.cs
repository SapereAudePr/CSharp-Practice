using Application.DTO;
using Application.Map;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly MyDbContext dbContext;

    public OrdersController(MyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        string? filterOn,
        string? filterBy,
        string? sortOn,
        bool isAscending = false,
        int pageNumber = 1,
        int pageSize = 10)
    {
        var orders = dbContext.Orders
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterBy))
        {
            orders = filterOn switch
            {
                "ShipCity" => orders.Where(x => x.ShipCity != null && x.ShipCity.Contains(filterBy)),
                "ShipName" => orders.Where(x => x.ShipName != null && x.ShipName.Contains(filterBy)),
                "ShipAddress" => orders.Where(x => x.ShipAddress != null && x.ShipAddress.Contains(filterBy)),
                "ShipCountry" => orders.Where(x => x.ShipCountry != null && x.ShipCountry.Contains(filterBy)),
                _ => orders
            };
        }

        if (!string.IsNullOrEmpty(sortOn))
        {
            orders = sortOn switch
            {
                "OrderID" => isAscending ? orders.OrderBy(x => x.OrderId) : orders.OrderByDescending(x => x.OrderId),
                "CustomerId" => isAscending ? orders.OrderBy(x => x.CustomerId) : orders.OrderByDescending(x => x.CustomerId),
                "EmployeeId" => isAscending ? orders.OrderBy(x => x.EmployeeId) : orders.OrderByDescending(x => x.EmployeeId),
                "OrderDate" => isAscending ? orders.OrderBy(x => x.OrderDate) : orders.OrderByDescending(x => x.OrderDate),
                "RequiredDate" => isAscending ? orders.OrderBy(x => x.RequiredDate) : orders.OrderByDescending(x => x.RequiredDate),
                "ShippedDate" => isAscending ? orders.OrderBy(x => x.ShippedDate) : orders.OrderByDescending(x => x.ShippedDate),
                "ShipPostalCode" => isAscending ? orders.OrderBy(x => x.ShipPostalCode) : orders.OrderByDescending(x => x.ShipPostalCode),
                _ => orders.OrderBy(x => x.OrderId)
            };
        }
        else
        {
            orders = orders.OrderBy(x => x.OrderId);
        }

        var result = await orders
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListDto()
            .ToListAsync();

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await dbContext.Orders
            .Include(x => x.Employee)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.OrderId == id);
        if (result is null)
            return NotFound();

        return Ok(result.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderDto orderDto)
    {
        var entity = orderDto.CreateToDomain();

        dbContext.Orders.Add(entity);

        await dbContext.SaveChangesAsync();

        var responseDto = entity.ToDto();

        return CreatedAtAction(nameof(GetById), new { id = responseDto.OrderId }, responseDto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderDto orderDto)
    {
        var orderDomain = await dbContext.Orders.FindAsync(id);
        if (orderDomain is null)
            return NotFound();

        orderDomain.MapUpdateToDomain(orderDto);

        await dbContext.SaveChangesAsync();

        return Ok(orderDomain.ToDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var toDelete = await dbContext.Orders.FindAsync(id);
        if (toDelete is null)
            return NotFound();

        dbContext.Remove(toDelete);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}

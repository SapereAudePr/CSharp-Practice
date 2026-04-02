using Application.DTO;
using Domain.Entity;

namespace Application.Map;

public static class OrderMapper
{
    public static IQueryable<OrderDto> ToListDto(this IQueryable<Order> query)
    {
        return query.Select(x => new OrderDto
        {
            OrderId = x.OrderId,
            OrderDate = x.OrderDate,
            RequiredDate = x.RequiredDate,
            ShippedDate = x.ShippedDate,
            ShipVia = x.ShipVia,
            Freight = x.Freight,
            ShipName = x.ShipName,
            ShipAddress = x.ShipAddress,
            ShipCity = x.ShipCity,
            ShipRegion = x.ShipRegion,
            ShipPostalCode = x.ShipPostalCode,
            ShipCountry = x.ShipCountry,
            CustomerId = x.CustomerId,
            EmployeeId = x.EmployeeId
        });
    }

    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto()
        {
            OrderId = order.OrderId,
            OrderDate = order.OrderDate,
            RequiredDate = order.RequiredDate,
            ShippedDate = order.ShippedDate,
            ShipVia = order.ShipVia,
            Freight = order.Freight,
            ShipName = order.ShipName,
            ShipCity = order.ShipCity,
            ShipAddress = order.ShipAddress,
            ShipRegion = order.ShipRegion,
            ShipPostalCode = order.ShipPostalCode,
            ShipCountry = order.ShipCountry,
            CustomerId = order.CustomerId,
            EmployeeId = order.EmployeeId
        };
    }

    public static Order ToDomain(this OrderDto orderDto)
    {
        return new Order()
        {
            OrderId = orderDto.OrderId,
            OrderDate = orderDto.OrderDate,
            RequiredDate = orderDto.RequiredDate,
            ShippedDate = orderDto.ShippedDate,
            ShipVia = orderDto.ShipVia,
            Freight = orderDto.Freight,
            ShipName = orderDto.ShipName,
            ShipCity = orderDto.ShipCity,
            ShipAddress = orderDto.ShipAddress,
            ShipRegion = orderDto.ShipRegion,
            ShipPostalCode = orderDto.ShipPostalCode,
            ShipCountry = orderDto.ShipCountry,
            CustomerId = orderDto.CustomerId,
            EmployeeId = orderDto.EmployeeId
        };
    }
}

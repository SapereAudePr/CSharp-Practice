using Domain.Models.Domain;
using Domain.Models.DTO;

namespace Domain.Mappings;

public static class RestaurantMap
{
    public static List<RestaurantDto> ToListDto(this List<Restaurant> restaurants)
    {
        return restaurants.Select(x => x.ToDto()).ToList();
    }

    public static RestaurantDto ToDto(this Restaurant restaurant)
    {
        return new RestaurantDto()
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Capacity = restaurant.Capacity,
            ReviewPoint = restaurant.ReviewPoint,
            StartShiftTime = restaurant.StartShiftTime,
            EndShiftTime = restaurant.EndShiftTime,
            BuiltDate = restaurant.BuiltDate,
            CreationTime = restaurant.CreationTime,
            RegionId = restaurant.RegionId
        };
    }

    public static Restaurant ToDomain(this RestaurantDto restaurantDto)
    {
        return new Restaurant()
        {
            Id = restaurantDto.Id,
            Name = restaurantDto.Name,
            Capacity = restaurantDto.Capacity,
            ReviewPoint = restaurantDto.ReviewPoint,
            StartShiftTime = restaurantDto.StartShiftTime,
            EndShiftTime = restaurantDto.EndShiftTime,
            BuiltDate = restaurantDto.BuiltDate,
            CreationTime = restaurantDto.CreationTime,
            RegionId = restaurantDto.RegionId
        };
    }

    public static Restaurant RequestToDomain(this RestaurantCreateRequestDto requestDto)
    {
        return new Restaurant()
        {
            Name = requestDto.Name,
            Capacity = requestDto.Capacity,
            ReviewPoint = requestDto.ReviewPoint,
            StartShiftTime = requestDto.StartShiftTime,
            EndShiftTime = requestDto.EndShiftTime,
            BuiltDate = requestDto.BuiltDate,
            RegionId = requestDto.RegionId
        };
    }

    public static Restaurant RequestToDomain(this RestaurantUpdateRequestDto requestDto)
    {
        return new Restaurant()
        {
            Name = requestDto.Name,
            Capacity = requestDto.Capacity,
            ReviewPoint = requestDto.ReviewPoint,
            StartShiftTime = requestDto.StartShiftTime,
            EndShiftTime = requestDto.EndShiftTime,
            BuiltDate = requestDto.BuiltDate,
            RegionId = requestDto.RegionId
        };
    }
}

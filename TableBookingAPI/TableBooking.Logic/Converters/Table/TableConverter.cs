using TableBooking.DTOs;

namespace TableBooking.Logic.Converters.Table
{
    public class TableConverter : ITableConverter
    {
        public TableDto TableToTableDto(Model.Models.Table table)
        {
            return new TableDto
            {
                RestaurantId = table.Restaurant.Id,
                NumberOfSeats = table.NumberOfSeats
            };
        }
    }
}
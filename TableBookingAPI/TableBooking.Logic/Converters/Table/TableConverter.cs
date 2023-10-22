using TableBooking.DTOs;

namespace TableBooking.Logic.Converters.Table
{
    public class TableConverter : ITableConverter
    {
        public TableDTO TableToTableDto(Model.Models.Table table)
        {
            return new TableDTO
            {
                RestaurantId = table.Restaurant.Id,
                NumberOfSeats = table.NumberOfSeats
            };
        }
    }
}
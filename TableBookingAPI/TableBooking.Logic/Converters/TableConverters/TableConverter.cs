using TableBooking.Model.Dtos.TableDtos;
using TableBooking.Model.Models;

namespace TableBooking.Logic.Converters.TableConverters
{
    public class TableConverter : ITableConverter
    {
        public TableDto TableToTableDto(Table table)
        {
            return new TableDto
            {
                RestaurantId = table.Restaurant.Id,
                NumberOfSeats = table.NumberOfSeats
            };
        }
    }
}
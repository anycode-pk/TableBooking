using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableBooking.DTOs;
using TableBooking.Model;

namespace TableBooking.Logic.Converters.Table;

public class TableConverter : ITableConverter
{
    public TableDTO TableToTableDto(Model.Table table)
    {
        return new TableDTO
        {
            RestaurantId = table.Restaurant.Id,
            NumberOfSeats = table.NumberOfSeats
        };
    }
}
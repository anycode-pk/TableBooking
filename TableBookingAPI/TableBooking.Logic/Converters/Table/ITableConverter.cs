using TableBooking.DTOs;

namespace TableBooking.Logic.Converters.Table
{
    public interface ITableConverter
    {
        public TableDto TableToTableDto(Model.Models.Table table);
    }
}

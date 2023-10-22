using TableBooking.DTOs;

namespace TableBooking.Logic.Converters.Table
{
    public interface ITableConverter
    {
        public TableDTO TableToTableDto(Model.Models.Table table);
    }
}

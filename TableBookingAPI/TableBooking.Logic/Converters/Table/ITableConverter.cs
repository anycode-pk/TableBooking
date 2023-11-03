using TableBooking.Model.Dtos.TableDtos;

namespace TableBooking.Logic.Converters.Table
{
    public interface ITableConverter
    {
        public TableDto TableToTableDto(Model.Models.Table table);
    }
}

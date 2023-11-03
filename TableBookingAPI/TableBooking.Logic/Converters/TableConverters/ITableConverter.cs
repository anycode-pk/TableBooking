using TableBooking.Model.Dtos.TableDtos;
using TableBooking.Model.Models;

namespace TableBooking.Logic.Converters.TableConverters
{
    public interface ITableConverter
    {
        public TableDto TableToTableDto(Table table);
    }
}

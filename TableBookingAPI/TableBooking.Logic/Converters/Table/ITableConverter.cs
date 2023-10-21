using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableBooking.DTOs;

namespace TableBooking.Logic.Converters.Table
{
    public interface ITableConverter
    {
        public TableDTO TableToTableDto(Model.Table table);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableBooking.Logic.Interfaces
{
    public interface IUnitOfWork
    {
        public IBookingRepository BookingRepository { get; }
        public IRestaurantRepository RestaurantRepository { get; }
        public ITableRepository TableRepository { get; }
        public IUserRepository UserRepository { get; }
        void Dispose();
        Task SaveChangesAsync();
    }
}

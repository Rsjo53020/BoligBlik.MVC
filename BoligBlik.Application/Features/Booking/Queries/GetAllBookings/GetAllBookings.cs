using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.Application.Features.Booking.Queries.GetAllBookings
{
    public class GetAllBookings
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllBookings(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

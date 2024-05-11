using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.Application.Features.Booking.Commands.UpdateBooking
{
    public class UpdateBooking
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBooking(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

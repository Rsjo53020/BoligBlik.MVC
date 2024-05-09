using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.Application.Features.Booking.Commands.DeleteBooking
{
    public class DeleteBooking
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBooking(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

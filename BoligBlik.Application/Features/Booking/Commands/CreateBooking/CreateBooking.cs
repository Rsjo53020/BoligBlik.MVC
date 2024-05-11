using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.Application.Features.Booking.Commands.CreateBooking
{
    public class CreateBooking
    {
        public readonly IUnitOfWork _unitOfWork;

        public CreateBooking(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
    }
}

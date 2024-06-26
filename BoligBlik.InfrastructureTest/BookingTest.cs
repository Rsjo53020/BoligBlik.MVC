﻿using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using BoligBlik.Persistence.Repositories.Bookings;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BoligBlik.InfrastructureTest
{
    /// <summary>
    /// Unit Test, Testing Booking.Create factory. 
    /// </summary>
    public class BookingTest
    {
        [Theory]

        [InlineData(0, 1, false, false)]     //starttime is tome now (should fail)
        [InlineData(1, 2, false, true)]     //times are okay (should succed)
        [InlineData(2, 1, false, false)]   //starttime bigger than endtime (should fail)
        [InlineData(-1, 1, false, false)] //starttime less than time now (should fail)
        [InlineData(1, 2, true, false)]  //times are okay, but booking is overlapping (should fail)

        public void TestBookingOverlapping(int start, int end, bool overlappingResult, bool expectedResult)
        {
            //arrange
            var bookingService = new Mock<IBookingDomainService>();

            var bookingItem = new BookingItem()
            {
                Description = "description",
                Id = Guid.NewGuid(),
                Name = "name",
                Price = 0,
                Rules = "rules",
                Repairs = "repairs"
            };

            //Define if booking is overlapping
            bookingService.Setup(x => x.IsBookingOverlapping(It.IsAny<Booking>())).Returns(overlappingResult);
            bool result = false;
            
            //act
            try
            {   //if validation succeds set result to true
                var booking = Booking.Create(DateTime.Now.AddDays(start), DateTime.Now.AddDays(end), bookingItem, Guid.NewGuid(), bookingService.Object);
                result = true;
            }
            catch
            {
                //if validation fails set result to false
                result = false;
            }

            //assert
            Assert.True(result == expectedResult);
        }
    }
}

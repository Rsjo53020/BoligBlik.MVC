using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using BoligBlik.Persistence.Repositories.Bookings;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BoligBlik.InfrastructureTest
{
    public class BookingTest
    {
        private void SetUp()
        {


        }
        [Theory]
        [InlineData(0, 1, false, false)]
        [InlineData(1, 2, false, true)]
        [InlineData(2, 1, false, false)]
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
            //define if booking is overlapping
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

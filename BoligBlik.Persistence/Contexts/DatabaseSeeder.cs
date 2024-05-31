using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;
using BoligBlik.Entities;
using BoligBlik.Persistence.Contexts.Interfaces;

namespace BoligBlik.Persistence.Contexts
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly BoligBlikContext _context;

        public DatabaseSeeder(BoligBlikContext context)
        {
            _context = context;
        }

        public void SeedDB()
        {
            SeedUsers();
            SeedBoardMembers();
            SeedMeeting();
            SeedBookingItem();
            SeedBooking();
            SeedAddress();

        }




        internal void SeedUsers()
        {
            if (_context.Users.Any()) return;

            var users = new User[]
            {
                new User
                {
                    FirstName = "Ronni",
                    LastName = "Jorgensen",
                    EmailAddress = "Ronni@Mail.dk",
                    PhoneNumber = "+1234567890",
                },
                new User
                {
                    FirstName = "Christoffer",
                    LastName = "Skafte",
                    EmailAddress = "Skafte@Mail.dk",
                    PhoneNumber = "+9876543210",
                },
                new User
                {
                    FirstName = "Alexander",
                    LastName = "Larsen",
                    EmailAddress = "Alex@Mail.dk",
                    PhoneNumber = "+9876543210",
                },
            };
            foreach (var user in users)
            {
                if (!_context.Users.Any(existingUser => existingUser.EmailAddress == user.EmailAddress))
                {
                    _context.Users.Add(user);
                }
            }
            _context.SaveChanges();
        }

        internal void SeedAddress()
        {
            if (_context.Adresses.Any()) return;

            var Address = new Address[]
            {

                new Address
                {
                    Street = "Findlandsvej",
                    HouseNumber = "51",
                    Floor = "1",
                    DoorNumber = "th",
                    PostalCode = new PostalCode("Vejle", "7100"),
                    Bookings = _context.Bookings.Where(b => b.Item.Name == "Vaskemaskine").ToList(),
                    Users = _context.Users.Where(b => b.EmailAddress == "Alex@Mail.dk" || b.EmailAddress == "Skafte@Mail.dk").ToList()

                },
                new Address
                {
                    Street = "Findlandsvej",
                    HouseNumber = "51",
                    Floor = "2",
                    DoorNumber = "th",
                    PostalCode = new PostalCode("Vejle", "7100"),
                    Bookings = _context.Bookings.Where(b => b.Item.Name == "Trailer").ToList(),
                    Users = _context.Users.Where(b => b.EmailAddress == "Ronni@Mail.dk").ToList()
                }
            };

            foreach (Address adress in Address)
            {
                if (!_context.Adresses.Any(existing => existing.DoorNumber == adress.DoorNumber && existing.Floor == adress.Floor))
                {
                    _context.Adresses.Add(adress);
                }
            }
            _context.SaveChanges();
        }

        internal void SeedBoardMembers()
        {
            if (_context.BoardMembers.Any()) return;

            var boardMembers = new BoardMember[]
            {
                new BoardMember
                {
                    Title = "Formand",
                    Description = "Formandspost",
                    User = _context.Users.FirstOrDefault(user => user.EmailAddress == "Alex@Mail.dk")
                },
                new BoardMember
                {
                    Title = "Næstformand",
                    Description = "Næstformandspost",
                    User = _context.Users.FirstOrDefault(user => user.EmailAddress == "Skafte@Mail.dk")
                },
                new BoardMember
                {
                    Title = "Kasser",
                    Description = "Kasserpost",
                    User = _context.Users.FirstOrDefault(user => user.EmailAddress == "Ronni@Mail.dk")
                }
            };

            foreach (var boardMember in boardMembers)
            {
                if (!_context.BoardMembers.Any(existingBoardMember => existingBoardMember.Title == boardMember.Title))
                {
                    _context.BoardMembers.Add(boardMember);
                }
            }

            _context.SaveChanges();
        }


        internal void SeedMeeting()
        {
            if (_context.Meetings.Any()) return;

            var meetings = new Meeting[]
            {
                new Meeting
                {
                    Start = DateTime.Now,
                    End = DateTime.Now + TimeSpan.FromHours(5),
                    Description = "Møde ang. Ronni",

                },
                new Meeting
                {
                    Start = DateTime.Now,
                    End = DateTime.Now + TimeSpan.FromHours(5),
                    Description = "Vigigt Møde",
                }
            };

            foreach (var meeting in meetings)
            {
                _context.Meetings.Add(meeting);
            }

            _context.SaveChanges();
        }

        internal void SeedBookingItem()
        {
            if (_context.BookingItems.Any()) return;

            var bookingItems = new BookingItem[]
            {
                new BookingItem
                {
                    Name = "Vaskemaskine",
                    Price = 20,
                    Description = "Booking af vaskemaskine",
                    Rules = "Kan bookes alle dage",
                    Repairs = "Ingen reperationer",

                },
                new BookingItem
                {
                    Name = "Trailer",
                    Price = 100,
                    Description = "The budget for the year",
                    Rules = "test",
                    Repairs = "te",
                }
            };

            foreach (var bookingItem in bookingItems)
            {
                _context.BookingItems.Add(bookingItem);
            }

            _context.SaveChanges();
        }

        internal void SeedBooking()
        {
            if (_context.Bookings.Any()) return;

                var bookings = new Booking[]
            {
                new Booking(
                    DateTime.Now.AddHours(1),
                    DateTime.Now.AddHours(2),
                     _context.BookingItems.FirstOrDefault(i => i.Name == "Vaskemaskine")),

                new Booking(
                    DateTime.Now.AddHours(3),
                    DateTime.Now.AddHours(4),
                    _context.BookingItems.FirstOrDefault(i => i.Name == "Vaskemaskine")),

                new Booking(
                DateTime.Now.AddHours(6),
                DateTime.Now.AddHours(7),
                _context.BookingItems.FirstOrDefault(i => i.Name == "Trailer"))
            };


            foreach (var booking in bookings)
            {
                _context.Bookings.Add(booking);
            }

            _context.SaveChanges();
        }


    }
}

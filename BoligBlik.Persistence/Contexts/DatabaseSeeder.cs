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
            //SeedUsers();
            //SeedBoardMembers();
            //SeedPayment();
            //SeedMeeting();
            //SeedDocument();
            //SeedBookingItem();
            //SeedAddress();
            //SeedProperty();
            //SeedBooking();
        }

        //internal void SeedUsers()
        //{
        //    var users = new User[]
        //    {
        //        new User
        //        {
        //            Id = Guid.NewGuid(),
        //            FirstName = "Ronni",
        //            LastName = "Jorgensen",
        //            EmailAddress = "Ronni@Mail.dk",
        //            Role = "Admin",
        //            PhoneNumber = "+1234567890",
        //        },
        //        new User
        //        {
        //            Id = Guid.NewGuid(),
        //            FirstName = "Christoffer",
        //            LastName = "Skafte",
        //            EmailAddress = "Skafte@Mail.dk",
        //            Role = "Kasser",
        //            PhoneNumber = "+9876543210",
        //        },
        //        new User
        //        {
        //            Id = Guid.NewGuid(),
        //            FirstName = "Alexander",
        //            LastName = "Larsen",
        //            EmailAddress = "Alex@Mail.dk",
        //            Role = "Næstformand",
        //            PhoneNumber = "+9876543210",
        //        },
        //    };
        //    foreach (var user in users)
        //    {
        //        if (!_context.Users.Any(existingUser => existingUser.EmailAddress == user.EmailAddress))
        //        {
        //            _context.Users.Add(user);
        //        }
        //    }
        //    _context.SaveChanges();
        //}

        //internal void SeedAddress()
        //{
        //    var Address = new Address[]
        //    {
        //        new Address
        //        {
        //            Street = "Vejlevej",
        //            HouseNumber = "10",
        //            Floor = "1",
        //            DoorNumber = "th",
        //            PostalCode = new PostalCode("Vejle", "7100"),
        //            Users = _context.Users.Where(user => user.EmailAddress == "Alex@Mail.dk").ToList()
        //        },
        //        new Address
        //        {
        //            Street = "lundesvej",
        //            HouseNumber = "10",
        //            Floor = "1",
        //            DoorNumber = "th",
        //            PostalCode = new PostalCode("Vejle", "7100"),
        //            Users = _context.Users.Where(user => user.EmailAddress != "Alex@Mail.dk").ToList()
        //        }
        //    };

        //    foreach (Address adress in Address)
        //    {
        //        _context.Adresses.Add(adress);
        //    }
        //    _context.SaveChanges();
        //}

        //internal void SeedBoardMembers()
        //{
        //    var boardMembers = new BoardMember[]
        //    {
        //        new BoardMember
        //        {
        //            Id = Guid.NewGuid(),
        //            Title = "Formand",
        //            Description = "Formandspost",
        //            User = _context.Users.FirstOrDefault(user => user.EmailAddress == user.EmailAddress)
        //        },
        //        new BoardMember
        //        {
        //            Id = Guid.NewGuid(),
        //            Title = "Næstformand",
        //            Description = "Næstformandspost",
        //            User = _context.Users.FirstOrDefault(user => user.EmailAddress == user.EmailAddress)
        //        },
        //        new BoardMember
        //        {
        //            Id = Guid.NewGuid(),
        //            Title = "Kasser",
        //            Description = "Kasserpost",
        //            User = _context.Users.FirstOrDefault(user => user.EmailAddress == user.EmailAddress)
        //        }
        //    };

        //    foreach (var boardMember in boardMembers)
        //    {
        //        if (!_context.BoardMembers.Any(existingBoardMember => existingBoardMember.Title == boardMember.Title))
        //        {
        //            _context.BoardMembers.Add(boardMember);
        //        }
        //    }

        //    _context.SaveChanges();
        //}

        //internal void SeedPayment()
        //{
        //    var payments = new Payment[]
        //    {
        //        new Payment
        //        {
        //            Amount = 100,
        //            Date = DateOnly.FromDateTime(DateTime.Now),
        //            Status = "Betalt",
        //            User = _context.Users.FirstOrDefault(user => user.EmailAddress == user.EmailAddress)
        //        },
        //        new Payment
        //        {
        //            Amount = 200,
        //            Date = DateOnly.FromDateTime(DateTime.Now),
        //            Status = "Afventer betaling",
        //            User = _context.Users.FirstOrDefault(user => user.EmailAddress == user.EmailAddress)
        //        }
        //    };

        //    foreach (var payment in payments)
        //    {
        //        _context.Payments.Add(payment);
        //    }

        //    _context.SaveChanges();
        //}

        //internal void SeedMeeting()
        //{
        //    var meetings = new Meeting[]
        //    {
        //        new Meeting
        //        {
        //            Id = Guid.NewGuid(),
        //            Start = DateOnly.FromDateTime(DateTime.Now),
        //            End = DateOnly.FromDateTime(DateTime.Now + TimeSpan.FromHours(5)),
        //            Description = "Møde ang. Ronni",

        //        },
        //        new Meeting
        //        {
        //            Id = Guid.NewGuid(),
        //            Start = DateOnly.FromDateTime(DateTime.Now),
        //            End = DateOnly.FromDateTime(DateTime.Now + TimeSpan.FromHours(5)),
        //            Description = "Vigigt Møde",
        //        }
        //    };

        //    foreach (var meeting in meetings)
        //    {
        //        _context.Meetings.Add(meeting);
        //    }

        //    _context.SaveChanges();
        //}

        //internal void SeedDocument()
        //{
        //    var documents = new Document[]
        //    {
        //        new Document
        //        {
        //            Id = Guid.NewGuid(),
        //            Title = "Møde Referat",
        //            Description = "Referat af møde",
        //            Category = "Referat",
        //        },
        //        new Document
        //        {
        //            Id = Guid.NewGuid(),
        //            Title = "Nye vedtægter",
        //            Description = "Vigtige vedtægter",
        //            Category = "Vedtægter",
        //        }
        //    };

        //    foreach (var document in documents)
        //    {
        //        _context.Documents.Add(document);
        //    }

        //    _context.SaveChanges();
        //}

        //internal void SeedBookingItem()
        //{
        //    var bookingItems = new BookingItem[]
        //    {
        //        new BookingItem
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Vaskemaskine",
        //            Price = 20,
        //            Description = "Booking af vaskemaskine",
        //            Rules = "Kan bookes alle dage",
        //            Repairs = "Ingen reperationer",

        //        },
        //        new BookingItem
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "test",
        //            Price = 100,
        //            Description = "The budget for the year",
        //            Rules = "test",
        //            Repairs = "te",
        //        }
        //    };

        //    foreach (var bookingItem in bookingItems)
        //    {
        //        _context.BookingItems.Add(bookingItem);
        //    }

        //    _context.SaveChanges();
        //}

        //internal void SeedBooking()
        //{
        //    var bookings = new Booking[]
        //    {

        //    };

        //    foreach (var booking in bookings)
        //    {
        //        _context.Bookings.Add(booking);
        //    }

        //    _context.SaveChanges();
        //}

        //internal void SeedProperty()
        //{
        //    var properties = new Property[]
        //    {
        //        new Property
        //        {
        //            Id = Guid.NewGuid(),
        //            BoardMember = _context.BoardMembers.FirstOrDefault(t => t.Title == "Formand"),
        //            Addresses = new List<Address>()
        //            {
        //            }
        //        }
        //    };

        //    foreach (var user in _context.BoardMembers)
        //    {
        //        if (!_context.Properties.Any(property => property.BoardMember.Id == BoardMember.tit))
        //        {
        //            properties[0].Addresses.Add(user.Address);
        //        }
        //    }

        //    _context.Properties.AddRange(properties);
        //    _context.SaveChanges();
        //}
    }
}

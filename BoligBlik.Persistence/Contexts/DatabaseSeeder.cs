﻿using BoligBlik.Domain.Entities;
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
            SeedAddress();
            SeedBooking();
            SeedBookingItems();
            //SeedProperty();
        }


        internal void SeedBookingItems()
        {
            var bookingItems = new BookingItem[]
            {
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Vaskemaskine",
            Price = 20,
            Description = "Booking af vaskemaskine",
            Rules = "Kan bookes alle dage",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Tørretumbler",
            Price = 25,
            Description = "Booking af tørretumbler",
            Rules = "Kan bookes efter kl. 16:00",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Opvaskemaskine",
            Price = 15,
            Description = "Booking af opvaskemaskine",
            Rules = "Kan bookes alle hverdage",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Køleskab",
            Price = 30,
            Description = "Booking af køleskab",
            Rules = "Kan bookes i weekenden",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Ovn",
            Price = 20,
            Description = "Booking af ovn",
            Rules = "Kan bookes fra kl. 8:00 til 20:00",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Mikroovn",
            Price = 15,
            Description = "Booking af mikroovn",
            Rules = "Kan bookes i hverdagene",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Kaffemaskine",
            Price = 10,
            Description = "Booking af kaffemaskine",
            Rules = "Kan bookes fra kl. 7:00 til 22:00",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Blender",
            Price = 15,
            Description = "Booking af blender",
            Rules = "Kan bookes alle dage",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Grill",
            Price = 20,
            Description = "Booking af grill",
            Rules = "Kan bookes om sommeren",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Hårtørrer",
            Price = 10,
            Description = "Booking af hårtørrer",
            Rules = "Kan bookes i badetiden",
            Repairs = "Ingen reparationer"
        },
        new BookingItem
        {
            Id = Guid.NewGuid(),
            Name = "Strygejern",
            Price = 15,
            Description = "Booking af strygejern",
            Rules = "Kan bookes alle hverdage",
            Repairs = "Ingen reparationer"
        }
            };

            foreach (var bookingItem in bookingItems)
            {
                if (!_context.BookingItems.Any(bi => bi.Name == bookingItem.Name))
                {
                    _context.BookingItems.Add(bookingItem);
                }
            }

            _context.SaveChanges();
        }


        internal void SeedUsers()
        {
            var users = new User[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Ronni",
                    LastName = "Jorgensen",
                    EmailAddress = "Ronni@Mail.dk",
                    PhoneNumber = "+1234567890",
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Christoffer",
                    LastName = "Skafte",
                    EmailAddress = "Skafte@Mail.dk",
                    PhoneNumber = "+9876543210",
                },
                new User
                {
                    Id = Guid.NewGuid(),
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
            var Address = new Address[]
            {
                new Address
                {
                    Street = "Vejlevej",
                    HouseNumber = "10",
                    Floor = "1",
                    DoorNumber = "th",
                    PostalCode = new PostalCode("Vejle", "7100")
                },
                new Address
                {
                    Street = "lundesvej",
                    HouseNumber = "10",
                    Floor = "1",
                    DoorNumber = "th",
                    PostalCode = new PostalCode("Vejle", "7100")
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
            var boardMembers = new BoardMember[]
            {
                new BoardMember
                {
                    Id = Guid.NewGuid(),
                    Title = "Formand",
                    Description = "Formandspost",
                    User = _context.Users.FirstOrDefault(user => user.EmailAddress == "Alex@Mail.dk")
                },
                new BoardMember
                {
                    Id = Guid.NewGuid(),
                    Title = "Næstformand",
                    Description = "Næstformandspost",
                    User = _context.Users.FirstOrDefault(user => user.EmailAddress == "Skafte@Mail.dk")
                },
                new BoardMember
                {
                    Id = Guid.NewGuid(),
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
            var meetings = new Meeting[]
            {
                new Meeting
                {
                    Id = Guid.NewGuid(),
                    Start = DateTime.Now,
                    End = DateTime.Now + TimeSpan.FromHours(5),
                    Description = "Møde ang. Ronni",

                },
                new Meeting
                {
                    Id = Guid.NewGuid(),
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
            var bookingItems = new BookingItem[]
            {
                new BookingItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Vaskemaskine",
                    Price = 20,
                    Description = "Booking af vaskemaskine",
                    Rules = "Kan bookes alle dage",
                    Repairs = "Ingen reperationer",

                },
                new BookingItem
                {
                    Id = Guid.NewGuid(),
                    Name = "test",
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
            var bookings = new Booking[]
            {

            };

            foreach (var booking in bookings)
            {
                _context.Bookings.Add(booking);
            }

            _context.SaveChanges();
        }

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

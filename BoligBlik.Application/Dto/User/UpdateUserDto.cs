﻿using BoligBlik.Application.Dto.Adress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Dto.User
{
    public class UpdateUserDto
    {
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FormerRole { get; set; }
        public string Role { get; set; }
        public AddressDto Address { get; set; }
    }
}

﻿using BoligBlik.MVC.DTO.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BoligBlik.MVC.DTO.User
{
    // DTO for updating a user
    public class UpdateUserDTO : IEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string Role { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Dto.User
{
    public class DeleteUserDto
    {
        public DateOnly DeletedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public int UserId { get; set; }
        public string Reason { get; set; }
        public DateTime DeletionDate { get; set; }
    }
}

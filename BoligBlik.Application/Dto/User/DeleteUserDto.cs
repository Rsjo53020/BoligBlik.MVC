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
        public DateTime DeletedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public string Reason { get; set; }
        public DateTime DeletionDate { get; set; }
    }
}

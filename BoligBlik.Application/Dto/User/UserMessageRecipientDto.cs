using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Dto.User
{
    public class UserMessageRecipientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAdress { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Practical.Data
{
    public class UserService
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long ServiceId { get; set; }

        public UService Service { get; set; }
    }
}

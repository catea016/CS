using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordApplication
{
    class User
    {
        public string UserId { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}

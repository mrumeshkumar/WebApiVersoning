using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVersoning
{
    public class UserV1
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

    }
    public class UserV2
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public int Age { get; set; }

    }
}

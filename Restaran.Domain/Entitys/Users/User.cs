using Restaran.Domain.Common;
using Restaran.Domain.Entitys.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaran.Domain.Entitys.Users
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Food Foods { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaran.Domain.Common
{
    public class Auditable
    {
        public int Id { get; set; }
        public string IsCreate { get; set; } = DateTime.Now.ToString();
    }
}

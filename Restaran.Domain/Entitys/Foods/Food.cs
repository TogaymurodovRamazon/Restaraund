using Restaran.Domain.Common;
using Restaran.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaran.Domain.Entitys.Foods
{
    public class Food :Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Mail Mails { get; set; }
    }
}

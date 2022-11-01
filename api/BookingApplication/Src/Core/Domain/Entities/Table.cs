using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Table
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}

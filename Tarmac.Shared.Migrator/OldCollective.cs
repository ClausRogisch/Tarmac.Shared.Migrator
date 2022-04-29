using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarmac.Shared.Migrator
{
    public class OldCollective
    {
        public string Collective { get; set; }
        public string Description { get; set; }
        public int DateOfFormation { get; set; }
        public string Region { get; set; }
        public string ImageUrl { get; set; }
    }
}

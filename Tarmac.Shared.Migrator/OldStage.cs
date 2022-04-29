using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarmac.Shared.Migrator
{
    public class OldStage
    {
        public string StageName { get; set; }
        public string Collective { get; set; }
        public int Priority { get; set; }
        public string StageImageURL { get; set; }
        public bool Active { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int StageWidth { get; set; }
        public int StageHeight { get; set; }
        public int Rotation { get; set; }
    }
}

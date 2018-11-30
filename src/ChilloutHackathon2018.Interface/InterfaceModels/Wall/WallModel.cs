using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceModels.Wall
{
    public class WallModel
    {
        public long? WallModelID { get; set; }

        public long? UserID { get; set; }

        public string Details { get; set; }
    }
}

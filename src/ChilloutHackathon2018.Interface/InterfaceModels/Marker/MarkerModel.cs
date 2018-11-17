using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceModels.Marker
{
    public class MarkerModel
    {
        public long? ModelID { get; set; }

        public long? UserID { get; set; }

        public long? MarkerID { get; set; }

        public byte[] Picture { get; set; }

    }
}

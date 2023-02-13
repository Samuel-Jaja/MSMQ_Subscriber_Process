using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ_Subscriber_Process.Model
{
    public class WellDataModel
    {
        public string? FieldName { get; set; }
        public string? WellName { get; set; }
        public string? DrainagePoint { get; set; }
    }
}

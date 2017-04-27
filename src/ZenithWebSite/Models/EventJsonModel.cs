using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebSite.Models
{
    public class EventJsonModel
    {
        public int EventId { get; set; }

        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }

        public bool IsActive { get; set; }
        public string ActivityDesp { get; set; }
        public string dateTimeFromStr { get; set; }
        public string dateTimeToStr { get; set; }
    }
}

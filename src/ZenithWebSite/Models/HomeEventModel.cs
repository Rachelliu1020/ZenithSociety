using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebSite.Models.ZenithModels;

namespace ZenithWebSite.Models
{
    public class HomeEventModel
    {
        public DateTime Displaydate { get; set; }
        public List<EventJsonModel> Events { get; set; }
    }
}

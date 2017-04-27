using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace ZenithWebSite.Models.ZenithModels
{
    public class MyActivity
    {
        [Key]
        public int MyActivityId { get; set; }

        [Required]
        [Display(Name = "Activity Description", Order = 15004)]
        public string ActivityDesp { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy h:mm tt}")]
        [Display(Name = "Creation Date", Order = 15007)]
        public DateTime CreationDate { get; set; }

        public List<MyEvent> MyEvents { get; set; }

    }
}
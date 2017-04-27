using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ZenithWebSite.Models.ZenithModels.customValidation;

namespace ZenithWebSite.Models.ZenithModels
{
    public class MyEvent
    {
        [Key]
        public int MyEventId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Event Date From", Order = 15001)]
        [DateRange(ErrorMessage = "{0} exceed over a valid date range. It must be between 10 years before and after.")]
        public DateTime DateTimeFrom { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy h:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Event Date To", Order = 15002)]
        [DateGreaterThan("DateTimeFrom", ErrorMessage = "{0} is too later")]
        [DateRange(ErrorMessage = "{0} exceed over a valid date range. It must be between 10 years before and after.")]
        public DateTime DateTimeTo { get; set; }

        [Display(Name = "Active status", Order = 15004)]
        public bool IsActive { get; set; }


        [Display(Name = "Creator", Order = 15005)]
        public string Creator { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy h:mm tt}")]
        [Display(Name = "Creation Date", Order = 15006)]
        public DateTime CreationDate { get; set; }

        
        public int MyActivityId { get; set; }
        public MyActivity MyActivity{ get; set; }


    }
}
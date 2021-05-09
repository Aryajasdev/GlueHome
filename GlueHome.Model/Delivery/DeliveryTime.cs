using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GlueHome.Model.Delivery
{
    [ExcludeFromCodeCoverage]
    public class DeliveryTime 
    {       

        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }        
    }
}

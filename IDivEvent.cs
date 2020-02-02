using System;
using System.ComponentModel.DataAnnotations;

namespace Div
{
    public interface IDivEvent
    {
        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }
    }
}
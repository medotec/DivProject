using System;

namespace Div
{
    public class DivAssignment : DivBase, IDivEvent
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
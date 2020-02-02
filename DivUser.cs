using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Div
{
    public class DivUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        public ICollection<DivAssignment> CreatedDivAssignments { get; set; }
        public ICollection<DivAssignment> ModifiedDivAssignments { get; set; }
    }
}
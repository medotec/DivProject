using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Div
{
    public abstract class DivBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }

        public int CreatedByUserId { get; set; }

        [Required]
        public DateTimeOffset LastDateModified { get; set; }

        public int LastModifiedByUserId { get; set; }

        [ForeignKey("CreatedByUserId")]
        public DivUser CreatedByUser { get; set; }

        [ForeignKey("LastModifiedByUserId")]
        public DivUser LastModifiedByUser { get; set; }
    }
}
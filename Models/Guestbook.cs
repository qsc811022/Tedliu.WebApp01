namespace Tedliu.WebApp01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Guestbook
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string Reply { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReplyTime { get; set; }
    }
}

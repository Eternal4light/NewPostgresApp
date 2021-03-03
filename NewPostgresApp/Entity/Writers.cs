using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewPostgresApp
{
    public class Writers
    {
        [Required]
        [Column("ID")]
        public Guid ID { get; set; }


        [Column("Name")]
        [StringLength(128)]
        public string Name { get; set; }

        public virtual List<Posts> Posted { get; set; } //также является навигационным свойством.

        




    }
}

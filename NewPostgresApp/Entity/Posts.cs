using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewPostgresApp
{
    public class Posts
    {
        [Required]
        [Column("ID")]
        public Guid ID { get; set; }



        [Column("Name")]
        public string Name { get; set; }

        [Column("Content")]
        public string Content { get; set; }




        [Column("WriterId")]
        public Guid WriterId { get; set; } //внешний ключ


        public virtual Writers Writer { get; set; } // навигационное св-во

    }
}

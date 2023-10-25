using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("word")]
    public class Word
    {
        public Word() { }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [MaxLength(255)]
        [Column("term")]
        public string Term { get; set; }

        [Column("date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public virtual List<Definition> Definition{ get; set; }
    }
}

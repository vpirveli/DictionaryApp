using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Word
    {
        public Word(){}

        [Key]
        public Guid Id { get; set; }
        [MaxLength(255)]
        public string Term { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public virtual List<Definition> Definition{ get; set; }
    }
}

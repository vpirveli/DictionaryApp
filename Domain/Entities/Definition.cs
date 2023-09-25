using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Definition
    {
        public Definition(){}

        [Key]
        public Guid Id { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [ForeignKey("WordId")]
        public Guid WordId { get; set; }
        public virtual Word Word { get; set; }
    }
}

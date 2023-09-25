using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class WordDTO
    {
        public string Term { get; set; }
        public List<string> Definition { get; set; }
    }
}

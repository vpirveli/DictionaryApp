﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Term { get; set; }
        public List<Definition> Definitions{ get; set; }
    }
}

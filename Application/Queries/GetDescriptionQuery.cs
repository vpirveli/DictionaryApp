﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetDefinitionQuery : IRequest<Definition>
    {
        public string Definition { get; set; } 
    }
}

﻿using Application.DTOs;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetWordQuery:IRequest<WordDTO>
    {
        public Guid WordId { get; set; } 
    }
}

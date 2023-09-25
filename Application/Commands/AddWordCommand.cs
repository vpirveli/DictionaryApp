using Application.DTOs;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class AddWordCommand : IRequest<Guid>
    {
        public string Term { get; set; }
        public string Description { get; set; }
    }
}

using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class AddDescriptionCommand : IRequest<Definition>
    {
        public AddDescriptionCommand(Definition definition) 
        {
            Description = definition.Description;
        }
        public string Description { get; set; }
    }
}

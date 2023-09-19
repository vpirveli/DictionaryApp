using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    internal class AddWordCommand : IRequest<int>
    {
        public string Term { get; set; }
    }
}

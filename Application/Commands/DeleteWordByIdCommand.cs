using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteWordByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}

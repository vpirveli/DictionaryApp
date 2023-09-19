using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    internal class GetWordQuery:IRequest<int>
    {
        public int WordId { get; set; } 
    }
}

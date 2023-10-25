using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    internal interface IQueryServices
    {
        string? GetCollumnNameAttribute(Type type, string v);
    }
}

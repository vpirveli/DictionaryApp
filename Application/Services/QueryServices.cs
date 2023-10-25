using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class QueryServices : IQueryServices
    {
        public string? GetCollumnNameAttribute(Type type, string propertyName)
        {
            var columnAttribute = (ColumnAttribute?)type.GetProperties()
                                                       .FirstOrDefault(p => p.Name == propertyName)?
                                                       .GetCustomAttributes(typeof(ColumnAttribute), false)
                                                       .FirstOrDefault();

            return columnAttribute == null ? "" : columnAttribute.Name;
        }
    }
}

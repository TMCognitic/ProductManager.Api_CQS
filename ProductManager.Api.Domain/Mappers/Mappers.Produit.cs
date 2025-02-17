using ProductManager.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Api.Domain.Mappers
{
    internal static partial class Mappers
    {
        internal static Produit ToProduit(this IDataRecord record)
        {
            return new Produit((int)record["Id"], (string)record["Nom"], (double)record["Prix"]);
        }
    }
}

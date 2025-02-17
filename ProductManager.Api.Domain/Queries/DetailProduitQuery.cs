using CommandQuerySeparation.Queries;
using ProductManager.Api.Domain.Entities;

namespace ProductManager.Api.Domain.Queries
{
    public class DetailProduitQuery : IQueryDefinition<Produit?>
    {
        public int Id { get; }

        public DetailProduitQuery(int id)
        {
            Id = id;
        }
    }
}

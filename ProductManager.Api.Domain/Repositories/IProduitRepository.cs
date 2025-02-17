using CommandQuerySeparation.Commands;
using CommandQuerySeparation.Queries;
using ProductManager.Api.Domain.Commands;
using ProductManager.Api.Domain.Entities;
using ProductManager.Api.Domain.Queries;

namespace ProductManager.Api.Domain.Repositories
{
    public interface IProduitRepository :
        IQueryHandler<ListeProduitQuery, IEnumerable<Produit>>,
        IQueryHandler<DetailProduitQuery, Produit?>,
        ICommandHandler<AjoutProduitCommand>,
        ICommandHandler<ModifierProduitCommand>,
        ICommandHandler<SupprimerProduitCommand>
    {
    }
}

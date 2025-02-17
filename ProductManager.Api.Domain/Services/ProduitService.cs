using BStorm.Tools.Database;
using ProductManager.Api.Domain.Commands;
using ProductManager.Api.Domain.Entities;
using ProductManager.Api.Domain.Mappers;
using ProductManager.Api.Domain.Queries;
using ProductManager.Api.Domain.Repositories;
using System.Data.Common;

namespace ProductManager.Api.Domain.Services
{
    public class ProduitService : IProduitRepository
    {
        private readonly DbConnection _dbConnection;

        public ProduitService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public bool Execute(AjoutProduitCommand command)
        {
            return 1 == _dbConnection.ExecuteNonQuery("AppUserSchema.AjoutProduit", true, command);
        }

        public IEnumerable<Produit> Execute(ListeProduitQuery query)
        {
            return _dbConnection.ExecuteReader("[AppUserSchema].[ListeProduits]", dr => dr.ToProduit(), true);
        }

        public Produit? Execute(DetailProduitQuery query)
        {
            return _dbConnection.ExecuteReader("[AppUserSchema].[ProduitParId]", dr => dr.ToProduit(), true, query).SingleOrDefault();
        }

        public bool Execute(SupprimerProduitCommand command)
        {
            return 1 == _dbConnection.ExecuteNonQuery("[AppUserSchema].[SupprimeProduit]", true, command);
        }

        public bool Execute(ModifierProduitCommand command)
        {
            return 1 == _dbConnection.ExecuteNonQuery("[AppUserSchema].[ModifieProduit]", true, command);
        }
    }
}

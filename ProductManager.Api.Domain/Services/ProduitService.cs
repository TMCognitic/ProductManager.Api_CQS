using BStorm.Tools.Database;
using CommandQuerySeparation.Results;
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

        public Result Execute(AjoutProduitCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("AppUserSchema.AjoutProduit", true, command);

                if(rows != 1)
                    return Result.Failure($"Quelque chose d'anormal s'est produit => nombre de ligne affectée {rows}");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
        }

        public Result<IEnumerable<Produit>> Execute(ListeProduitQuery query)
        {
            try
            {
                return Result<IEnumerable<Produit>>.Success(_dbConnection.ExecuteReader("[AppUserSchema].[ListeProduits]", dr => dr.ToProduit(), true).ToArray());
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Produit>>.Failure(ex.Message, ex);
            }
        }

        public Result<Produit> Execute(DetailProduitQuery query)
        {
            try
            {
                Produit? produit = _dbConnection.ExecuteReader("[AppUserSchema].[ProduitParId]", dr => dr.ToProduit(), true, query).SingleOrDefault();

                if(produit is null)
                    return Result<Produit>.Failure("Produit non trouvé");

                return Result<Produit>.Success(produit);
            }
            catch (Exception ex)
            {
                return Result<Produit>.Failure(ex.Message, ex);
            }
        }

        public Result Execute(SupprimerProduitCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("[AppUserSchema].[SupprimeProduit]", true, command);

                if (rows is 0)
                    throw new Exception("Produit non trouvé");

                if (rows != 1)
                    return Result.Failure($"Quelque chose d'anormal s'est produit => nombre de ligne affectée {rows}");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
        }

        public Result Execute(ModifierProduitCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("[AppUserSchema].[ModifieProduit]", true, command);

                if (rows is 0)
                    throw new Exception("Produit non trouvé");

                if (rows != 1)
                    return Result.Failure($"Quelque chose d'anormal s'est produit => nombre de ligne affectée {rows}");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message, ex);
            }
        }
    }
}

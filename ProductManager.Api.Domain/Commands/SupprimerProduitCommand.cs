using CommandQuerySeparation.Commands;

namespace ProductManager.Api.Domain.Commands
{
    public class SupprimerProduitCommand : ICommandDefinition
    {
        public int Id { get; }

        public SupprimerProduitCommand(int id)
        {
            Id = id;
        }
    }
}

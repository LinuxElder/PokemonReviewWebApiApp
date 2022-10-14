using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfPokemon(int pokemonId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExists(int ownerId);
    }
}

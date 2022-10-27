using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        ICollection<Review> GetReviewsOfAPokemon(int pokemonId);
        Review GetReview(int reviewId);
        bool ReviewExists(int reviewId);
    }
}

using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
       

        public ReviewRepository(DataContext context)
        {
           _context = context;          
        }
        public ICollection<Review> GetReviewsOfAPokemon(int pokemonId)
        {
           return _context.Reviews.Where(r =>r.Pokemon.Id == pokemonId).ToList();
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.All(r =>r.Id == reviewId);
        }
    }
}

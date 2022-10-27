using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        ICollection<Reviewer> GetReviewesByReviewer(int reviewerID);
        Reviewer GetReviewer(int reviewerId);
        bool ReviewerExists(int reviewerID);
    }
}

using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public ICollection<Reviewer> GetReviewesByReviewer(int reviewerID)
        {
            throw new NotImplementedException();
        }

        public bool ReviewerExists(int reviewerID)
        {
            return _context.Reviewers.All(r => r.Id == reviewerID);
        }
    }
}

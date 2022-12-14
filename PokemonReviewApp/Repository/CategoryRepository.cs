using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository

    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool CategoryExistsByName(string id)
        {
            return _context.Categories.Any(c => c.Name == id);
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(p => p.Id == id).FirstOrDefault();
        }


        public ICollection<Pokemon> GetPokemonByCategory(int id)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == id).Select(c => c.Pokemon).ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }
    }
}

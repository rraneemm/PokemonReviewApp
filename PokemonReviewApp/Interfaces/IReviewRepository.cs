using Pokemon_Review_App.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        ICollection<Review> GetReviewsOfPokemon(int pokemonId);
        Review GetReviewById(int id);
        bool ReviewExists(int id);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool DeleteReview(int id);
        bool DeleteReviews(List<int> ids);
        bool Save();
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pokemon_Review_App.Data;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class ReviewRepository : IReviewRepository
    {

        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;

        }
        public bool CreateReview(Review review)
        {
            _context.Add(review);
            return Save();
        }


        public bool DeleteReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }


        public bool DeleteReviews(List<Review> reviews)
        {
            _context.Remove(reviews);
            return Save();
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfPokemon(int pokemonId)
        {
            return _context.Reviews.Where(p => p.Pokemon.Id == pokemonId).ToList();
        }

        public bool ReviewExists(int id)
        {
            return _context.Reviews.Any(r => r.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }
    }
}

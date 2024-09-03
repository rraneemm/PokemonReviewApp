using AutoMapper;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Dtos;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}

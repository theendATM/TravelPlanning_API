using Microsoft.EntityFrameworkCore;
using System.Linq;
using tpa_backend.Data;
using tpa_backend.DTOModels;

namespace tpa_backend.Services
{
    public interface ISelectInfoService
    {
        public List<CityViewDTO> GetCities();
        public List<MovingTypeViewDTO> GetMovingTypes();
        public List<DifficultyViewDTO> GetDifficulties();
        public List<InterestViewDTO> GetInterests();
    }

    public class SelectInfoService : ISelectInfoService
    {
        AppDbContext _context;
        public SelectInfoService(AppDbContext context)
        {
            _context = context;
        }

        public List<CityViewDTO> GetCities()
        {
            var cities = _context.Cities.Select(c => new CityViewDTO
            {
                Id=c.Id,
                Name = c.Name,
            }).ToList();

            return cities;
        }

        public List<DifficultyViewDTO> GetDifficulties()
        {
            var diffs = _context.Difficulties.Select(c => new DifficultyViewDTO
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return diffs;
        }

        public List<MovingTypeViewDTO> GetMovingTypes()
        {
            var mt = _context.MovingTypes.Select(c => new MovingTypeViewDTO
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return mt;
        }

        public List<InterestViewDTO> GetInterests()
        {
            var interests = _context.Interests.Select(c => new InterestViewDTO
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return interests;
        }

        
    }
}
